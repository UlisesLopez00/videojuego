using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce = 2f;
    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.transform.CompareTag(GameConstants.TAG_PLAYER)){return;}
        other.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
    }
}
