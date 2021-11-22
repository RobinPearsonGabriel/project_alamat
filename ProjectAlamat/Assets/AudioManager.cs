using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip bgm;
    public AudioClip initialMusic;
    public AudioClip secondMusic;
    public bool multipleInitialMusic;

    public static AudioManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicLevel", musicSource.volume);
        soundSource.volume = PlayerPrefs.GetFloat("SoundLevel", soundSource.volume);

        if (initialMusic != null)
        {
            musicSource.clip = initialMusic;
            musicSource.Play();
            Invoke("ChangeMusic", musicSource.clip.length-0.195f);
        }
        else
        {
            ChangeMusic();
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void ChangeSoundVolume(float volume)
    {
        soundSource.volume = volume;
    }

    public void ChangeMusic()
    {
        if (secondMusic != null && multipleInitialMusic==true)
        {
            musicSource.clip = secondMusic;
            musicSource.PlayDelayed(0.01f);
            multipleInitialMusic = false;
            Invoke("ChangeMusic", musicSource.clip.length);
        }
        else
        {
            musicSource.clip = bgm;
            musicSource.PlayDelayed(0.01f);
            musicSource.loop = true;
        }
    }

    public void PlayAudioClip(AudioClip clipToPlay)
    {
        soundSource.clip = clipToPlay;
        soundSource.Play();
    }



}
