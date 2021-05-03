﻿using System;
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

        public void GetPlayerData(int source, List<object> args, string raw)
        {
            ClientHelper.Instance.PrintToClient($"{PlayerConstants.PlayerProfile}", MessageType.Information);
        }

        public void GetPlayerLocation(int source, List<object> args, string raw)
        {
            ClientHelper.Instance.PrintToClient($"Location | X: {Game.PlayerPed.Position.X} | Y: {Game.PlayerPed.Position.Y} | Z: {Game.PlayerPed.Position.Z}", MessageType.Information);
        }

        public void Die(int source, List<object> args, string raw)
        {
            Game.PlayerPed.Kill();
            ClientHelper.Instance.PrintToClient($"You've killed yourself.", MessageType.Warning);
        }
    }
}
