using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGunLoot : LootItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public override void GiveLoot(){
        LevelManager.Ins.player.bombGun.gameObject.SetActive(true);
    }
}
