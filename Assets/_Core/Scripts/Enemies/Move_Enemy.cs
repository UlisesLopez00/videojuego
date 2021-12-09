using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Move_Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject startPosition;
    public GameObject endPosition;
    void Start()
    {
        enemy.transform.position = startPosition.transform.position;
        enemy.transform
            .DOMove(endPosition.transform.position,1)
            .SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

    }
}
