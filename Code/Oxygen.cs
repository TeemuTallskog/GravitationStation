using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// throw this script in the meter under the OxygenMeter object
// set the Player actions script to 'Player Anim'
// set a 'Max time' for the meter (seconds)
// throw TimerT object in the 'Time Text'
// under the Player object in the Player Actions script link Oxygen Meter to 'meter' 


public class Oxygen : MonoBehaviour
{
    [SerializeField] private PlayerActions playerAnim;

    public float maxTime = 2f; // max time is adjustable in the inspector!
    float meter;
    public Text timeText;
    Image oxygenImage;

    private bool stopTime;

    // Start is called before the first frame update
    void Start()
    {
        oxygenImage = GetComponent<Image>(); // gets the image component of meter
        meter = maxTime; // sets meter to the already set max time
        stopTime = false;
    }

    // Update is called once per frame
    public void Update()
    {
        // minutes, seconds, and milliseconds in format of text
        float time = meter - Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60f);
        float fraction = time * 1000;
        fraction = fraction % 1000;
        string textT = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, fraction);


        // if timer is more than zero it will keep counting down and decreasing the meter
        if (time > 0)
        {
            meter -= Time.deltaTime;
            oxygenImage.fillAmount = meter / maxTime;
        }

        if (!stopTime && time <= 0)
        {
            playerAnim.KillPlayer(); // KillPlayer method will be active if not stopTimer and timer is lesser or qual to zero
            stopTime = true; // after player dies this will stop the timer
            oxygenImage.fillAmount = 0; 
            meter = 0;
            timeText.text = (meter).ToString("Out of oxygen!"); // sets the tiemr text to ""Out of oxygen!" string after timer hits zero
        }

        if (stopTime == false) // if stopTiemr is set to false then timer text will keep showing the timer
        {
            timeText.text = textT;
        }
    }

    // reactivates script when the player hit respawn.
    public void SetOxygenActive()
    {
        Start();
        Debug.Log("test");
    }
}
