using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crossfade : MonoBehaviour
{
    private Animator animator;

    [Header("OPEN ANIMATION")]
    [SerializeField] private string disappearTrigger;

    [Header("EXIT ANIMATION")]
    [SerializeField] private AnimationClip appearClip;
    [SerializeField] private string appearTrigger;

    public float ExitClipLength { get => appearClip.length; }

    public void AppearCrossfade()
    {
        animator.SetTrigger(appearTrigger);
    }

    public void DisappearCrossfade()
    {
        animator.SetTrigger(disappearTrigger);
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
}
