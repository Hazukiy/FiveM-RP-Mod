using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModClient
{
    public class Commands
    {
        #region Singleton
        private static Commands _instance;
        public static Commands Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Commands();
                }
                return _instance;
            }
        }
        #endregion

        private Commands()
        {

        }

        // NOTE: Add new commands into here to they can be registered dynamically
        public List<CommandRegisterModel> DynamicRegister = new List<CommandRegisterModel>()
        {
            Die,
            GetLocation
        };

        public static CommandRegisterModel GetLocation = new CommandRegisterModel()
        {
            Name = "getloc",
            ActionDelegate = new Action<int, List<object>, string>((source, args, raw) => CommandActions.Instance.GetPlayerLocation(source, args, raw)),
            IsRestrictedCommand = false
        };

        public static CommandRegisterModel Die = new CommandRegisterModel() 
        { 
            Name = "die",
            ActionDelegate = new Action<int, List<object>, string>((source, args, raw) => CommandActions.Instance.Die(source, args, raw)),
            IsRestrictedCommand = false
        };
    }
}
