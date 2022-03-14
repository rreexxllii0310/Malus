using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantItemTrigger : MonoBehaviour
{
    public PlayerController player;
    public Item thisItem;
    public ImportantItem importantItem;
    public MapItem mapItem;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.Pick)
            {
                mapItem.SetPicked();
                importantItem.GetImportantItem(1);
                Destroy(gameObject);
                player.Pick = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        player.Pick = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.Pick = false;
    }
}
