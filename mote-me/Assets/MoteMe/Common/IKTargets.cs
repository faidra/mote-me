using UnityEngine;

public class IKTargets : MonoBehaviour, IIKTargets
{
    [SerializeField]
    Transform HeadTarget;
    [SerializeField]
    Transform LeftHandTarget;
    [SerializeField]
    Transform RightHandTarget;

    Transform IIKTargets.HeadTarget => HeadTarget;
    Transform IIKTargets.LeftHandTarget => LeftHandTarget;
    Transform IIKTargets.RightHandTarget => RightHandTarget;
}
