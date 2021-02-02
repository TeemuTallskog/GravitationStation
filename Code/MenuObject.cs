using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObject : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D objectVar = gameObject.GetComponent<Rigidbody2D>(); //gives initial velocity to the object in the main menu, so it will bounce around.
        objectVar.velocity = new Vector2(15, 10);
        Time.timeScale = 0.5f;
    }
}
