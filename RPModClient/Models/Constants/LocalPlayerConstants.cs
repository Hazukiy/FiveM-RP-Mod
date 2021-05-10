using RPModClient.Job;
using RPModShared;

namespace RPModClient
{
    public static class LocalPlayerConstants
    {
        public static PlayerDataModel PlayerProfile { get; set; }

        public static JobsModel CurrentJob { get; set; } = Jobs.Unemployed;

        public static int NextSalary { get; set; } = 60; // Every 60 seconds, same for every job
    }
}
