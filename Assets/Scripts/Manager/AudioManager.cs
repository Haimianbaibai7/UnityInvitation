using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip BackgroundMusic;

    public AudioClip ClickBoy;
    public AudioClip ClickMail;
    public AudioClip OpenMail;
    public AudioClip PaperSilde;
    public AudioClip FinalPaper;




    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    public void PlayBackGroundMusic()
    {
        m_AudioSource.clip = BackgroundMusic;
        m_AudioSource.Play();
    }

    public void PlayEffectMusic(AudioClip audioClip)
    {
        m_AudioSource.PlayOneShot(audioClip);
        Debug.Log(audioClip);

    }
    
}
