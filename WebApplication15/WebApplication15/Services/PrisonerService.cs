using WebApplication15.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;

namespace WebApplication15.Services
{
    public class PrisonerService
    {
        private readonly IMongoCollection<Prisoner> _prisoners;
        public PrisonerService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prisoners = database.GetCollection<Prisoner>(settings.PrisonerCollectionName);

        }

        public List<Prisoner> GetAllAsync()
        {
            List<Prisoner> prisoners;
            prisoners = _prisoners.Find(emp => true).ToList();
            return prisoners;
        }

        public async Task<Prisoner> GetByIdAsync(string id)
        {
         return  await _prisoners.Find<Prisoner>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Prisoner> CreateAsync (Prisoner prisoner)
        {
            await _prisoners.InsertOneAsync(prisoner);
            return prisoner;
        }
        public async Task UpdateAsync (string id, Prisoner prisoner)
        {
            await _prisoners.ReplaceOneAsync(c => c.Id == id, prisoner);
        }
        public async Task DeleteAsync (string id)
        {
            await _prisoners.DeleteOneAsync(c => c.Id == id);
        }
    }
}
