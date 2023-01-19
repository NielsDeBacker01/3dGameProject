using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MouseTracker))]
public class FirstPersonController : MonoBehaviour
{

    // public vars
    public bool controlableCamera = true;
    public bool hardStop = false;
    public float mouseSensitivityX = 250;
    public float mouseSensitivityY = 250;
    public float walkSpeed = 6;
    public float jumpForce = 220;
    public LayerMask groundedMask;

    // System vars
    bool grounded;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Transform cameraTransform;
    Vector3 moveDir;
    RaycastHit hit;
    MouseTracker mouse;
    Rigidbody rb;
    Animator animator;


    void Awake()
    {
        if(controlableCamera)
        {
            Screen.lockCursor = true;
        }
        else
        {
            mouse = this.GetComponent(typeof(MouseTracker)) as MouseTracker;
        }
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        animator = this.GetComponentInChildren<Animator>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        RaycastHit hit;
        // Look rotation:
        if(controlableCamera){
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime); 
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if(hardStop){
            if(inputX == 0 && inputY == 0)
            {
                rb.velocity = Vector3.zero;
            }
        }

        moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
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
        Vector3 localMove = controlableCamera ? transform.TransformDirection(moveAmount) : moveAmount;
        localMove *= Time.fixedDeltaTime;

        Ray ray = new Ray(rb.position, localMove);
        RaycastHit hit;
        if (!Physics.Raycast(ray,out hit,localMove.magnitude))
        {
            rb.MovePosition(localMove + rb.position);
        }
        else
        {
            rb.MovePosition(hit.point);
        }
        
        if(!controlableCamera){
            Quaternion rotation = gameObject.transform.rotation;
            Quaternion old = new Quaternion(rotation.x, 0, rotation.z, rotation.w);
            gameObject.transform.LookAt(mouse.GetMouse());
            rotation = gameObject.transform.rotation;
            gameObject.transform.rotation = new Quaternion(old.x, rotation.y, old.z, rotation.w);
        }

        //animationCheck
        if (localMove.x != 0 || localMove.z != 0) animator.SetBool("Run", true);
        if ((localMove.z <.05 && localMove.x <.05)&& (localMove.z > -.05 && localMove.x >- .05)) animator.SetBool("Run", false);
    }
}