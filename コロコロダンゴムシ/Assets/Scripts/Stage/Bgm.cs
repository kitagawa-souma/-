using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    private AudioSource audioSource;

    void start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //スコアが1000になると音量が下がる
        //if(スコア >= 1000;)
        if(Input.GetKey(KeyCode.Space) == true)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
            /*
            audioSource.volume -= 0.1f;
            if(audioSource.volume <= 0.0f)
            {
                audioSource.clip = audioClip2;
                audioSource.Stop(audioClip1);
            }
            if(audioSouce.clip == audioClip2)
            {
                audioource.Play(audioClip2);
                if(audioSource.volume < 1.0f)
                {
                    audioSource.volume += 0.1f;
                }
            }*/
        }
    }
}
