using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudioControl : MonoBehaviour
{
    public AudioClip[] BossSfx;

    public static BossAudioControl instance;

    public AudioSource BossAudioSource;

    void start()
    {
        BossAudioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void SoundGenerator(int index)
    {
        BossAudioSource.clip = BossSfx[index];
        BossAudioSource.Play();
    }
}
