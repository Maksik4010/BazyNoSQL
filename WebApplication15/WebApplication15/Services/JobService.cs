using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class JobService
    {
        private readonly IMongoCollection<Job> _jobs;
        public JobService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _jobs = database.GetCollection<Job>(settings.JobCollectionName);

        }

        public List<Job> GetAllAsync()
        {
            List<Job> jobs;
            jobs = _jobs.Find(emp => true).ToList();
            return jobs;
        }

        public async Task<Job> GetByIdAsync(string id)
        {
            return await _jobs.Find<Job>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Job> CreateAsync(Job job)
        {
            await _jobs.InsertOneAsync(job);
            return job;
        }
        public async Task UpdateAsync(string id, Job job)
        {
            await _jobs.ReplaceOneAsync(c => c.Id == id, job);
        }
        public async Task DeleteAsync(string id)
        {
            await _jobs.DeleteOneAsync(c => c.Id == id);
        }
    }
}
