using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class ExclusiveLaserPointer : MonoBehaviour
{
    [SerializeField]
    SteamVR_LaserPointer[] Targets;

    SteamVR_Action_Boolean interactWithUI;
    int activeIndex = 0;

    void Start()
    {
        interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");
    }

    void Update()
    {
        foreach (var target in Targets.WithIndex())
        {
            if (interactWithUI.GetStateDown(target.Item1.pose.inputSource))
            {
                activeIndex = target.Item2;
                break;
            }
        }

        foreach (var target in Targets.WithIndex())
        {
            var enabled = target.Item2 == activeIndex;
            target.Item1.gameObject.SetActive(enabled);
        }
    }
}
