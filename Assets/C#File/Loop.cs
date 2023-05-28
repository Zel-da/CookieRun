using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float speed = 3f;
    [SerializeField] float posValue;

    GameObject obj;
  
    Vector2 startPos;
    float newPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;

        if (obj.GetComponent<PlayerMove>().Hp < 0)
        {
            speed = 0;
        }
    }
}
