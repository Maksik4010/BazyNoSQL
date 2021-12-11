using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class PrisonerJobService
    {
        private readonly IMongoCollection<PrisonerJob> _prisonerJobs;
        public PrisonerJobService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prisonerJobs = database.GetCollection<PrisonerJob>(settings.PrisonerJobCollectionName);

        }

        public List<PrisonerJob> GetAllAsync()
        {
            List<PrisonerJob> prisonerJobs;
            prisonerJobs = _prisonerJobs.Find(emp => true).ToList();
            return prisonerJobs;
        }

        public async Task<PrisonerJob> GetByIdAsync(string id)
        {
            return await _prisonerJobs.Find<PrisonerJob>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PrisonerJob> CreateAsync(PrisonerJob prisonerJob)
        {
            await _prisonerJobs.InsertOneAsync(prisonerJob);
            return prisonerJob;
        }
        public async Task UpdateAsync(string id, PrisonerJob prisonerJob)
        {
            await _prisonerJobs.ReplaceOneAsync(c => c.Id == id, prisonerJob);
        }
        public async Task DeleteAsync(string id)
        {
            await _prisonerJobs.DeleteOneAsync(c => c.Id == id);
        }
    }
}
