using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication15.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PrisonerCollectionName { get; set; }
        public string ApplicationCollectionName { get; set; }
        public string ApplicationTypeCollectionName { get; set; }
        public string GuardCollectionName { get; set; }
        public string GuiltCollectionName { get; set; }
        public string JobCollectionName { get; set; }
        public string LocationCollectionName { get; set; }
        public string PrisonerJobCollectionName { get; set; }
        public string PrisonLocationCollectionName { get; set; }
        public string PrisonPositionCollectionName { get; set; }
        public string PrisonRankCollectionName { get; set; }
        public string ScheduleCollectionName { get; set; }
        public string SensorCollectionName { get; set; }
        public string SensorLogCollectionName { get; set; }
        public string SensorTypeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IDatabaseSettings
    {
        public string PrisonerCollectionName { get; set; }
        public string ApplicationCollectionName { get; set; }
        public string ApplicationTypeCollectionName { get; set; }
        public string GuardCollectionName { get; set; }
        public string GuiltCollectionName { get; set; }
        public string JobCollectionName { get; set; }
        public string LocationCollectionName { get; set; }
        public string PrisonerJobCollectionName { get; set; }
        public string PrisonLocationCollectionName { get; set; }
        public string PrisonPositionCollectionName { get; set; }
        public string PrisonRankCollectionName { get; set; }
        public string ScheduleCollectionName { get; set; }
        public string SensorCollectionName { get; set; }
        public string SensorLogCollectionName { get; set; }
        public string SensorTypeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
