using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCards : MonoBehaviour
{
    private GameObject thisKeyCard;
    [SerializeField] private Door levelDoor;
    private GameObject keyCardParentObject;
    private Transform[] allKeycards;

   void Start()
    {
        keyCardParentObject = this.transform.parent.gameObject; // get the parent object of all keycards
        thisKeyCard = gameObject;
        allKeycards = keyCardParentObject.GetComponentsInChildren<Transform>(); //Gets all transforms from the child obejcts and puts them on a list
    }

    //on enter it calls for keycollected in KeyCard.cs then sets the keycard to inactive aka hides it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelDoor.KeyCollected();
        thisKeyCard.SetActive(false);
    }

    public void SetKeycardsActive() //This is called by PlayerActions.cs on respawn and it will set all the keycards active.
    {
        foreach (Transform n in allKeycards) n.gameObject.SetActive(true);
        levelDoor.ResetCount(); // this will reset the count that the level door is keeping on the keycards.
        Debug.Log("Keycard count reset");
    }

}
