using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private float time = 0f;

    void Update()
    {
        this.time += Time.deltaTime;

        if (this.time > 3f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
