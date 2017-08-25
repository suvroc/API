namespace AnyStatus.API
{
    interface IScheduler
    {
        void Schedule(Plugin plugin);

        void Unschedule(Plugin plugin);
    }
}
