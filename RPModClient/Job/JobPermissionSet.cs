using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPModClient.Job
{
    public enum JobPermissionSet
    {
        None = 0, // No special permission
        CanAccessFire, // Can access fire services and fire cars
        CanAccessEMS, // Can access EMS services and EMS cars
        CanAccessPD, // Can access PD and police cars
        CanAccessMayor // Basically all below
    }
}
