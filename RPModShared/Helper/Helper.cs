using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModShared
{
    public class Helper
    {
        #region Singleton
        private static Helper _instance;
        public static Helper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Helper();
                }
                return _instance;
            }
        }
        #endregion

        private Helper()
        {
        }

        public PlayerDataModel ConvertToModel(ExpandoObject obj)
        {
            // TODO: There's gotta be a better way of mapping values
            return new PlayerDataModel()
            {
                Id = Convert.ToInt32(obj.FirstOrDefault(x => x.Key.Equals("Id")).Value),
                Name = obj.FirstOrDefault(x => x.Key.Equals("Name")).Value.ToString(),
                LicenseID = obj.FirstOrDefault(x => x.Key.Equals("LicenseID")).Value.ToString(),
                Wallet = Convert.ToInt64(obj.FirstOrDefault(x => x.Key.Equals("Wallet")).Value),
                Bank = Convert.ToInt64(obj.FirstOrDefault(x => x.Key.Equals("Bank")).Value),
                Salary = Convert.ToInt64(obj.FirstOrDefault(x => x.Key.Equals("Salary")).Value),
                Debt = Convert.ToInt64(obj.FirstOrDefault(x => x.Key.Equals("Debt")).Value)
            };
        }
    }
}
