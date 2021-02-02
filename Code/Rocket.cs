using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D playerRB, rocketRB;
    SpriteRenderer rocketRenderer;
    [SerializeField] Sprite rocketWithPlayer;
    bool inRocketToggle = false;
    GameObject playerObject;
    Collider2D playerCollider;
    Player_control playerControls;
    GameObject rocketEffects;

    void Start()
    {
        rocketRB = gameObject.GetComponent<Rigidbody2D>();
        playerRB = (Rigidbody2D)GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rocketRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerObject = (GameObject)GameObject.Find("Player");
        playerCollider = (Collider2D)GameObject.Find("Player").GetComponent<Collider2D>();
        playerControls = (Player_control)GameObject.Find("Player").GetComponent<Player_control>();
        rocketEffects = (GameObject)GameObject.Find("RocketAddons");
        rocketEffects.SetActive(false);
    }


    void Update()
    {
        InRocket();
        RocketLaunch();
    }

    void Use()
    {
        rocketRenderer.sprite = rocketWithPlayer;
        inRocketToggle = true;
        playerObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        playerCollider.isTrigger = true;
        playerControls.enabled = false;
    }

    void InRocket()
    {
        if (inRocketToggle)
        {
            playerRB.transform.position = rocketRB.transform.position;
        }
    }

    void RocketAccelerate()
    {
        rocketRB.gravityScale *= -1;
        rocketEffects.SetActive(true);
        SoundController.PlaySound("rocket");
    }

    void RocketLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRocketToggle)
        {
            RocketAccelerate();
            Debug.Log("accelerating");
        }
    }

}
