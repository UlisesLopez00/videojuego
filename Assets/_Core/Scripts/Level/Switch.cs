using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : LootItem
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteSwitch;

    public GameObject chestLoot;
  
    
    public override void GiveLoot()
    {
        Debug.Log("Prender switch");
        spriteRenderer.sprite = spriteSwitch;
        Invoke("showChest", 1);
    }

    public void showChest() 
    {
        chestLoot.gameObject.SetActive(true);
    }
}
