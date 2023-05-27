using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.coinAmount += 100;
            Destroy(gameObject);
            sfx.SoundPlay1();
        }

    }
}
