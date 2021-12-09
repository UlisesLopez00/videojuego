using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyOn : MonoBehaviour
{
    public Sprite keyOn;
    public Sprite keyOff;
    public Image image;

    public void KeyTaked(){
        image.sprite=keyOn;
    }
    public void KeyOff(){
        image.sprite=keyOff;
    }
}
