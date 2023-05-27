using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x -= 7 * Time.deltaTime;
        transform.position = position;

        if (position.x < 14 || position.x > -14)
        {
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);

    }
}