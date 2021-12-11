using ConsoleApp2.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class ApplicationTypeService
    {
        private readonly IMongoCollection<ApplicationType> _applicationTypes;
        public ApplicationTypeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _applicationTypes = database.GetCollection<ApplicationType>(settings.ApplicationTypeCollectionName);

        }

        public List<ApplicationType> GetAllAsync()
        {
            List<ApplicationType> applicationTypes;
            applicationTypes = _applicationTypes.Find(emp => true).ToList();
            return applicationTypes; 
        }

        public async Task<ApplicationType> GetByIdAsync(string id)
        {
            return await _applicationTypes.Find<ApplicationType>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ApplicationType> CreateAsync(ApplicationType applicationType)
        {
            await _applicationTypes.InsertOneAsync(applicationType);
            return applicationType;
        }
        public async Task UpdateAsync(string id, ApplicationType applicationType)
        {
            await _applicationTypes.ReplaceOneAsync(c => c.Id == id, applicationType);
        }
        public async Task DeleteAsync(string id)
        {
            await _applicationTypes.DeleteOneAsync(c => c.Id == id);
        }
    }
}
