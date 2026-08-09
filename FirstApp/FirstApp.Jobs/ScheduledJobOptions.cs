namespace FirstApp.Jobs;

public sealed class ScheduledJobOptions
{
    public const string SectionName = "ScheduledJobs";

    public int IntervalSeconds { get; set; } = 60;
}
