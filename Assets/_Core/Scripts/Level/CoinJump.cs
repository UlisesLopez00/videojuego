using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinJump : MonoBehaviour
{
    public void Jump(){
        transform.DOJump(LevelManager.Ins.coinText.transform.position, 1,1, 0.5f)
        .OnComplete(OnCoinJumpComplete);
    }
    public void OnCoinJumpComplete(){
        LevelManager.Ins.AddCoins();
        gameObject.SetActive(false);
    }
}
