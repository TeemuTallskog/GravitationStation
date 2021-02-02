using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]private PlayerActions playerAnim;


    //Calls killplayer from PlayerActions.cs if the collision is a player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            playerAnim.KillPlayer();
        }
    }
}
