namespace AnyStatus.API
{
    interface IScheduler
    {
        void Schedule(Widget widget);

        void Unschedule(Widget widget);
    }
}
