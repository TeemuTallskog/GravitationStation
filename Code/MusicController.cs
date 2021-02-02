using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    //if you switch music between scenes you need to have different tags on the songs. Use tags "Music-1" and "Music-2". if Music-1 is playing and you switch songs on level-2 you put destroy on scene to level-2 and on level 2 you choose music 2 as a tag.
    [SerializeField] private string destroyOnScene; //here you put the scene where you want the current song to end on.
    [SerializeField] private bool isThisMainMenu;
    void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag(gameObject.tag); //Finds all objects with a same tag and deletes the newest one. So the settings set in this script will be saved through out the entire game.
        if (musicObjects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (!isThisMainMenu && SceneManager.GetActiveScene().name == "MainMenu") //destroys Main menu music object if you use the level selector to hop into different levels.
            Destroy(this.gameObject);
        if (isThisMainMenu && SceneManager.GetActiveScene().name != "MainMenu")
            Destroy(this.gameObject);
        if (SceneManager.GetActiveScene().name == destroyOnScene) //if the current scene is what you selected this object will be destroyed.
            Destroy(this.gameObject);
    }
}

