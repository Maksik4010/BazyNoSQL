using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class PrisonLocationService
    {
        private readonly IMongoCollection<PrisonLocation> _prisonLocations;
        public PrisonLocationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prisonLocations = database.GetCollection<PrisonLocation>(settings.PrisonLocationCollectionName);

        }

        public List<PrisonLocation> GetAllAsync()
        {
            List<PrisonLocation> prisonLocations;
            prisonLocations = _prisonLocations.Find(emp => true).ToList();
            return prisonLocations;
        }

        public async Task<PrisonLocation> GetByIdAsync(string id)
        {
            return await _prisonLocations.Find<PrisonLocation>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PrisonLocation> CreateAsync(PrisonLocation prisonLocation)
        {
            await _prisonLocations.InsertOneAsync(prisonLocation);
            return prisonLocation;
        }
        public async Task UpdateAsync(string id, PrisonLocation prisonLocation)
        {
            await _prisonLocations.ReplaceOneAsync(c => c.Id == id, prisonLocation);
        }
        public async Task DeleteAsync(string id)
        {
            await _prisonLocations.DeleteOneAsync(c => c.Id == id);
        }
    }
}
