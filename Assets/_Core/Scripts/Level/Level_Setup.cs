using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Setup : MonoBehaviour
{
    public GameObject spawnPoint;
    void Start()
    {
        LevelManager.Ins.player.transform.position = spawnPoint.transform.position;
    }
}
