using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterController : MonoBehaviour
{
    private bool isJump = false;
    private bool isSlide = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    Animator anim;
    public int JumpCount;
    Rigidbody2D rigid;
    public float JumpPower;

    private Vector2 startPosition;
    void Start()
    {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        JumpCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // spacebar 누르면
        {
            anim.SetBool("isJump", true);
            isJump = true;
            JumpCount = 1;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
        else if (transform.position.y <= startPosition.y)
        {
            isJump = false;
            anim.SetBool("isJump", false);
            JumpCount = 0;
        }

        if (transform.position.y <= jumpHeight - 0.1f && JumpCount == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // spacebar 누르면
            {
                anim.SetBool("isDoubleJump", true);
                isJump = false;
                JumpCount = 0;
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }

        if (Input.GetButton("Slide"))
        {
            anim.SetBool("isSlide", true);
        }
        else
        {
            anim.SetBool("isSlide", false);
            transform.position = startPosition;
        }
    }
}