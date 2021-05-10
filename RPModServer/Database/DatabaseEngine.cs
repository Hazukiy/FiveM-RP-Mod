using System.IO;
using System.Linq;
using CitizenFX.Core;
using RPModShared;
using LiteDB;

namespace RPModServer
{
    public class DatabaseEngine : BaseScript
    {
        #region Singleton
        private static DatabaseEngine _instance;
        public static DatabaseEngine Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DatabaseEngine();
                }
                return _instance;
            }
        }
        #endregion

        private readonly string _databaseLocation = Path.Combine(Directory.GetCurrentDirectory(), @"FiveMRP-Database.db");

        private DatabaseEngine()
        {
        }

        public PlayerDataModel GetPlayerData(Player player, string licenseID)
        {
            using (var db = new LiteDatabase(_databaseLocation))
            {
                var col = db.GetCollection<PlayerDataModel>("playerData");

                if (col.Exists(x => x.LicenseID.Equals(licenseID)))
                {
                    Debug.WriteLine($"Found record with licenseID: {licenseID}");
                    return col.FindOne(x => x.LicenseID.Equals(licenseID));
                }
                else
                {
                    var data = new PlayerDataModel()
                    {
                        Name = player.Name,
                        LicenseID = licenseID,
                        Wallet = DefaultAccount.DefaultWallet,
                        Bank = DefaultAccount.DefaultBank,
                        Debt = DefaultAccount.DefaultDebt
                    };

                    var result = col.Insert(data);

                    Debug.WriteLine($"Record does NOT exist, adding new record for licenseID: {licenseID}");

                    return data;
                }
            }
        }

        public void SaveBank(long newValue, string licenseID)
        {
            using (var db = new LiteDatabase(_databaseLocation))
            {
                // Grab the collection
                var col = db.GetCollection<PlayerDataModel>("playerData");
                var playerData = col.Find(x => x.LicenseID.Contains(licenseID)).FirstOrDefault();
                playerData.Bank = newValue;

                // Update & get transaction result
                var result = col.Update(playerData);
                if(result)
                {
                    Debug.WriteLine($"Successfully updated bank to ${playerData.Bank} for licenseID: {licenseID}");
                }
                else
                {
                    Debug.WriteLine($"Failed to update bank for licenseID: {licenseID}");
                }
            }
        }
    }
}
