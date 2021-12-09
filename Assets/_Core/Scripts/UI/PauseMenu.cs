using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnLevelSelectClick(){
        LevelManager.Ins.ShowLevelSelect();
        OnCountinueClick();
    }
    public void OnCountinueClick(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
