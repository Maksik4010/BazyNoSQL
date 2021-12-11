using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class PrisonPositionService
    {
        private readonly IMongoCollection<PrisonPosition> _prisonPositions;
        public PrisonPositionService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prisonPositions = database.GetCollection<PrisonPosition>(settings.PrisonPositionCollectionName);

        }

        public List<PrisonPosition> GetAllAsync()
        {
            List<PrisonPosition> prisonPositions;
            prisonPositions = _prisonPositions.Find(emp => true).ToList();
            return prisonPositions;
        }

        public async Task<PrisonPosition> GetByIdAsync(string id)
        {
            return await _prisonPositions.Find<PrisonPosition>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PrisonPosition> CreateAsync(PrisonPosition prisonPosition)
        {
            await _prisonPositions.InsertOneAsync(prisonPosition);
            return prisonPosition;
        }
        public async Task UpdateAsync(string id, PrisonPosition prisonPosition)
        {
            await _prisonPositions.ReplaceOneAsync(c => c.Id == id, prisonPosition);
        }
        public async Task DeleteAsync(string id)
        {
            await _prisonPositions.DeleteOneAsync(c => c.Id == id);
        }
    }
}
