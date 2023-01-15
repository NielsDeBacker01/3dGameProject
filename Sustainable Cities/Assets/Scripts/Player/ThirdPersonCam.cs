using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        // rotation orietation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        float horizontalIpnut = Input.GetAxis("Horizontal");
        float verticalIpnut = Input.GetAxis("Vertical");

        Vector3 inputDir = orientation.forward * verticalIpnut + orientation.right * horizontalIpnut;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
