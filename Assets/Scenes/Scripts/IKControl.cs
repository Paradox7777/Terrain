using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField]
    private bool ikActive;

    [SerializeField]
    private Transform _pointRightHand;
    
    [SerializeField]
    private Transform _pointLeftHand;

    [SerializeField]
    private Transform _pointLooks;

    [SerializeField]
    private LayerMask _rayLayer;

    [SerializeField]
    private Transform _footTransform;

    [SerializeField]
    private Vector3 _offsetFootL;

    [SerializeField]
    private Vector3 _offsetFootR;

    [SerializeField]
    private float _valueWeight;

    private static readonly int LeftLeg = Animator.StringToHash("Legt-leg");
    private static readonly int RightLeg = Animator.StringToHash("Right-leg");


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (ikActive)
        {
            if (Vector3.Distance(_pointLooks.transform.position , transform.position) < 2f)
            {
                _animator.SetLookAtWeight(1);
            }
            _animator.SetLookAtPosition(_pointLooks.position);

            if (Vector3.Distance(_pointRightHand.transform.position, transform.position) < 1.5f)
            {
                ChangeWeightAvatar(AvatarIKGoal.RightHand, 1);
            }
            
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _pointRightHand.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _pointRightHand.rotation);

            if (Vector3.Distance(_pointLeftHand.transform.position, transform.position) < 1.5f)
            {
                ChangeWeightAvatar(AvatarIKGoal.LeftHand, 1);
            }
         
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointLeftHand.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointLeftHand.rotation);

            LegsIK();
                
        }
        else
        {
            ChangeWeightAvatar(AvatarIKGoal.RightHand, 0);
            ChangeWeightAvatar(AvatarIKGoal.LeftHand, 0);
            _animator.SetLookAtWeight(0);
        }
    }

    private void LegsIK()
    {
        var weightFootL = _animator.GetFloat(LeftLeg);
        ChangeWeightAvatar(AvatarIKGoal.LeftFoot, weightFootL);
        
        var weightFootR = _animator.GetFloat(RightLeg);
        ChangeWeightAvatar(AvatarIKGoal.RightFoot, weightFootR);

        ChangePositionLeg(AvatarIKGoal.LeftFoot, _offsetFootL);
        ChangePositionLeg(AvatarIKGoal.RightFoot, _offsetFootR);
    }

    private void ChangePositionLeg(AvatarIKGoal avatarIKGoal, Vector3 offset)
    {
        var footPos = _animator.GetIKPosition(avatarIKGoal);

        if (Physics.Raycast(footPos + Vector3.up, Vector3.down, out var hit, 2.0f, _rayLayer))
        {
            _animator.SetIKPosition(avatarIKGoal, hit.point + offset);
            _animator.SetIKRotation(avatarIKGoal, Quaternion.LookRotation(Vector3.ProjectOnPlane(_footTransform.forward, hit.normal), hit.normal));
        }
    }
    private void ChangeWeightAvatar(AvatarIKGoal avatarIKGoal, float value)
    {
        _animator.SetIKPositionWeight(avatarIKGoal, value);
        _animator.SetIKRotationWeight(avatarIKGoal, value);
    }
}
