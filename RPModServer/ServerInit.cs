using System;
using CitizenFX.Core;

namespace RPModServer
{
    public class ServerInit : BaseScript
    {
        public ServerInit()
        {
            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
        }

        private void OnResourceStart(string resourceName)
        {
            Debug.WriteLine($"RP Mod server loaded");
        }
    }
}
