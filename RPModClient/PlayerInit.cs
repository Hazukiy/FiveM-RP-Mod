using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using RPModShared;
using static CitizenFX.Core.Native.API;

namespace RPModClient
{
    public class PlayerInit : BaseScript
    {
        // Centre of town
        private static Vector3 SpawnLocation = new Vector3() { X = 195.9843f, Y = -933.7408f, Z = 30.68679f };

        public PlayerInit()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawned);
            EventHandlers["rpOnDataUpdated"] += new Action<ExpandoObject>(OnDataUpdated);

            // Make a request to retrieve player data
            TriggerServerEvent("rpGetPlayerData");

            // Start timers
            Tick += SalaryTick;
        }

        private async Task SalaryTick()
        {
            PlayerConstants.NextSalary--;

            if(PlayerConstants.NextSalary <= 0)
            {
                PlayerConstants.NextSalary = 60;

                PlayerConstants.PlayerProfile.Bank += PlayerConstants.PlayerProfile.Salary;

                TriggerServerEvent("rpSavePlayerData", PlayerConstants.PlayerProfile);

                ClientHelper.Instance.PrintToClient($"Salary income of ${PlayerConstants.PlayerProfile.Salary}");
            }

            await Delay(1000);
        }

        private void OnDataUpdated(ExpandoObject playerData)
        {
            PlayerConstants.PlayerProfile = Helper.Instance.ConvertToModel(playerData);
            Debug.WriteLine($"Loaded player profile: {PlayerConstants.PlayerProfile}");
        }

        private void OnPlayerSpawned(object spawnInfo)
        {
            // NOTE: Although we can use spawnmanager resource, going to use it here directly
            if(Game.PlayerPed.IsAlive)
            {
                Game.PlayerPed.Position = SpawnLocation;
            }

            // Change the player model
            Game.Player.ChangeModel(new Model(PedHash.Hillbilly01AMM)); 
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            // Loop through the list of command and register dynamically
            try
            {
                foreach (var cmd in Commands.Instance.DynamicRegister)
                {
                    RegisterCommand(cmd.Name, cmd.ActionDelegate, cmd.IsRestrictedCommand);
                    Debug.WriteLine($"Successfully registered command: {cmd.Name}");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error trying to dynamically register commands: {ex}");
            }
        }
    }
}
