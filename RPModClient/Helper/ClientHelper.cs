using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using RPModShared;
using static CitizenFX.Core.Native.API;

namespace RPModClient
{
    public class ClientHelper : BaseScript
    {
        #region Singleton
        private static ClientHelper _instance;
        public static ClientHelper Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientHelper();
                }
                return _instance;
            }
        }
        #endregion

        private ClientHelper()
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
