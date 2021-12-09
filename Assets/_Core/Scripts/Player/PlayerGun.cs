using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public GameObject shootPos;
    public GameObject bulletPrefab;
    public GameObject particulas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Shoot();   
        }
    }

    public void Shoot(){
        Instantiate(bulletPrefab, 
                    shootPos.transform.position,
                    shootPos.transform.rotation);
    }
}
