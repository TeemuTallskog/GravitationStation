using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    private bool upDown = false;

    //once you're on top of a ladder trigger it allows you to climb up and down
    void OnTriggerStay2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player")) 
        {
            Rigidbody2D playercollision = collide.GetComponent<Rigidbody2D>();
            Animator playerAnimator = collide.GetComponent<Animator>();
            if (!upDown)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    playercollision.velocity = new Vector2(0, speed);
                    playerAnimator.Play("LadderUp");
                    SoundController.PlaySound("ladder");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    playercollision.velocity = new Vector2(0, -speed);
                    playerAnimator.Play("LadderUp");
                    SoundController.PlaySound("ladder");
                }
                else
                {
                    playercollision.velocity = new Vector2(0, 0);
                    playerAnimator.Play("Idle");
                }
            }
            else //upDown toggle with toggle between these two controls. gravity gets turned upside down the player controls on the ladder will also be turned upsidedown.
            {
                if (Input.GetKey(KeyCode.S))
                {
                    playercollision.velocity = new Vector2(0, speed);
                    playerAnimator.Play("LadderUp");
                    SoundController.PlaySound("ladder");
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    playercollision.velocity = new Vector2(0, -speed);
                    playerAnimator.Play("LadderUp");
                    SoundController.PlaySound("ladder");
                }
                else
                {
                    playercollision.velocity = new Vector2(0, 0);
                    playerAnimator.Play("Idle");
                }
            }
        }
    }

    //once you exit ladder it sets your character velocity to 0 and sets your animation to jump
    void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
        Animator playerAnimator = collision.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAnimator.Play("Idle");
            playerRB.velocity = new Vector2(0, 0);
        }
    }
    
    public void ToggleUpDown()
    {
        upDown = !upDown;
    }

}
