using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;

namespace RPModClient.Hud
{
    public class HudInit : BaseScript
    {
        private const int _topHudHeight = 520;
        private const float _hudSize = 0.3f;

        public HudInit()
        {
            Tick += HudTick;
        }

        private async Task HudTick()
        {
            // TODO: Make this better
            var walletText = new Text($"Wallet: ${PlayerConstants.PlayerProfile.Wallet}", new PointF(20, _topHudHeight), _hudSize);
            var bankText = new Text($"Bank: ${PlayerConstants.PlayerProfile.Bank}", new PointF(20, _topHudHeight + 10), _hudSize);
            var debtText = new Text($"Debt: ${PlayerConstants.PlayerProfile.Debt}", new PointF(20, _topHudHeight + 20), _hudSize);
            var salaryText = new Text($"Salary: ${PlayerConstants.PlayerProfile.Salary}", new PointF(20, _topHudHeight + 30), _hudSize);
            var nextSalaryText = new Text($"Salary in: {PlayerConstants.NextSalary} seconds", new PointF(20, _topHudHeight + 40), _hudSize);
            nextSalaryText.Color = Color.FromArgb(255, 0, 0);

            walletText.Draw();
            bankText.Draw();
            debtText.Draw();
            salaryText.Draw();
            nextSalaryText.Draw();
        }
    }
}
