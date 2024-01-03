using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAudioControl : MonoBehaviour
{
    Battle_Shooter shooter;
    List<AudioSource> audioSource;

    [Header("Sfx")]
    public AudioClip[] audioClips;

    private void Awake()
    {
        shooter = GetComponent<Battle_Shooter>();
        if (shooter != null)
            Battle_Shooter.OnFireExcuted += HandlerFireExecute_Sound;
        audioSource = new List<AudioSource>();
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSource.Add(this.gameObject.AddComponent<AudioSource>());
            audioSource[i].clip = audioClips[i];
            audioSource[i].playOnAwake = false;
        }
    }
    public void HandlerFireExecute_Sound(Transform other_transform, int idx)
    {
        if (transform.CompareTag(other_transform.tag))
        {
            audioSource[idx].Play();
        }
    }

    private void OnDestroy()
    {
        Battle_Shooter.OnFireExcuted -= HandlerFireExecute_Sound;
    }

}
