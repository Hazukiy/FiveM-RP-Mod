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
    public class Helper : BaseScript
    {
        #region Singleton
        private static Helper _instance;
        public static Helper Instance
        {
            get
            {
                if(_instance == null)
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

        public void PrintToClient(string message, MessageType type = MessageType.Normal)
        {
            var color = GetMessageColour(type);
            TriggerEvent("chat:addMessage", new
            {
                color = color,
                args = new[] { Constants.ChatPrefix, message }
            });
        }

        private int[] GetMessageColour(MessageType type)
        {
            switch(type)
            {
                case MessageType.Normal:
                default:
                    return new[] { 255, 233, 51 }; //Yellow
                case MessageType.Warning:
                    return new[] { 255, 125, 51 }; //Orange
                case MessageType.Danger:
                    return new[] { 255, 22, 22 }; //Red
                case MessageType.Information:
                    return new[] { 22, 184, 255 }; //Blue
            }
        }
    }
}
