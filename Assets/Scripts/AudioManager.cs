using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip bgm;

    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }
    //public void PlayVFX(AudioClip clip)
    //{
    //    VFXSource.PlayOneShot(clip);
    //}
    //public void PlayTyping(AudioClip clip)
    //{
    //    typingSource.Play();
    //}
}
