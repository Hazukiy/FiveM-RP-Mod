using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace RPModClient.Job
{
    public class JobsModel
    {
        public string Name { get; set; }

        public long BaseSalary { get; set; }

        public long SalaryIncreaseRate { get; set; } // How often the user gets a promotion on their base salary

        public List<PedHash> Models { get; set; } // The supported models that role can support

        public List<JobPermissionSet> Permissions { get; set; } // A list of permissions that the job supports

        public List<Vehicle> AuthorisedVehicles { get; set; } // A list of special vehicles that the role is authorised to use

        public Vector3 SpawnLocation { get; set; }
    }
}
