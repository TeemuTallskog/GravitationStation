using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Throw this script in the Player object

public class Gravity : MonoBehaviour
{
    Rigidbody2D gravitySwitch;

    public static bool UpDown;
    private SpriteRenderer playerSpriteRenderer;
    private float playerHeight;
    [SerializeField] private Ladder anyLadder; // here you input any ladder object you have in a scene
    private GameObject[] gravToggleList;
    public List<Animator> gravButtonAnimator = new List<Animator>();

    private void Start()
    {
        gravitySwitch = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerHeight = gravitySwitch.transform.lossyScale.y; // gets players height
        gravToggleList = GameObject.FindGameObjectsWithTag("GravityToggle");
        foreach (GameObject n in gravToggleList) gravButtonAnimator.Add(n.GetComponent<Animator>()); //gets all animators from gravity toggle buttons and puts them on a list
    }

    public void Up()  // Method for setting gravity scale to inverse and rotating Player object 180 degrees
    {
        if (!UpDown)
            SetState(true);
        Debug.Log("Up");
        gravitySwitch.gravityScale *= -1;
        transform.localRotation = Quaternion.Euler(180, 0, 0);
        gravitySwitch.transform.position = new Vector3(gravitySwitch.transform.position.x, gravitySwitch.transform.position.y + playerHeight + 2f, gravitySwitch.transform.position.z);  //Teleports the player up its own height +2f so it doesn't clip trough the map
        LadderToggle();
        foreach (Animator n in gravButtonAnimator) n.Play("GravityUp"); //Playes gravity up animation on all gravity buttons once gravity switches to "Up"
        SoundController.PlaySound("gravity");
    }

    public void Down()  // Method for setting gravity scale to normal and setting Player object rotation back to normal
    {
        if (UpDown)
            SetState(false);
        Debug.Log("Down");
       gravitySwitch.gravityScale *= -1;
       transform.localRotation = Quaternion.Euler(0, 0, 0);
        gravitySwitch.transform.position = new Vector3(gravitySwitch.transform.position.x, gravitySwitch.transform.position.y - playerHeight - 2f, gravitySwitch.transform.position.z); //Teleports the player down its own height -2f so it doesn't clip trough the map
        LadderToggle();
        foreach (Animator n in gravButtonAnimator) n.Play("GravityDown"); //Playes gravity up animation on all gravity buttons once gravity switches to "Up"
        SoundController.PlaySound("gravity"); //Plays Gravity SFX
    }

    public void SetState(bool input)
    {
        UpDown = input;
    }

    private void LadderToggle()
    {
        if (anyLadder != null)
        {
            anyLadder.SendMessage("ToggleUpDown", SendMessageOptions.DontRequireReceiver);  // Sends message to ladder to inverse Controls
        }
    }
}
