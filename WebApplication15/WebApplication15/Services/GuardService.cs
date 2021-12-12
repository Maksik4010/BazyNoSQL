using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class GuardService
    {
        private readonly IMongoCollection<Guard> _guards;
        public GuardService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _guards = database.GetCollection<Guard>(settings.GuardCollectionName);

        }

        public List<Guard> GetAllAsync()
        {
            List<Guard> guards;
            guards = _guards.Find(emp => true).ToList();
            return guards;
        }

        public async Task<Guard> GetByIdAsync(string id)
        {
            return await _guards.Find<Guard>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Guard> CreateAsync(Guard guard)
        {
            await _guards.InsertOneAsync(guard);
            return guard;
        }
        public async Task UpdateAsync(string id, Guard guard)
        {
            await _guards.ReplaceOneAsync(c => c.Id == id, guard);
        }
        public async Task DeleteAsync(string id)
        {
            await _guards.DeleteOneAsync(c => c.Id == id);
        }
    }
}
