using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UniRx;

public class VRUIInput : MonoBehaviour
{
    [SerializeField]
    public SteamVR_LaserPointer LaserPointer;

    private void Start()
    {
        Observable.FromEvent<PointerEventHandler, PointerEventArgs>(h => (_, e) => h(e), h => LaserPointer.PointerClick += h, h => LaserPointer.PointerClick -= h)
            .Where(_ => enabled)
            .Subscribe(HandleTriggerClicked)
            .AddTo(this);

        Observable.FromEvent<PointerEventHandler, PointerEventArgs>(h => (_, e) => h(e), h => LaserPointer.PointerIn += h, h => LaserPointer.PointerIn -= h)
            .Where(_ => enabled)
            .Subscribe(HandlePointerIn)
            .AddTo(this);

        Observable.FromEvent<PointerEventHandler, PointerEventArgs>(h => (_, e) => h(e), h => LaserPointer.PointerOut += h, h => LaserPointer.PointerOut -= h)
            .Where(_ => enabled)
            .Subscribe(HandlePointerOut)
            .AddTo(this);
    }
    private void HandleTriggerClicked(PointerEventArgs e)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }
    }

    private void HandlePointerIn(PointerEventArgs e)
    {
        var selectable = e.target.GetComponent<Selectable>();
        if (selectable != null)
        {
            selectable.Select();
        }
    }

    private void HandlePointerOut(PointerEventArgs e)
    {

        var button = e.target.GetComponent<Selectable>();
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}