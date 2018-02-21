namespace AnyStatus.API
{
    internal interface IScheduler
    {
        void Schedule(Widget widget);

        void Unschedule(Widget widget);
    }
}