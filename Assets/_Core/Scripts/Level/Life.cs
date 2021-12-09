using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Image image;
    public Sprite heartOff;
    public Sprite heartOn;
    public void ApagarVida(){
        image.sprite=heartOff;
    }
    public void PrenderVida(){
        image.sprite=heartOn;
    }
}
