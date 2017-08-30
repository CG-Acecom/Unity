using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip endClip;
    public AudioClip gameClip;

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
            GameObject.DontDestroyOnLoad(gameObject);
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
        Debug.Log("MusicPlayer: loaded level " + scene.buildIndex);
        music.Stop();
        switch (scene.buildIndex)
        {
            case 0:
                music.clip = startClip;
                break;
            case 1:
                music.clip = gameClip;
                break;
            case 2:
                music.clip = endClip;
                break;
            default: break;
        }
        music.loop = true;
        music.Play();
    }

}
