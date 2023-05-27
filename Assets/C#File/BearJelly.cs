using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.coinAmount += 5000;
            Destroy(gameObject);
            sfx.SoundPlay3();
        }

    }
}