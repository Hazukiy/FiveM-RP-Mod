using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModShared
{
    public class PlayerDataModel
    {
        // Account related
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseID { get; set; }

        // Money related
        public long Wallet { get; set; }
        public long Bank { get; set; }
        public long Debt { get; set; }

        public override string ToString()
        {
            return $"Account for ID {Id} ({LicenseID}) {Name} | Wallet: ${Wallet} | Bank: ${Bank} | Debt: ${Debt}";
        }
    }
}
