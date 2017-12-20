using System;

namespace UniRx
{
    public interface IScheduler
    {
        //TODO Byron 2017.12.20 有什么用?
        DateTimeOffset Now { get; }

        // Interface is changed from official Rx for avoid iOS AOT problem (state is dangerous).

        IDisposable Schedule(Action action);

        IDisposable Schedule(TimeSpan dueTime, Action action);
    }

    public interface ISchedulerPeriodic
    {
        IDisposable SchedulePeriodic(TimeSpan period, Action action);
    }

    public interface ISchedulerLongRunning
    {
        IDisposable ScheduleLongRunning(Action<ICancelable> action);
    }

    //TODO Byron 2017.12.20 做什么?
    public interface ISchedulerQueueing
    {
        void ScheduleQueueing<T>(ICancelable cancel, T state, Action<T> action);
    }
}