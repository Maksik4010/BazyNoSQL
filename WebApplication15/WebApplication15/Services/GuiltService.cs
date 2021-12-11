using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class GuiltService
    {
        private readonly IMongoCollection<Guilt> _guilts;
        public GuiltService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _guilts = database.GetCollection<Guilt>(settings.GuiltCollectionName);

        }

        public List<Guilt> GetAllAsync()
        {
            List<Guilt> guilts;
            guilts = _guilts.Find(emp => true).ToList();
            return guilts;
        }

        public async Task<Guilt> GetByIdAsync(string id)
        {
            return await _guilts.Find<Guilt>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Guilt> CreateAsync(Guilt guilt)
        {
            await _guilts.InsertOneAsync(guilt);
            return guilt;
        }
        public async Task UpdateAsync(string id, Guilt guilt)
        {
            await _guilts.ReplaceOneAsync(c => c.Id == id, guilt);
        }
        public async Task DeleteAsync(string id)
        {
            await _guilts.DeleteOneAsync(c => c.Id == id);
        }
    }
}
