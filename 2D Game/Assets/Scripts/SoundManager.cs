using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource source;
    public AudioClip backgroundMusic;
    public List<AudioClip> allAudioClips;
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        restartBackgroundMusic();
    }

    public void PlaySoundEffect(string name)
    {
        AudioClip temp = null;
        foreach (var clip in allAudioClips)
        {
            if (clip.name == name)
            {
                temp = clip;
            }   
        }

        if (temp != null)
        {
            source.PlayOneShot(temp);
        }
        else
        {
            Debug.Log("AudioClip not found: " + name);
        }
    }

    public void restartBackgroundMusic()
    {
        source.clip = backgroundMusic;
        source.Play();
    }

    public void stopAllSounds()
    {
        source.Stop();
    }
    public void ToggleSoundActive(bool soundActive)
    {
        this.gameObject.SetActive(soundActive);
    }
}
