using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class SensorService
    {
        private readonly IMongoCollection<Sensor> _sensors;
        public SensorService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensors = database.GetCollection<Sensor>(settings.SensorCollectionName);

        }

        public List<Sensor> GetAllAsync()
        {
            List<Sensor> sensors;
            sensors = _sensors.Find(emp => true).ToList();
            return sensors;
        }

        public async Task<Sensor> GetByIdAsync(string id)
        {
            return await _sensors.Find<Sensor>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Sensor> CreateAsync(Sensor sensor)
        {
            await _sensors.InsertOneAsync(sensor);
            return sensor;
        }
        public async Task UpdateAsync(string id, Sensor sensor)
        {
            await _sensors.ReplaceOneAsync(c => c.Id == id, sensor);
        }
        public async Task DeleteAsync(string id)
        {
            await _sensors.DeleteOneAsync(c => c.Id == id);
        }
    }
}
