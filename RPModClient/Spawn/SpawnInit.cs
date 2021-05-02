using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace RPModClient
{
    public class SpawnInit : BaseScript
    {
        // Centre of town
        private static Vector3 SpawnLocation = new Vector3() { X = 195.9843f, Y = -933.7408f, Z = 30.68679f };

        public SpawnInit()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawned);
        }

        private void OnPlayerSpawned(object spawnInfo)
        {
            // NOTE: Although we can use spawnmanager resource, going to use it here directly
            if(Game.PlayerPed.IsAlive)
            {
                Game.PlayerPed.Position = SpawnLocation;
            }

            // Change the player model
            Game.Player.ChangeModel(new Model(PedHash.Acult01AMM)); 
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
