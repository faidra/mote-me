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
            RetryButton.OnClickAsObservable().Select(_ => SceneManager.SceneId.Main),
            WatchButton.OnClickAsObservable().Select(_ => SceneManager.SceneId.Watch),
            BackButton.OnClickAsObservable().Select(_ => SceneManager.SceneId.Preparation))
        .First()
        .Select(SceneManager.ChangeToAsync)
        .Subscribe(task => task.Forget())
        .AddTo(this);
    }
}
