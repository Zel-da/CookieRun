using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.coinAmount += 1000;
            Destroy(gameObject);
            sfx.SoundPlay2();
        }

    }
}
