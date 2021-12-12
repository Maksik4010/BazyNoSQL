using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _locations;
        public LocationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _locations = database.GetCollection<Location>(settings.LocationCollectionName);

        }

        public List<Location> GetAllAsync()
        {
            List<Location> locations;
            locations = _locations.Find(emp => true).ToList();
            return locations;
        }

        public async Task<Location> GetByIdAsync(string id)
        {
            return await _locations.Find<Location>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Location> CreateAsync(Location location)
        {
            await _locations.InsertOneAsync(location);
            return location;
        }
        public async Task UpdateAsync(string id, Location location)
        {
            await _locations.ReplaceOneAsync(c => c.Id == id, location);
        }
        public async Task DeleteAsync(string id)
        {
            await _locations.DeleteOneAsync(c => c.Id == id);
        }
    }
}
