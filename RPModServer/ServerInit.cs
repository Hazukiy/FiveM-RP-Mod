using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using RPModShared;
using CitizenFX.Core.Native;

namespace RPModServer
{
    public class ServerInit : BaseScript
    {
        public ServerInit()
        {
            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
            EventHandlers["rpGetPlayerData"] += new Action<Player>(OnGetPlayerData);
            EventHandlers["rpSavePlayerData"] += new Action<Player, ExpandoObject>(OnPlayerSaveData);
        }

        private void OnPlayerSaveData([FromSource] Player player, ExpandoObject playerData)
        {
            var licenseID = player.Identifiers["license"];
            if (string.IsNullOrEmpty(licenseID))
            {
                throw new InvalidOperationException($"Warning - license ID for player ({player.Name}) was empty! Failed to get player data.");
            }

            var data = Helper.Instance.ConvertToModel(playerData);

            // Save data 
            DatabaseEngine.Instance.SavePlayer(data);
        }

        private void OnGetPlayerData([FromSource] Player player)
        {
            var licenseID = player.Identifiers["license"];
            if (string.IsNullOrEmpty(licenseID))
            {
                throw new InvalidOperationException($"Warning - license ID for player ({player.Name}) was empty! Failed to get player data.");
            }

            // Get playe data from DB
            var data = DatabaseEngine.Instance.GetPlayerData(player, licenseID);

            // Trigger player event
            TriggerClientEvent(player, "rpOnDataUpdated", data);
        }

        private void OnResourceStart(string resourceName)
        {
            Debug.WriteLine($"RP Mod server loaded");
        }
    }
}
