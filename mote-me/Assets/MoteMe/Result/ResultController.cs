using UnityEngine;
using UniRx;
using UniRx.Async;
using UnityEngine.UI;
using Zenject;

public class ResultController : MonoBehaviour
{
    [SerializeField]
    Button RetryButton;
    [SerializeField]
    Button WatchButton;
    [SerializeField]
    Button BackButton;

    [Inject]
    SceneManager SceneManager;

    void Start()
    {
        Observable.Merge(
            RetryButton.OnClickAsObservable().Select(_ => "test"),
            WatchButton.OnClickAsObservable().Select(_ => "watch"),
            BackButton.OnClickAsObservable().Select(_ => "preparation"))
        .First()
        .Select(SceneManager.ChangeToAsync)
        .Subscribe(task => task.Forget())
        .AddTo(this);
    }
}
