using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteDamage;
    public Sprite spriteDead;
    public Animator animator;
  
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == GameConstants.TAG_BULLET)
        {
            OnDamage();
        }
    }
    public void OnDamage(){
       if(animator != null){animator.enabled= false;}
        spriteRenderer.sprite = spriteDamage;
        InvokeRepeating("Parpadeo",0,0.2f);
        Invoke("Dead",1.5f);
        AudioManager.Ins.PlaySound(GameConstants.AUDIO_DAMAGE_ENEMY);
    }

    private void Dead(){
        CancelInvoke("Parpadeo");
        spriteRenderer.sprite = spriteDead;
        Invoke("Muerto",0.5f);
    }
    private void Muerto(){
        GameObject.Destroy(this.gameObject);
    }
    public void BackToNormal(){
        if(animator != null){animator.enabled = true;}
        CancelInvoke("Parpadeo");
        spriteRenderer.enabled = true;
    }
    private void Parpadeo(){
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
