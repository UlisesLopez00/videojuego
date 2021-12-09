using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject text;
    private void OnTriggerEnter2D(Collider2D _other) {
        if (_other.tag != GameConstants.TAG_PLAYER){return;}
        text.gameObject.SetActive(true);
        //Debug.Log("Choque con puerta");
        LevelManager.Ins.OnLevelComplete();
    }
}
