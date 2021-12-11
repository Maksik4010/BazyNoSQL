using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class PrisonRankService
    {
        private readonly IMongoCollection<PrisonRank> _prisonRanks;
        public PrisonRankService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prisonRanks = database.GetCollection<PrisonRank>(settings.PrisonRankCollectionName);

        }

        public List<PrisonRank> GetAllAsync()
        {
            List<PrisonRank> prisonRanks;
            prisonRanks = _prisonRanks.Find(emp => true).ToList();
            return prisonRanks;
        }

        public async Task<PrisonRank> GetByIdAsync(string id)
        {
            return await _prisonRanks.Find<PrisonRank>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PrisonRank> CreateAsync(PrisonRank prisonRank)
        {
            await _prisonRanks.InsertOneAsync(prisonRank);
            return prisonRank;
        }
        public async Task UpdateAsync(string id, PrisonRank prisonRank)
        {
            await _prisonRanks.ReplaceOneAsync(c => c.Id == id, prisonRank);
        }
        public async Task DeleteAsync(string id)
        {
            await _prisonRanks.DeleteOneAsync(c => c.Id == id);
        }
    }
}
