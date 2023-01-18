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

    [Header("Enemy")]
    public float timer = 1f;
    public int damageTaken = 0;

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
        timer += Time.deltaTime;
        MovePlayer();
        Oxygen();
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

    void Oxygen(){
        timer += Time.deltaTime;
        if (Mathf.Round(timer)%3==0){
            this.hp.currentHp--;
            timer = 1f;
        }
    }

    void OnTriggerEnter(Collider hit){
        if(hit.transform.gameObject.tag.Contains("enemy")){
        this.hp.currentHp-=damageTaken;
        }
    }
}