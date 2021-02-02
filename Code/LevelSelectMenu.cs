using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    private PlayerPref playerPreferances;
    private MainMenu mainMenuController;
    private Button levelonebtn, leveltwobtn, levelthreebtn, levelfourbtn, levelfivebtn, levelsixbtn;
    private int levelCount;

    // Start is called before the first frame update
    void Start()
    {
        playerPreferances = (PlayerPref)GameObject.FindGameObjectWithTag("PlayerPrefs").GetComponent<PlayerPref>();
        mainMenuController = (MainMenu)GameObject.Find("MenuController").GetComponent<MainMenu>();

        levelonebtn = (Button)GameObject.Find("Level-1").GetComponent<Button>();
        leveltwobtn = (Button)GameObject.Find("Level-2").GetComponent<Button>();
        levelthreebtn = (Button)GameObject.Find("Level-3").GetComponent<Button>();
        levelfourbtn = (Button)GameObject.Find("Level-4").GetComponent<Button>();
        levelfivebtn = (Button)GameObject.Find("Level-5").GetComponent<Button>();
        levelsixbtn = (Button)GameObject.Find("Level-6").GetComponent<Button>();

        levelonebtn.onClick.AddListener(() =>mainMenuController.LevelSwap("Level-1"));
        leveltwobtn.onClick.AddListener(() => mainMenuController.LevelSwap("Level-2"));
        levelthreebtn.onClick.AddListener(() => mainMenuController.LevelSwap("Level-3"));
        levelfourbtn.onClick.AddListener(() => mainMenuController.LevelSwap("Level-4"));
        levelfivebtn.onClick.AddListener(() => mainMenuController.LevelSwap("Level-6"));
        levelsixbtn.onClick.AddListener(() => mainMenuController.LevelSwap("Level-7"));

        levelonebtn.interactable = false;
        leveltwobtn.interactable = false;
        levelthreebtn.interactable = false;
        levelfourbtn.interactable = false;
        levelfivebtn.interactable = false;
        levelsixbtn.interactable = false;

        //levelCount = playerPreferances.ReturnLevelsCompleted();

        UnlockButtons();
    }



    void UnlockButtons() //unlocks the buttons according to the if statements in this method
    {
        if(playerPreferances.CheckLevelList("Level-1"))//calls to playerpreferences if this level is found from the completed levels list.
        {
            levelonebtn.interactable = true; //Makes the button interactable
            DisableLock(levelonebtn); //disables the lock image on MainMenu.cs
        }
        if (playerPreferances.CheckLevelList("Level-2"))
        {
            leveltwobtn.interactable = true;
            DisableLock(leveltwobtn);
        }
        if (playerPreferances.CheckLevelList("Level-3"))
        {
            levelthreebtn.interactable = true;
            DisableLock(levelthreebtn);
        }
        if (playerPreferances.CheckLevelList("Level-4"))
        {
            levelfourbtn.interactable = true;
            DisableLock(levelfourbtn);
        }
        if (playerPreferances.CheckLevelList("Level-6"))
        {
            levelfivebtn.interactable = true;
            DisableLock(levelfivebtn);
        }
        if (playerPreferances.CheckLevelList("Level-7"))
        {
            levelsixbtn.interactable = true;
            DisableLock(levelsixbtn);
        }
    }

    void DisableLock(Button button) //gets the Locked object from the button and disables it.
    {
        button.transform.GetChild(1).gameObject.SetActive(false);
    }

}
