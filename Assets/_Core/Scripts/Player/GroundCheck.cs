using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool isGrounded=false;
    public SpriteRenderer spriteRenderer;
    public PlayerMovement playerMovement;

    void Start()
    {
        
    }

    void Update()
    {
        if (isGrounded)
        {
            spriteRenderer.color = Color.green;
        }else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // isGrounded = other != null && other.tag == GameConstants.TAG_GROUND;

        if (other.tag != GameConstants.TAG_GROUND){return;}
            isGrounded=true;
            playerMovement.OnLandEvent();    
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag != GameConstants.TAG_GROUND){return;}
        isGrounded = false;
    }

}
