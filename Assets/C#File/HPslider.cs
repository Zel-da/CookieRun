using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPslider : MonoBehaviour
{
    public Slider slTimer;
    float fSliderBarTime;
    GameObject obj;
    public int speed;
    public GameObject EndPanel;

    void Start()
    {
        slTimer = GetComponent<Slider>();
        obj = GameObject.Find("Player");
        speed = 1;
        //EndPanel = GameObject.Find("EndPanel");
    }

    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            //slTimer.value -= Time.deltaTime * speed;
            slTimer.value = obj.GetComponent<PlayerMove>().Hp;
        }
        else
        {
            Debug.Log("Game Over!");
            EndPanel.SetActive(true);
        }
    }
}
