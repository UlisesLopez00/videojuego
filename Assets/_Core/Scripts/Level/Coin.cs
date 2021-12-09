using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        if (other.tag != GameConstants.TAG_PLAYER){return;}
        LevelManager.Ins.AddCoins();
        GameObject.Destroy(this.gameObject);
    }
}
