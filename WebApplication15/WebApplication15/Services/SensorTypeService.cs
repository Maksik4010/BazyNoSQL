using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class SensorTypeService
    {
        private readonly IMongoCollection<SensorType> _sensorTypes;
        public SensorTypeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensorTypes = database.GetCollection<SensorType>(settings.SensorTypeCollectionName);

        }

        public List<SensorType> GetAllAsync()
        {
            List<SensorType> sensorTypes;
            sensorTypes = _sensorTypes.Find(emp => true).ToList();
            return sensorTypes;
        }

        public async Task<SensorType> GetByIdAsync(string id)
        {
            return await _sensorTypes.Find<SensorType>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<SensorType> CreateAsync(SensorType sensortype)
        {
            await _sensorTypes.InsertOneAsync(sensortype);
            return sensortype;
        }
        public async Task UpdateAsync(string id, SensorType sensortype)
        {
            await _sensorTypes.ReplaceOneAsync(c => c.Id == id, sensortype);
        }
        public async Task DeleteAsync(string id)
        {
            await _sensorTypes.DeleteOneAsync(c => c.Id == id);
        }
    }
}
