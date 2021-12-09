using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLoot : LootItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void GiveLoot(){
        LevelManager.Ins.player.gun.gameObject.SetActive(true);
    }
    
}
