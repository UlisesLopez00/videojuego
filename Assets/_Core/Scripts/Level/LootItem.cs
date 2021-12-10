using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public bool isActive = false;
    public bool isLooted = false;
    public GameObject lootUIPos;
    public bool removeAfterLoot = false;
    public virtual void GiveLoot(){}
    private void OnTriggerEnter2D(Collider2D _other) {
        if(isLooted){return;}

        if(_other.tag != GameConstants.TAG_PLAYER){return;}
        isActive=true;
        LevelManager.Ins.lootUI.gameObject.SetActive(true);
        LevelManager.Ins.lootUI.transform.position = lootUIPos.transform.position;
    }
    private void OnTriggerExit2D(Collider2D _other) {
        if(isLooted){return;}

        if(_other.tag != GameConstants.TAG_PLAYER){return;}
        isActive=false;
        LevelManager.Ins.lootUI.gameObject.SetActive(false);
    }

    void Update() {
        if(!isActive){return;}
        if(isLooted){return;}
        Collect();
    }
    public void Collect(){
        if (Input.GetKeyDown(KeyCode.E)){
           DoCollect();
        }
    }
    public void DoCollect(){
         GiveLoot();
            isLooted=true;
            LevelManager.Ins.lootUI.gameObject.SetActive(false);
            if (removeAfterLoot)
            {
                gameObject.SetActive(false);
            }
    }
    public void OnClickCollect(){
        DoCollect();
    }
    public void Dar(){
        
    }
}
