using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class PlayerAnimController : MonoBehaviour
{
    
    
    public AudioClip footstepPlayer;
    public AudioClip damageTaken;
    public AudioClip deathSound;
    
    
    protected AnimatorStateInfo m_CurrentStateInfo;    // Information about the base layer of the animator cached.
    protected AnimatorStateInfo m_NextStateInfo;
    protected bool m_IsAnimatorTransitioning;
    protected AnimatorStateInfo m_PreviousCurrentStateInfo;    // Information about the base layer of the animator from last frame.
    protected AnimatorStateInfo m_PreviousNextStateInfo;
    protected bool m_PreviousIsAnimatorTransitioning;
    
    
    readonly int m_HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
    readonly int m_HashAngleDeltaRad = Animator.StringToHash("AngleDeltaRad");
    readonly int m_HashTimeoutToIdle = Animator.StringToHash("TimeoutToIdle");
    readonly int m_HashDeath = Animator.StringToHash("Death");
    
    
    
    readonly int m_HashEllenDeath = Animator.StringToHash("Death");
    readonly int m_HashLocomotion = Animator.StringToHash("Locomotion");
    readonly int m_Rifle1 = Animator.StringToHash("Rifle");
    readonly int m_Pistol = Animator.StringToHash("Pistol");
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
