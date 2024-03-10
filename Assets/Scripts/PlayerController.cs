using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float gravity = 9.81f;

    private float _fallVelocity = 0f;

    private CharacterController _characterController;

    public float jumpForce;

    public float speed;

    private Vector3 _moveVector;
    public Animator AnimatorController;
    

    void Update ()
    {
        // Movement
        Movement();
        // Jump
        JumpUpdate();
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);


        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    void Movement() {
        _moveVector = Vector3.zero;
        var RunDir = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            RunDir = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            RunDir = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            RunDir = 4;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            RunDir = 3;
        }

        AnimatorController.SetInteger("RunInteger", RunDir);
    }
    void JumpUpdate() {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
}
