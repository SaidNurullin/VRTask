using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LeverManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string isAnimationActiveParameter;
    [SerializeField] private Transform lever;
    [SerializeField] private Vector3 leverOffAngle;
    [SerializeField] private Vector3 leverOffPosition;
    [SerializeField] private Vector3 leverOnAngle;
    [SerializeField] private Vector3 leverOnPosition;
    [SerializeField] private XRSimpleInteractable simpleInteractable;

    private bool isAnimationActive = false;

    private bool isActive = false;

    private void Start()
    {
        lever.localEulerAngles = leverOffAngle;
        simpleInteractable.activated.AddListener(ChangeState);
    }

    private void ChangeState(ActivateEventArgs arg0)
    {
        if (!isActive) return;
        isAnimationActive = !isAnimationActive;
        animator.SetBool(isAnimationActiveParameter, isAnimationActive);

        if (isAnimationActive)
        {
            lever.localEulerAngles = leverOnAngle;
            lever.localPosition = leverOnPosition;
        }
        else
        {
            lever.localEulerAngles = leverOffAngle;
            lever.localPosition = leverOffPosition;
        }
    }

    public void Activate()
    {
        isActive = true;
    }
}
