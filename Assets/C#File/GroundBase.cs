using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase : MonoBehaviour
{
    public float GroundSpeed = 0;
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * GroundSpeed);

        if(transform.position.x < -11)
        {
            gameObject.SetActive(false);
        }    
    }
}
