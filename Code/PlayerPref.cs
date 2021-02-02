using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPref : MonoBehaviour
{
    /* Add an empty game object to your scene with a tag "PlayerPrefs" and add this script to it. 
     The scene also has to have a working canvas with all needed objects *copy from Level-1* with volumesettings and canvascontroller scripts. */

    //we're not utilizing Unitys feature PlayerPrefs due to the game being built on WebGL and not being able to store players data locally on the players machine.


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PlayerPrefs"); //Finds all objects with a tag "PlayerPrefs" and deletes the newest one. So the settings set in this script will be saved through out the entire game.
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        if (count <= 0) //sets the audio volume on the first load.
        {
            musicVolume = 0.2f;
            sfxVolume = 0.5f;
        }
        count += 1;
        Debug.Log(musicVolume);
        Debug.Log(count);
    }
    private static int count;
    private static float musicVolume; //music volume is saved in this float throughout the whole game.
    private static float sfxVolume; //sfx volume is saved in this float throughtout the whole game.
    public static List<string> levelsCompleted = new List<string>();

    public void ChangeMusicVolume(float input) //you can change the music volume calling this.
    {
        musicVolume = input;
    }

    public void ChangeSFXVolume(float input) //you can change the sfx volume calling this.
    {
        sfxVolume = input;
    }

    public float SfxVolume() // returns the saved sfx volume float.
    {
        return sfxVolume;
    }

    public float MusicVolume()// returns the saved music volume float.
    {
        return musicVolume;
    }

    public bool CheckLevelList(string input) //returns true or false weather or not the level from the input is completed.
    {
        if (levelsCompleted.Contains(input))
            return true;
        else
            return false;
    }

    public void LevelCompleted(string input)
    {
        Debug.Log("LevelCompleted" + levelsCompleted);
        if(!levelsCompleted.Contains(input))//checks if the list already has that level completed
        levelsCompleted.Add(input);//adds the completed level to the list
    }
}
