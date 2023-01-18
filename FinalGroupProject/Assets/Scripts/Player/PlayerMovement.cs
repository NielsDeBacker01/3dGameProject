using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    HealthManager hp;

    [Header("Movement")]
    public float moveSpeed;
    public float swimForce;
    public float swimCooldown;
    public float swimMultiplier;
    bool readyToSwim;

    [Header("Keybinds")]
    public KeyCode swimKey = KeyCode.Space;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        hp = this.GetComponent(typeof(HealthManager)) as HealthManager;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToSwim = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to swim
        if(Input.GetKey(swimKey) && readyToSwim)
        {
            readyToSwim = false;
            Swim();
            Invoke(nameof(ResetSwim), swimCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f * swimMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Swim()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * swimForce, ForceMode.Impulse);
    }
    private void ResetSwim()
    {
        readyToSwim = true;
    }

    void OnTriggerEnter(Collider hit){
    if(hit.transform.gameObject.tag.Contains("boss")){
        this.hp.currentHp--;
        Destroy(hit.gameObject);
        }
    }
}