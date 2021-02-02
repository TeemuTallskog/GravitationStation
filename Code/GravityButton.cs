using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All gravity buttons need to be under the same parent object for animations to work
// Throw this script in the sprite button
// Link the Player object in the Target option

public class GravityButton : MonoBehaviour
{
    public static bool flipSwitch;
    private Gravity Target; //The Player
    public enum ButtonSelector // list with awailable options from dropdown inside inspector
    {
        GUpButton, GDownButton,ToggleButton
    };
    public ButtonSelector buttonSelect; //the selection made inside unity inspector

    void Start()
    {
        Target = (Gravity)GameObject.FindGameObjectWithTag("Player").GetComponent<Gravity>();
    }

    public void Use()
    {
        if (buttonSelect == ButtonSelector.ToggleButton) // Versatile gravity button will call this
        {
            Toggle();
        }
        if (buttonSelect == ButtonSelector.GUpButton) // gravity up button will call this
        {
            SetState(true);
        }
        if (buttonSelect == ButtonSelector.GDownButton) //gravity down button will call this
        {
            SetState(false);
        }
    }

    public void Toggle() // if the flipSwitch is true, flipSwtich will be set to false  to turn gravity to normal, else it will be set to true to make gravity upsidedown. this toggle will toggle flipSwitch between true and false to control gravity.
    {
        if (flipSwitch)
            SetState(false);
        else
            SetState(true);
    }

    void SetState(bool input) //calling this with input = true gravity will be switched upside down and if it's false gravity be go back to normal.
    {
        flipSwitch = input;
        if (input)
        {
            if (Target != null)
                Target.SendMessage("Up"); //sends a message to Gravity.cs to run function "Up"
        }
        else
        {
            if (Target != null)
                Target.SendMessage("Down"); //Sends a message to Gravity.cs to run function "Down"
        }
    }

}
