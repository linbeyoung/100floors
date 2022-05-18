using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    float xVelocity;

    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;

    public bool isOnGround;

    bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);

        anim.SetBool("isOnGround", isOnGround);
        Movement();


    }



    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));  // 实现了跑动的动画
        if (xVelocity != 0)
        {
            // transform.localScale = new Vector3(Mathf.Sign(xVelocity), 1, 1);  // 实现翻转
            transform.localScale = new Vector3(xVelocity, 1, 1);  // 实现翻转

        }

    }


    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        // if (other.gameObject.tag == "Spike") {
        if (other.CompareTag("Spike")) {
            anim.SetTrigger("dead");
        }

    }
    //检测视线可以看得见,检测OverlapCircle的覆盖范围

    public void PlayerDead()
    {
        playerDead = true;
        GameManager.GameOver(playerDead);
    }

    // 可以用来检查射线颜色
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);  
    }
}
