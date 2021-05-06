using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace RPModServer
{
    public class DatabaseEvents : BaseScript
    {
        public DatabaseEvents()
        {
            EventHandlers["rpGetPlayerData"] += new Action<Player>(OnGetPlayerData);
            EventHandlers["rpSaveBank"] += new Action<Player, long>(OnPlayerSaveBank);
        }

        private void OnPlayerSaveBank([FromSource] Player player, long newValue)
        {
            var licenseID = CheckLicense(player);

            // Save data 
            DatabaseEngine.Instance.SaveBank(newValue, licenseID);
        }

        private void OnGetPlayerData([FromSource] Player player)
        {
            var licenseID = CheckLicense(player);

            // Get playe data from DB
            var data = DatabaseEngine.Instance.GetPlayerData(player, licenseID);

            // Trigger player event
            TriggerClientEvent(player, "rpOnDataUpdated", data);
        }

        private string CheckLicense(Player player)
        {
            // NOTE: Check it's valid
            var licenseID = player.Identifiers["license"];
            if (string.IsNullOrEmpty(licenseID))
            {
                throw new InvalidOperationException($"Warning - licenseID for player ({player.Name}) was empty! Failed to get player data.");
            }

            return licenseID;
        }
    }
}
