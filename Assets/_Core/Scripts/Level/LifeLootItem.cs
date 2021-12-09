using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLootItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        int lifes=LevelManager.Ins.currentLifes;
        Debug.Log("tus vidas "+lifes);
        if (lifes>=3)
        {
            return;
        }else{
            if(other.tag != GameConstants.TAG_PLAYER){return;}
            GameObject.Destroy(this.gameObject);
            LevelManager.Ins.AddLife(lifes);
            lifes++;
            Debug.Log("vida añadida"+lifes);
        }
       
    }
}
