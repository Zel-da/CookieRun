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
    public int SlideCount;
    private Vector2 startPosition;
    public Vector2 SlidePosition;
    bool isSlide;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        JumpCount = 2;
        SlideCount = 0;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.down * 1, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if(rayHit.collider != null)
        {
            JumpCount = 2;
            anim.SetBool("isJump", false);
            anim.SetBool("isDoubleJump", false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && JumpCount == 2)
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            JumpCount = 1;
            sfx.SoundPlay5();
        }

        if (Input.GetButtonDown("Jump") && JumpCount == 1)
        {
            anim.SetBool("isDoubleJump", true);
            JumpCount = 0;
            sfx.SoundPlay5();
        }

        if (Input.GetButtonDown("Slide"))
        {
            
        }

        if (Input.GetButton("Slide"))
        {
            anim.SetBool("isSlide", true);
            transform.position = SlidePosition;
            isSlide = true;
            //gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            if (SlideCount == 0)
            {
                sfx.SoundPlay6();
            }
            SlideCount++;
        }
        else
        {
            anim.SetBool("isSlide", false);
            SlideCount = 0;
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
            

        if (Input.GetButtonUp("Slide") && isSlide == true)
        {
            transform.position = startPosition;
            isSlide = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);//충돌했을때 x축,y축 넘김
        }
    }

    //무적시간
    void OnDamaged(Vector2 targetPos)
    {
        //gameObject는 자기자신을 의미
        //충돌시 플레이어의 레이어가 PlayerDamaged 즉,3번 레이어로 변해야 
        gameObject.layer = 3;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);//무적시간일 때 플레이어가 투명하게
        sfx.SoundPlay7();

        Invoke("OffDamaged", 3);
    }

    void OffDamaged()
    {
        gameObject.layer = 0;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}