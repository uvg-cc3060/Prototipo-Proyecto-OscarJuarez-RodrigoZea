using UnityEngine;
using System.Collections;

public class IKHandler : MonoBehaviour {

    Animator anim;
    Vector3 lookPos;
    Vector3 IK_lookPos;
    Vector3 targetPos;
    PlayerControl pl;

    public float lerpRate = 15;
    public float updateLookPosThreshold = 2;
    public float lookWeight = 1;
    public float bodyWeight = .9f;
    public float headWeight = 1;
    public float clampWeight = 1;

    public float rightHandWeight = 1;
    public float leftHandWeight = 1;

    public Transform rightHandTarget;
    public Transform rightElbowTarget;
    public Transform leftHandTarget;
    public Transform leftEblowTarget;

    void Start()
    {
        this.anim = GetComponent<Animator>();
        pl = GetComponent<PlayerControl>();
    }

    void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);

        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);

        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);

        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);

        anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, rightHandWeight);
        anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, leftHandWeight);

        anim.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowTarget.position);
        anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftEblowTarget.position);


        this.lookPos = pl.lookPos;
        lookPos.z = transform.position.z;

        float distanceFromPlayer = Vector3.Distance(lookPos, transform.position);

        if (distanceFromPlayer > updateLookPosThreshold)
        {
            targetPos = lookPos;
        }

        IK_lookPos = Vector3.Lerp(IK_lookPos, targetPos, Time.deltaTime * lerpRate);

        anim.SetLookAtWeight(lookWeight, bodyWeight, headWeight, headWeight, clampWeight);
        anim.SetLookAtPosition(IK_lookPos);

        
    }
}
