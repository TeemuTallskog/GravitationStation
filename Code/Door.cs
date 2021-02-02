using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    private bool isDoorOpen;
    private SpriteRenderer levelDoorSprite;
    [SerializeField] private Sprite door_open;
    [SerializeField] private Sprite door_closed;
    [SerializeField] private string NextLevel;
    [SerializeField]private int keysRequiredToUnlock;
    private int keysCollected;
    private Rigidbody2D player;
    [SerializeField] private GravityButton gravButton;
    private TextMeshProUGUI uiCounter;
    private GameObject doorClosedLight, doorOpenLight;
    PlayerPref playerPreferences;


    private void Start()
    {
        playerPreferences = (PlayerPref)GameObject.FindGameObjectWithTag("PlayerPrefs").GetComponent<PlayerPref>();
        levelDoorSprite = GetComponent<SpriteRenderer>();
        player = (Rigidbody2D)GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        uiCounter = (TextMeshProUGUI)GameObject.Find("KeycardCounter").GetComponent<TextMeshProUGUI>();
        doorClosedLight = (GameObject)GameObject.Find("DoorClosedLight");
        doorOpenLight = (GameObject)GameObject.Find("DoorOpenLight");
        doorOpenLight.SetActive(false);
    }

    void Update()
    {
        uiCounter.text = keysCollected + " / " + keysRequiredToUnlock; //this will be shown on HUD so the player can track how many keycards they have collected.
    }

    //Opens the door to the next level
    public void OpenDoor()
    {
        levelDoorSprite.sprite = door_open;
        isDoorOpen = true;
        doorOpenLight.SetActive(true);
        doorClosedLight.SetActive(false);
    }

    public void CloseDoor() // closes the level door incase the player collects all the key cards but dies before entering the door
    {
        levelDoorSprite.sprite = door_closed;
        isDoorOpen = false;
        doorClosedLight.SetActive(true);
        doorOpenLight.SetActive(false);
    }

    //loads the player into the next level if the door is open
    public void EnterDoor()
    {
        if (isDoorOpen)
        {
            if (player.gravityScale < 0)
                gravButton.SendMessage("SetState", false);
            SceneManager.LoadScene(NextLevel);
            playerPreferences.LevelCompleted(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterDoor();
    }

    //registeres one key collected and opends door if it's the last key in the scene
    public void KeyCollected()
    {
        keysCollected += 1;
        SoundController.PlaySound("cardCollect"); // Plays Keycard collect SFX
        if (keysCollected == keysRequiredToUnlock)
        {
            OpenDoor();
            SoundController.PlaySound("doorOpen"); //Plays Door opening SFX
        }
    }

    public void ResetCount()
    {
        keysCollected = 0;
        CloseDoor();
    }

}
