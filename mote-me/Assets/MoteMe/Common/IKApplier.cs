using UnityEngine;
using RootMotion.FinalIK;
using Zenject;

public class IKApplier
{
    [Inject]
    IIKTargets IKTarget;

    const float footDistance = 0.1f;

    public void Apply(GameObject avatarModel)
    {
        var vrIK = avatarModel.AddComponent<VRIK>();
        vrIK.AutoDetectReferences();

        vrIK.solver.leftArm.stretchCurve = new AnimationCurve();
        vrIK.solver.rightArm.stretchCurve = new AnimationCurve();

        var firstPerson = avatarModel.GetComponent<VRM.VRMFirstPerson>();
        vrIK.references.head = firstPerson.FirstPersonBone;
        vrIK.solver.spine.headTarget = CreateWithOffset(IKTarget.HeadTarget, -firstPerson.FirstPersonOffset, Quaternion.identity);
        vrIK.solver.leftArm.target = CreateWithOffset(IKTarget.LeftHandTarget, Vector3.zero, new Quaternion(0f, 1f, 0f, 1f));
        vrIK.solver.rightArm.target = CreateWithOffset(IKTarget.RightHandTarget, Vector3.zero, new Quaternion(0f, -1f, 0f, 1f));

        vrIK.solver.locomotion.footDistance = footDistance;
    }

    Transform CreateWithOffset(Transform target, Vector3 offsetPosition, Quaternion offsetRotation)
    {
        var offset = new GameObject("offset").transform;
        offset.SetParent(target, false);
        offset.localPosition = offsetPosition;
        offset.localRotation = offsetRotation;
        return offset;
    }
}