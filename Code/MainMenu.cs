using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button newGameButton, settingsButton, settingsBackButton, creditsButton, creditsBackBTN, exitGameButton,
        levelSelectButton, exitLevelSelectBTN;

    private GameObject settingsObject, creditsObject, mainMenuButtons, levelSelectObject;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectObject = (GameObject)GameObject.Find("LevelSelectWindow");
        mainMenuButtons = (GameObject)GameObject.Find("MainMenuButtons");
        newGameButton = (Button)GameObject.Find("NewGame_Button").GetComponent<Button>();
        settingsButton = (Button)GameObject.Find("SettingsButton").GetComponent<Button>();
        settingsObject = (GameObject)GameObject.Find("Settings");
        creditsObject = (GameObject)GameObject.Find("Credits");
        settingsBackButton = (Button)GameObject.Find("BackButton").GetComponent<Button>();
        creditsButton = (Button)GameObject.Find("Credits Button").GetComponent<Button>();
        creditsBackBTN = (Button)GameObject.Find("CreditsBackButton").GetComponent<Button>();
        exitGameButton = (Button)GameObject.Find("ExitGameButton").GetComponent<Button>();
        levelSelectButton = (Button)GameObject.Find("LevelSelectButton").GetComponent<Button>();
        exitLevelSelectBTN = (Button)GameObject.Find("ExitLevelSelectBTN").GetComponent < Button>();

        exitLevelSelectBTN.onClick.AddListener(() => HideLevelSelect());
        newGameButton.onClick.AddListener(() => LevelSwap("StoryScene1")); // will switch to Scene "Level-1"
        settingsButton.onClick.AddListener(() => ShowSettings());
        settingsBackButton.onClick.AddListener(() => HideSettings());
        creditsBackBTN.onClick.AddListener(() => HideCredits());
        creditsButton.onClick.AddListener(() => ShowCredits());
        exitGameButton.onClick.AddListener(() => ExitGame());
        levelSelectButton.onClick.AddListener(() => ShowLevelSelect());
        settingsObject.SetActive(false);
        creditsObject.SetActive(false);
        levelSelectObject.SetActive(false);
    }

    public void LevelSwap(string level) //Call this function with a scene name and it will switch to that scene
    {
        SceneManager.LoadScene(sceneName: level);
    }

    void HideMainMenu() // Hides main menu
    {
        mainMenuButtons.SetActive(false);
    }

    void ShowMainMenu() // shows main menu.
    {
        mainMenuButtons.SetActive(true);
    }

    void ShowSettings() //Hides main menu and goes to settings.
    {
        settingsObject.SetActive(true);
        HideMainMenu();
    }

    void HideSettings() // Hides the settings menu and goes back to the main menu.
    {
        settingsObject.SetActive(false);
        ShowMainMenu();
    }

    void ShowCredits() //shows credits page
    {
        creditsObject.SetActive(true);
        HideMainMenu();
    }
    void HideCredits() // hides credits page
    {
        creditsObject.SetActive(false);
        ShowMainMenu();
    }

    void ShowLevelSelect()
    {
        levelSelectObject.SetActive(true);
        HideMainMenu();
    }

    void HideLevelSelect()
    {
        levelSelectObject.SetActive(false);
        ShowMainMenu();
    }

    void ExitGame() // exits the game
    {
        Debug.Log("ByeBye");
        Application.Quit();
    }

}
