using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : LootItem
{
    public Animator animator;
    public List<CoinJump> coinList;
    private int coinIter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void GiveLoot()
    {
        animator.Play("chest-open");
        InvokeRepeating("GiveCoin",0,0.2f);
    }
    public void GiveCoin(){
        if (coinIter >= coinList.Count)
        {
            CancelInvoke("GiveCoin");
            coinList[coinIter].gameObject.SetActive(false);
            return;
        }
        coinList[coinIter].gameObject.SetActive(true);
        coinList[coinIter].Jump();
        
        coinIter++;
    }
    
}
