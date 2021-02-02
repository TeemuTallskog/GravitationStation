using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    private GameObject thisText;
    private GameObject childText;

    void Start()
    {
        thisText = gameObject;
        childText = thisText.transform.GetChild(0).gameObject;
        childText.SetActive(false);
    }

    //if player is ontop of the text collider the text is visible
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            childText.SetActive(true);
        }
    }

    // once player exits it's hidden
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            childText.SetActive(false);
        }
    }
}
