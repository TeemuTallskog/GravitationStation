using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static AudioClip walk1, walk2, jump, doorOpen, cardCollect, gravity, ladder1, ladder2, death, rocketThrust; //All the sound effects
    private static AudioSource audioSrc;
    private static bool walkToggle = true; //toggle to control the walking sound
    private static bool climbToggle = true; //toggle to control the climbing sound


    void Start()
    {
        walk1 = Resources.Load<AudioClip>("Walk1st");
        walk2 = Resources.Load<AudioClip>("Walk2nd");
        jump = Resources.Load<AudioClip>("Jump");
        doorOpen = Resources.Load<AudioClip>("DoorOpen");
        cardCollect = Resources.Load<AudioClip>("CardCollect");
        gravity = Resources.Load<AudioClip>("GravitySwitch");
        ladder1 = Resources.Load<AudioClip>("Ladder1");
        ladder2 = Resources.Load<AudioClip>("Ladder2");
        death = Resources.Load<AudioClip>("death");
        rocketThrust = Resources.Load<AudioClip>("RocketThrust");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walk":   //Walking SFX which has 2 parts that will play after each other controlled by a toggle.
                if (!audioSrc.isPlaying)
                    if (walkToggle)
                    { 
                        audioSrc.PlayOneShot(walk1);
                        walkToggle = !walkToggle;
                    }
                else if (!walkToggle)
                    {
                        audioSrc.PlayOneShot(walk2);
                        walkToggle = !walkToggle;
                    }
                break;
            case "stop": //Stops any SFX that is currently playing.
                audioSrc.Stop();
                break;
            case "jump": //Jump SFX
                audioSrc.PlayOneShot(jump);
                break;
            case "doorOpen": //Door opening SFX
                audioSrc.PlayOneShot(doorOpen);
                break;
            case "cardCollect": //Collecting a keycard SFX
                audioSrc.PlayOneShot(cardCollect);
                break;
            case "gravity": //Pressing a gravity switch SFX
                audioSrc.PlayOneShot(gravity);
                break;
            case "ladder": //Climbing a ladder SFX that has 2 parts that are player one after the other controlled by a toggle
                if (!audioSrc.isPlaying)
                    if (climbToggle)
                    {
                        audioSrc.PlayOneShot(ladder1);
                        climbToggle = !climbToggle;
                    }
                    else if (!climbToggle)
                    {
                        audioSrc.PlayOneShot(ladder2);
                        climbToggle = !climbToggle;
                    }
                break;
            case "death": //Player dying SFX
                audioSrc.PlayOneShot(death);
                break;
            case "rocket": //Rocket thrust SFX
                audioSrc.PlayOneShot(rocketThrust);
                break;
        }
    }

}
