using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{

    //Put this on the Player GameObject
    public PlayerActions()
    {

    }
    private Transform playerTransform;
    private Rigidbody2D playerRB;
    [SerializeField]private GameObject deathScreenUI;
    [SerializeField] private Transform spawnPoint;
    private Player_control playerObject;
    private Animator playerAnimator;
    [SerializeField] private GravityButton anyGravityButton;
    private KeyCards keycard;
    [SerializeField] private Oxygen oxygenMeter;

    void Start()
    {
        playerObject = (Player_control)GameObject.Find("Player").GetComponent<Player_control>();
        playerTransform = (Transform)GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRB = (Rigidbody2D)GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        keycard = (KeyCards)GameObject.FindGameObjectWithTag("Keycard").GetComponent<KeyCards>();
    }

    //Sets Players Sprite to dead player Sprite and sets the death screen UI to active.
    public void KillPlayer()
    {
        deathScreenUI.SetActive(true);
        playerObject.enabled = false;
        playerAnimator.Play("Player_dead");
        playerRB.velocity = Vector3.zero; // sets dead players velocity to 0;
        SoundController.PlaySound("death"); //Plays the death SFX
    }

    //teleports the player to a respawn point and sets the player animation back to idle. Also disables death screen
    public void Respawn()
    {
        oxygenMeter.SetOxygenActive();
        keycard.SetKeycardsActive();
        playerTransform.transform.position = spawnPoint.position;
        deathScreenUI.SetActive(false);
        playerObject.enabled = true;
        playerAnimator.Play("Idle");
        if(playerRB.gravityScale < 0) // Turns gravity to normal if player respawns while upsidedown
        {
            anyGravityButton.SendMessage("Use"); 
        }
    }
}
