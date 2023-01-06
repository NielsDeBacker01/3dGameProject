using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    // public vars
    public bool controlableCamera = true;
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


    void Awake()
    {
        if(controlableCamera)
        {
            Screen.lockCursor = true;
        }
        cameraTransform = Camera.main.transform;
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
        else
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                gameObject.transform.LookAt(hit.point);
            }
        }

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

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

        Rigidbody rb = GetComponent<Rigidbody>();

        Ray ray = new Ray(rb.position, localMove);
        RaycastHit hit;
        if (!Physics.Raycast(ray,out hit,localMove.magnitude))
        {
            rb.MovePosition(localMove + rb.position);
        }
        else
            rb.MovePosition(hit.point);
    }
}