using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public PlayerController player;
    public Item thisItem;
    public Inventory playerInventory;
    public MapItem mapItem;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            if (player.Pick)
            {
                mapItem.SetPicked();
                AddItemToBag();
                Destroy(gameObject);
                player.Pick = false;
            }
        }
    }

    public void AddItemToBag()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null) 
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
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
