using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;

namespace RPModClient
{
    public class HudInit : BaseScript
    {
        private const int _topHudHeight = 600;
        private const int _width = 230;
        private const float _hudSize = 0.33f;

        public HudInit()
        {
            Tick += HudTick;
        }

        private async Task HudTick()
        {
            if(Game.Player.IsPlaying && PlayerConstants.PlayerProfile != null)
            {
                try
                {
                    // Constrcut text
                    var wallet = new Text($"Wallet: ${PlayerConstants.PlayerProfile.Wallet}", new PointF(_width, _topHudHeight), _hudSize);
                    var bank = new Text($"Bank: ${PlayerConstants.PlayerProfile.Bank}", new PointF(_width, _topHudHeight + 13), _hudSize);
                    var debt = new Text($"Debt: ${PlayerConstants.PlayerProfile.Debt}", new PointF(_width, _topHudHeight + 26), _hudSize);
                    var job = new Text($"Job: {PlayerConstants.CurrentJob.Name}", new PointF(_width, _topHudHeight + 39), _hudSize);
                    var salary = new Text($"Salary: ${PlayerConstants.CurrentJob.BaseSalary}", new PointF(_width, _topHudHeight + 52), _hudSize);
                    var salaryIn = new Text($"Salary In: {PlayerConstants.NextSalary}", new PointF(_width, _topHudHeight + 65), _hudSize);

                    // Set colours
                    wallet.Color = Color.FromArgb(255, 221, 81);
                    bank.Color = Color.FromArgb(255, 221, 81);
                    debt.Color = Color.FromArgb(255, 221, 81);
                    job.Color = Color.FromArgb(255, 221, 81);
                    salary.Color = Color.FromArgb(255, 221, 81);
                    salaryIn.Color = Color.FromArgb(255, 221, 81);

                    wallet.Draw();
                    bank.Draw();
                    debt.Draw();
                    job.Draw();
                    salary.Draw();
                    salaryIn.Draw();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine($"Exception HudTick: {ex}");
                }
            }
        }
    }
}
