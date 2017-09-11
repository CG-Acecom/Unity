using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider,difficultySlider;
    public LevelManager levelManager;

    private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
        musicPlayer.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
