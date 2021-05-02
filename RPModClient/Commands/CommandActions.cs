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
    public class CommandActions : BaseScript
    {
        #region Singleton
        private static CommandActions _instance;
        public static CommandActions Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CommandActions();
                }
                return _instance;
            }
        }
        #endregion

        private CommandActions()
        {

        }

        public void GetPlayerLocation(int source, List<object> args, string raw)
        {
            Helper.Instance.PrintToClient($"Location | X: {Game.PlayerPed.Position.X} | Y: {Game.PlayerPed.Position.Y} | Z: {Game.PlayerPed.Position.Z}", MessageType.Information);
        }

        public void Die(int source, List<object> args, string raw)
        {
            Game.PlayerPed.Kill();
            Helper.Instance.PrintToClient($"You killed yourself.", MessageType.Warning);
        }
    }
}
