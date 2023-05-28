using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    Vector3 position;
    GameObject obj;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        obj = GameObject.Find("Player");
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        position.x -= 7 * Time.deltaTime * speed;
        transform.position = position;

        if (obj.GetComponent<PlayerMove>().Hp < 0)
        {
            speed = 0;
        }

    }
}