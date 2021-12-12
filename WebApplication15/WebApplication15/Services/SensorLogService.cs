using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class SensorLogService
    {
        private readonly IMongoCollection<SensorLog> _sensorLogs;
        public SensorLogService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensorLogs = database.GetCollection<SensorLog>(settings.SensorLogCollectionName);

        }

        public List<SensorLog> GetAllAsync()
        {
            List<SensorLog> sensorlogs;
            sensorlogs = _sensorLogs.Find(emp => true).ToList();
            return sensorlogs;
        }

        public async Task<SensorLog> GetByIdAsync(string id)
        {
            return await _sensorLogs.Find<SensorLog>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<SensorLog> CreateAsync(SensorLog sensorlog)
        {
            await _sensorLogs.InsertOneAsync(sensorlog);
            return sensorlog;
        }
        public async Task UpdateAsync(string id, SensorLog sensorlog)
        {
            await _sensorLogs.ReplaceOneAsync(c => c.Id == id, sensorlog);
        }
        public async Task DeleteAsync(string id)
        {
            await _sensorLogs.DeleteOneAsync(c => c.Id == id);
        }
    }
}
