using Zenject;
using System;
using UniRx;

public class LongPressManager
{
    readonly IObservable<Unit> longPressTimer;

    public LongPressManager(
        [Inject(Id = "LongPressDuration")]float longPressDuration)
    {
        longPressTimer = Observable.Timer(TimeSpan.FromSeconds(longPressDuration)).AsUnitObservable();
    }

    public IObservable<Unit> LongPressAsObservable(Func<bool> condition)
    {
        return Observable.EveryUpdate()
            .Select(_ => condition())
            .DistinctUntilChanged()
            .Select(satisfied => satisfied ? longPressTimer : Observable.Empty<Unit>())
            .Switch();
    }
}
