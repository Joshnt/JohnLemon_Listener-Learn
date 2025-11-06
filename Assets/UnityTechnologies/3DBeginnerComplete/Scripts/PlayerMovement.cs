using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    [SerializeField] private FMODUnity.StudioEventEmitter walkLoop;
    [SerializeField] private FMODUnity.StudioEventEmitter idleLoop;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if (isWalking) {
            if (!walkLoop.IsPlaying()) {walkLoop.Play();}
            if (idleLoop.IsPlaying()) {idleLoop.Stop();}
        }else{
            if (!idleLoop.IsPlaying()) {idleLoop.Play();}
            if (walkLoop.IsPlaying()) {walkLoop.Stop();}
        }
        m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    void OnDestroy()
    {
        if (walkLoop != null && walkLoop.IsPlaying()) {
            walkLoop.Stop();
        }
        if (idleLoop != null && idleLoop.IsPlaying()) {
            idleLoop.Stop();
        }
    }

}