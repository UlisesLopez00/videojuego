using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag==GameConstants.TAG_ENEMY ||
            other.tag==GameConstants.TAG_GROUND)
        {
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        rigidbody2D.velocity = transform.right * speed;       
    }

}
