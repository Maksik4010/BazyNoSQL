using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class ScheduleService
    {
        private readonly IMongoCollection<Schedule> _schedules;
        public ScheduleService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _schedules = database.GetCollection<Schedule>(settings.ScheduleCollectionName);

        }

        public List<Schedule> GetAllAsync()
        {
            List<Schedule> schedules;
            schedules = _schedules.Find(emp => true).ToList();
            return schedules;
        }

        public async Task<Schedule> GetByIdAsync(string id)
        {
            return await _schedules.Find<Schedule>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            await _schedules.InsertOneAsync(schedule);
            return schedule;
        }
        public async Task UpdateAsync(string id, Schedule schedule)
        {
            await _schedules.ReplaceOneAsync(c => c.Id == id, schedule);
        }
        public async Task DeleteAsync(string id)
        {
            await _schedules.DeleteOneAsync(c => c.Id == id);
        }
    }
}
