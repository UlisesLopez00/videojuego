using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    public bool keyStatus = false;
    void Start() {
        doorClosed.gameObject.SetActive(true);
        doorOpen.gameObject.SetActive(false);
        doorClosed.transform.position=doorOpen.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != GameConstants.TAG_PLAYER){return;}
        Debug.Log("Se recogio la llave");
        LevelManager.Ins.OnKeyTaked();
        keyStatus=true;
        if (keyStatus){
            ChangeDoor();    
        }
        GameObject.Destroy(this.gameObject);
    }
    public void ChangeDoor(){
        doorClosed.gameObject.SetActive(false);
        doorOpen.gameObject.SetActive(true);
    }
}
