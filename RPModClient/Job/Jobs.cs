using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace RPModClient.Job
{
    public class Jobs
    {
        #region Singleton
        private static Jobs _instance;
        public static Jobs Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Jobs();
                }
                return _instance;
            }
        }
        #endregion

        //https://docs.fivem.net/docs/game-references/ped-models/#ambient-male
        private Jobs()
        {

        }

        // NOTE: Add new JOBS into here to they can be registered dynamically
        public List<CommandRegisterModel> DynamicRegister = new List<CommandRegisterModel>()
        {
            
        };

        #region Standard Job Roles
        public static JobsModel Unemployed = new JobsModel()
        {
            Name = "Unemployed",
            BaseSalary = 10,
            SalaryIncreaseRate = 0,
            Permissions = new List<JobPermissionSet>() { JobPermissionSet.None },
            Models = new List<PedHash>()
            {  
                PedHash.Hillbilly01AMM,
                PedHash.Hillbilly02AMM,
                PedHash.Soucent02AFM,
                PedHash.Soucent02AFO
            }
        };
        #endregion
    }
}
