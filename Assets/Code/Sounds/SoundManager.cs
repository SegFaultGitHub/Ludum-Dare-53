using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [HideInInspector] public float volume;
    [SerializeField] private AudioSource _musicSource, _effetSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(_musicSource.clip);
    }


    public void PlaySound(AudioClip clip)
    {
        _effetSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.Log("ERROR : No music clip found");
            return;
        }
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void ChangeMasterVolume(float value)
    {
        volume = value;
        AudioListener.volume = volume;
    }

}
