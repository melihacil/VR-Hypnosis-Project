using Meta.WitAi.Attributes;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum Direction
{
    X = 0,
    Y = 1,
    Z = 2
}


public class ObjectAlignment : MonoBehaviour
{

    [SerializeField]
    private bool centerEye;

    [SerializeField] [HideIf("centerEye")]
    private Transform mainTarget;

    [SerializeField]
    private bool customHeightTarget;

    [ShowIf("customHeightTarget")] [SerializeField]
    private Transform heightTarget;

    [Space]
    [SerializeField]
    private bool isDistancePosition;
    [ShowIf("isDistancePosition")]
    [SerializeField]
    private float distanceToTarget;

    [Space]
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float duration;
    [SerializeField]
    private float fixedDeltaLimit;

    [Space]
    [SerializeField]
    private bool hasZeroLimitDirection;
    [ShowIf("hasZeroLimitDirection")]
    [SerializeField]
    private Direction zeroLimitDirection;

    [ShowIf("hasZeroLimitDirection")]
    [SerializeField]
    private bool oppositeDirection;

    [Space]
    [SerializeField]
    private bool lookAtTheTarget;
    [ShowIf("lookAtTheTarget")]
    [SerializeField]
    private Transform lookAtTarget;


    private Vector3 _snappedPosition;
    private string _moveId;

    //---------------------------------------------------------------------------------
    private void Awake()
    {
        if (centerEye)
        {
            //mainTarget = Manager.Controller?.GetController<OVRReferenceController>()?.centerEye?.transform;
            if (mainTarget == null)
            {
                mainTarget = Camera.main.transform;
            }
        }
        if (heightTarget == null || customHeightTarget == false)
            heightTarget = mainTarget;
        if (lookAtTarget == null || lookAtTheTarget == false)
            lookAtTarget = mainTarget;

        _moveId = "Move" + gameObject.GetInstanceID();
    }


    //---------------------------------------------------------------------------------
    private void OnEnable()
    {
        //Move new position
        UpdatePositionImmediately();
    }


    //---------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        if (CheckIsInRange(out var isImmediately))
            return;

        //Move new position
        MovePanel(isImmediately ? 0 : duration);
    }


    //---------------------------------------------------------------------------------
    public void UpdatePosition() => MovePanel(duration);


    //---------------------------------------------------------------------------------
    public void UpdatePositionImmediately()
    {
        transform.position = GetTargetPosition();
        LookAtTheTarget();
    }


    //---------------------------------------------------------------------------------
    private bool CheckIsInRange(out bool isImmediately)
    {
        isImmediately = false;

        var targetPosition = GetTargetPosition();
        var isInRange = Mathf.Abs((_snappedPosition - targetPosition).magnitude) < fixedDeltaLimit;

        if (!isInRange || !hasZeroLimitDirection)
            return isInRange;

        var axis = (int)zeroLimitDirection;
        isInRange = _snappedPosition[axis] - offset[axis] >= targetPosition[axis];
        isInRange = oppositeDirection ? !isInRange : isInRange;

        isImmediately = !isInRange;
        return isInRange;
    }


    //---------------------------------------------------------------------------------
    private Vector3 GetTargetPosition()
    {
        var position = mainTarget.position + offset;
        position.SetY(heightTarget.position.y + offset.y);
        var direction = mainTarget.forward;

        return position + direction * (isDistancePosition ? distanceToTarget : 0);
    }


    //---------------------------------------------------------------------------------
    private void MovePanel(float duration = 0f)
    {
        var targetPosition = GetTargetPosition();

        DOTween.Kill(_moveId);
        transform.DOMove(targetPosition, duration).SetId(_moveId).OnUpdate(LookAtTheTarget);

        _snappedPosition = targetPosition;
    }


    //---------------------------------------------------------------------------------
    private void LookAtTheTarget()
    {
        if (lookAtTheTarget)
            transform.LookAt(lookAtTarget);
    }

    

}
