using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 1f;
    public float jumpForce = 3f;
    public bool canJump = true;
    public GameObject ballPrefab;
    public GameObject Arm;
    public Animator armAnimator;

    public Vector3 target;
    public GameObject ballSpawn;

    public float horizontal;
    
    // Start is called before the first frame update
    protected void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        armAnimator = Arm.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        /*horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("movementX", horizontal);
        armAnimator.SetFloat("movementX",horizontal);
        if (Input.GetButtonDown("Jump") && canJump) Jump();
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowBall();  
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           BatSwing(); 
        }*/
            

    }

    protected void Jump()
    {
        
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        canJump = false;
        
    }

  
    protected void BatSwing()
    {
        animator.SetTrigger("Bat");
    }

    private void FixedUpdate()
    {
        Debug.Log($"Cash : {GameManager.GetGameManager().GetSubsystem<DataSubsystem>().money}$");
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
        
        if (rb.velocity.y <= 0 && Physics2D.Raycast(transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Floor")))
        {

            canJump = true;

        }
        
    }
}
