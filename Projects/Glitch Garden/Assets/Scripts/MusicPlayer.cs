using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    public AudioClip [] levelMusicChangeArray;
    
    private AudioSource music;

    void Awake()
    {
        if (instance != null&&instance!=this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
        }
    }
    // Use this for initialization
    void Start () {

    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);
        if (thisLevelMusic)
        {
            music.Stop();
            music.clip = thisLevelMusic;
            music.loop = true;
            music.Play();
        }
    }

}
