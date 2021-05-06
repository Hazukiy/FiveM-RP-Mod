using RPModClient.Job;
using RPModShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModClient
{
    public static class PlayerConstants
    {
        public static PlayerDataModel PlayerProfile { get; set; }

        public static JobsModel CurrentJob { get; set; } = Jobs.Unemployed;

        public static int NextSalary { get; set; } = 60; // Every 60 seconds, same for every job
    }
}
