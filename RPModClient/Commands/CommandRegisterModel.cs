using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModClient
{
    public class CommandRegisterModel
    {
        public string Name { get; set; }

        public Action<int, List<object>, string> ActionDelegate { get; set; }

        public bool IsRestrictedCommand { get; set; }
    }
}
