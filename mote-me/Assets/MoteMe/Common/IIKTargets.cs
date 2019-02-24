using UnityEngine;

interface IIKTargets
{
    Transform HeadTarget { get; }
    Transform LeftHandTarget { get; }
    Transform RightHandTarget { get; }
}