using System;
using CitizenFX.Core;

namespace RPModServer
{
    public class ServerInit : BaseScript
    {
        public ServerInit()
        {
            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
            EventHandlers["onTestPrint"] += new Action<string>(OnTestPrint);
        }

        private void OnResourceStart(string resourceName)
        {
            Debug.WriteLine($"RP Mod server loaded");
        }

        private void OnTestPrint(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
