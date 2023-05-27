using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float JumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public int JumpCount;
    private Vector2 startPosition;
    public Vector2 SlidePosition;
    bool isSlide;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        JumpCount = 2;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 2, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if(rayHit.collider != null)
        {
            JumpCount = 2;  
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && JumpCount == 2)
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            JumpCount = 1;
        }
        else
        {
            anim.SetBool("isJump", false);
        }

        if (Input.GetButtonDown("Jump") && JumpCount == 1)
        {
            anim.SetBool("isDoubleJump", true);
            JumpCount = 0;
        }
        else
            anim.SetBool("isDoubleJump", false);
        
        if (Input.GetButton("Slide"))
        {
            anim.SetBool("isSlide", true);
            transform.position = SlidePosition;
            isSlide = true;
        }
        else
            anim.SetBool("isSlide", false);

        if (Input.GetButtonUp("Slide") && isSlide == true)
        {
            transform.position = startPosition;
            isSlide = false;
        }
    }

    public void Jump()
    {

    }
}