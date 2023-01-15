using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInputController : MonoBehaviour
{

    // public vars
    public float walkSpeed = 6;
    public float jumpForce = 220;
    public LayerMask groundedMask;
    public Transform body;
    Animator animation;

    // System vars
    bool grounded;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animation = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up *100* jumpForce);
            }
        }

        // Grounded check

        if (Physics.CheckSphere(body.position,0.1f,groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + localMove);
        if (localMove.x != 0 || localMove.z != 0) animation.SetBool("run", true);
        if (localMove.z == 0 && localMove.x == 0) animation.SetBool("run", false);

    }
}

