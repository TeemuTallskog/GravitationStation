using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    //You need to link the death screen Ui and Pause Menu UI inside Unity
    //Pause menu needs to have "Resume" & "ExitGame" buttons
    //Death screen needs to have a "RespawnButton" Button

    [SerializeField] private PlayerActions playerAnim;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject deathScreenUI;
    private bool isPaused = false;
    private Button resumeGameButton;
    private Button exitGameButton;
    private Button respawnButton;
    private Button respawnWhileAlive;
    private GameObject pauseMenuButtons;
    private Button settingsButton;
    private GameObject settingsMenu;
    private bool isInMenu = true;
    private Button backButton;

    void Start()
    {
        exitGameButton = (Button)GameObject.Find("ExitGame").GetComponent<Button>();
        resumeGameButton = (Button)GameObject.Find("Resume").GetComponent<Button>();
        respawnButton = (Button)GameObject.Find("RespawnButton").GetComponent<Button>();
        respawnWhileAlive = (Button)GameObject.Find("RespawnPause").GetComponent<Button>();
        pauseMenuButtons = (GameObject)GameObject.Find("PauseMenuButtons");
        settingsButton = (Button)GameObject.Find("SettingsButton").GetComponent<Button>();
        settingsMenu = (GameObject)GameObject.Find("Settings");
        backButton = (Button)GameObject.Find("BackButton").GetComponent<Button>();

        settingsButton.onClick.AddListener(() => EnterSettings());
        respawnButton.onClick.AddListener(() => playerAnim.Respawn());
        exitGameButton.onClick.AddListener(() => LevelSwap("MainMenu"));
        resumeGameButton.onClick.AddListener(() => DeactivatePauseMenu());
        respawnWhileAlive.onClick.AddListener(() => playerAnim.Respawn());
        backButton.onClick.AddListener(() => DisableSettingsMenu());
        pauseMenuUI.SetActive(false);
        deathScreenUI.SetActive(false);
    }

    private void Update()
    {
        //When you press esc game goes on pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        //isPaused = true means it's paused
        if (isPaused)
        {
            ActivatePauseMenu();
        }
        else
        {
            DeactivatePauseMenu();
        }
    }

    //activates pause menu
    void ActivatePauseMenu()
    {
        if (isInMenu)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            settingsMenu.SetActive(false);
            pauseMenuButtons.SetActive(true);
        }
        if (!isInMenu)
        {

        }
    }
    //deactivates pause menu
    void DeactivatePauseMenu()
    {
        isInMenu = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    // loads the level that's put into the input
    void LevelSwap(string level)
    {
        SceneManager.LoadScene(sceneName: level);
    }

    public void EnterSettings() //Enters sound settings
    {
        isInMenu = false;
        pauseMenuButtons.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void EnableMenuButtons() //Enables the buttons on the pause menu
    {
        pauseMenuButtons.SetActive(true);
    }

    void DisableSettingsMenu() // disables the settings menu and enters pause menu
    {
        settingsMenu.SetActive(false);
        EnableMenuButtons();
    }
}
