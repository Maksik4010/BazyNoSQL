using WebApplication15.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class ApplicationService
    {
        private readonly IMongoCollection<Application> _applications;
        public ApplicationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _applications = database.GetCollection<Application>(settings.ApplicationCollectionName);

        }

        public List<Application> GetAllAsync()
        {
            List<Application> applications;
            applications = _applications.Find(emp => true).ToList();
            return applications;
        }

        public async Task<Application> GetByIdAsync(string id)
        {
            return await _applications.Find<Application>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Application> CreateAsync(Application application)
        {
            await _applications.InsertOneAsync(application);
            return application;
        }
        public async Task UpdateAsync(string id, Application application)
        {
            await _applications.ReplaceOneAsync(c => c.Id == id, application);
        }
        public async Task DeleteAsync(string id)
        {
            await _applications.DeleteOneAsync(c => c.Id == id);
        }
    }
}
