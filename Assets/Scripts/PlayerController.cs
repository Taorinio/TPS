using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float fallVelocity = 1f;
    public float jumpForce = 6.5f;
    public float speed = 1f;
    CharacterController CharCont;
    Vector3 moveVector;

    void Start()
    {
        CharCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = transform.forward * Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime + transform.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime + Vector3.down * fallVelocity * Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && CharCont.isGrounded) {
            fallVelocity = -jumpForce;
        }
    }

    void FixedUpdate()
    {
        fallVelocity += CharCont.isGrounded ? 0 : 9.81f * Time.fixedDeltaTime;
        CharCont.Move(moveVector);
    }
}
