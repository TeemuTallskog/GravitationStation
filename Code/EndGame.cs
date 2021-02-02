using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private StoryLoad endAnimator;
void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            endAnimator.ToggleEnd(); //calls storyload.cs to play end screen and change to main menu
            
    }
}
