using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    //Add this script to your canvas. Your scene needs to have an empty object with the tag "PlayerPrefs" with a playerpref.cs script attached to it.
    // You need to link the music and sfx slider, background music and sound controller Audio sources and the MusicText and SFXText Text Meshes to this script

    [SerializeField]  private Slider musicSlider;
    [SerializeField]  private Slider sfxSlider;
    private AudioSource musicSource;
    [SerializeField] private string musicTagOnThisScene; //here you input the tag of the music played on that scene
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI sfxVolumeText;
    private PlayerPref playerPref;
    private float musicVolume, sfxVolume;
    
    void Start()
    {
        musicSource = (AudioSource)GameObject.FindGameObjectWithTag(musicTagOnThisScene).GetComponent<AudioSource>();
        playerPref = (PlayerPref)GameObject.FindGameObjectWithTag("PlayerPrefs").GetComponent<PlayerPref>();
        musicVolume = playerPref.MusicVolume(); //on start makes the music volume to the one saved in playerpref.cs
        sfxVolume = playerPref.SfxVolume(); //on start makes the sfx volume to the one saved in playerpref.cs
        musicSlider.value = musicVolume; // Corrects the music slider value to the same as music volume.
        sfxSlider.value = sfxVolume; //Corrects the sfx slider value to the same as sfx volume.
    }

    void Update()
    {
        SoundVolume();
    }

    void SoundVolume()
    {
        playerPref.ChangeMusicVolume(musicSlider.value); // Changes the saved music volume float in playerpref.cs to the one on the slider.
        playerPref.ChangeSFXVolume(sfxSlider.value); // Changes the saved sfx volume float in playerpref.cs to the one on the slider.
        musicSource.volume = musicSlider.value; //changes the background music volume to sliders float value.
        sfxSource.volume = sfxSlider.value; //changes the sfx volume to sliders float value.
        sfxVolumeText.text = (Mathf.RoundToInt(sfxSlider.value * 100)).ToString(); //Makes the visible number in the menu 1-100 instead of 0.0001 - 1.
        musicVolumeText.text = (Mathf.RoundToInt(musicSlider.value * 100)).ToString(); //Makes the visible number in the menu 1-100 instead of 0.0001 - 1.
    }
}
