using UnityEngine;
using UniRx;
using UniRx.Async;
using UnityEngine.UI;
using Zenject;

public class PreparationController : MonoBehaviour
{
    [SerializeField]
    Button PlayButton;
    [Inject]
    SceneManager SceneManager;

    void Start()
    {
        PlayButton.OnClickAsObservable()
            .Subscribe(_ => GoToPlay())
            .AddTo(this);
    }

    void GoToPlay()
    {
        SceneManager.ChangeToAsync("main").Forget();
    }
}
