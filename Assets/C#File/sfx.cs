using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip1;
    public static AudioClip audioClip2;
    public static AudioClip audioClip3;
    public static AudioClip audioClip4;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip1 = Resources.Load<AudioClip>("g_coin");
        audioClip2 = Resources.Load<AudioClip>("g_jelly");
        audioClip3 = Resources.Load<AudioClip>("g_BigBearJelly");
        audioClip4 = Resources.Load<AudioClip>("i_large_energy");
    }

    // Update is called once per frame
    public static void SoundPlay1()
    {
        audioSource.PlayOneShot(audioClip1);
    }
    public static void SoundPlay2()
    {
        audioSource.PlayOneShot(audioClip2);
    }
    public static void SoundPlay3()
    {
        audioSource.PlayOneShot(audioClip3);
    }

    public static void SoundPlay4()
    {
        audioSource.PlayOneShot(audioClip4);
    }
}