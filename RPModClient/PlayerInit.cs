using System;
using System.Dynamic;
using System.Threading.Tasks;
using RPModShared;
using CitizenFX.Core;
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

                PlayerConstants.PlayerProfile.Bank += PlayerConstants.CurrentJob.BaseSalary;

                TriggerServerEvent("rpSaveBank", PlayerConstants.PlayerProfile.Bank);

                ClientHelper.Instance.PrintToClient($"Salary income of ${PlayerConstants.CurrentJob.BaseSalary}");
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
            Random rnd = new Random();
            Game.Player.ChangeModel(new Model(PlayerConstants.CurrentJob.Models[rnd.Next(0, PlayerConstants.CurrentJob.Models.Count)])); 
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
