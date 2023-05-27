using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField]
    Button jumpButton;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            anim.SetBool("JumpON", true);
        }
        else
        {
            anim.SetBool("JumpON", false);
        }
    }
}
