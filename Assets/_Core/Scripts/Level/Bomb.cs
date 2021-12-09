using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject particulas;
    public float speed;
    public float speedY;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == GameConstants.TAG_ENEMY || 
           other.tag == GameConstants.TAG_GROUND)
        {

            Instantiate(particulas,
                        transform.position,
                        transform.rotation);
        
            Debug.Log("Entro a colision");
            gameObject.SetActive(false);
            particulas.gameObject.SetActive(true);
        }
    }

    
    void Update()
    {
        rigidbody2D.AddForce(new Vector2(transform.right.x * speed, speedY));
        Debug.Log(speedY);
    }
}
