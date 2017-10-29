namespace AnyStatus.API
{
    public interface IReportProgress
    {
        int Progress { get; set; }

        bool ShowProgress { get; set; }

        void ResetProgress();
    }
}
