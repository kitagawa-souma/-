using System.Collections.Generic;
using UnityEngine;

/*
 * public class SoundManager : MonoBehaviour
{
    [SerializeField, Range(0, 1), Tooltip("マスター音量")]
    float Volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGMの音量")]
    float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SEの音量")]
    float seVolume = 1;

    AudioClip[] bgm;
    AudioClip[] se;

    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();

    AudioSouce bgmAudioSouce;
    AudioSouce seAudioSouce;

    public float Volume
    {
        set
        {
            Volume = Mathf.Clamp01(value);
            bgmAudioSouce.volume = bgmVolume * Volume;
            seAudioSouce.volume = seVolume * Volume;
        }
        get
        {
            return Volume;
        }
    }

    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSouce.volme = bgmVolume * Volume;
        }
        get
        {
            return bgmVolume;
        }
    }

    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSouce.volume = seVolume * volume;
        }
        get
        {
            return seVolume;
        }
    }

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        bgmAudioSouce = gameObject.AddComponent<AudioSouce>();
        seAudioSouce = gameObject.AddComponent<AudioSouce>();

        bgm = Resouces.LoadAll<AudioClip>("Audio/BGM");
        se = Resouces.LoadAll<AudioClip>("Audio/SE");

        for (int i = 0; i < bgm.Length; i++)
        {
            bgmIndex.Add(bgm[i].name, i);
        }
        for (int i = 0; i < se.Length; i++)
        {
            seIndex.Add(se[i].name, i);
        }
    }

    public int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のBGMファイルが存在しません。");
            return 0;
        }
    }

    public int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のSEファイルが存在しません。");
            return 0;
        }
    }

    //BGM再生
    public void PlayBgm(int index)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);

        bgmAudioSouce.clip = bgm[index];
        bgmAudioSouce.loop = true;
        bgmAudioSouce.volume = BgmVolume * Volume;
        bgmAudioSouce.Play();
    }

    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    public void StopBgm()
    {
        bgmAudioSouce.Stop();
        bgmAudioSouce.clip = null;
    }

    //SE再生
    public void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, se.Length);
    }

    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    public void StopSe()
    {
        seAudioSouce.Stop();
        seAudioSouce.clip = null;
    }
}
*/