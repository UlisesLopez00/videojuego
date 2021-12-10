using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement pm;
    public SpriteRenderer sr;
    public Sprite spriteDamage;
    public Animator animator;
    public GameObject gun;
    public GameObject bombGun;
    private const int MAX_LIFES=3;
    
    public int lifes=3;
    public void ResetPlayer(){
        lifes = MAX_LIFES;
        gun.gameObject.SetActive(false);
        bombGun.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == GameConstants.TAG_ENEMY  )
        {
            Debug.Log("Colision con enemigo");
            OnDamage();
        }
    }

    private bool esInmune = false;
    public void OnDamage(){
        if(esInmune) { return; }
        AudioManager.Ins.PlaySound(GameConstants.AUDIO_DAMAGE_SOUND);
        lifes--;
        if(lifes<0){
            LevelManager.Ins.GameOver();
            pm.BlockMove(true);    
            pm.StopMove();
            animator.enabled=false;
            return;
        }
        LevelManager.Ins.OnDamagePlayer(lifes);

        esInmune = true;
        pm.BlockMove(true);
        pm.StopMove();
        
        animator.enabled = false;
        sr.sprite = spriteDamage;

        pm.DamageForce();

        InvokeRepeating("Parpadeo",0,0.2f);

        Invoke("BackToNormal", 1.5f);
    }

    public void BackToNormal(){
        esInmune = false;
        pm.BlockMove(false);
        animator.enabled = true;
        CancelInvoke("Parpadeo");
        sr.enabled = true;
    }

    private void Parpadeo(){
        sr.enabled = !sr.enabled;
    }

}
