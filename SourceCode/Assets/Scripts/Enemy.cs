using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHp = 100f;
    float hp;
    private GameObject player;
    private Player playerScript;

    private BoxCollider2D PlayerAttackCol;
    private Animator anim;

    public float dañoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
     hp = maxHp;
     player = GameObject.Find("Player");
     PlayerAttackCol = player.GetComponent<BoxCollider2D>();
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = player.GetComponent<Player>();
        dañoPlayer = playerScript.dañoAtaque;
    }

    public void SufrirDaño(float daño){
        hp -= daño;

        if(hp < 1){
            anim.SetBool("dead", true);
        }
    }

    private void DeadEnemy(){
        Destroy(gameObject, 0.15f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other == PlayerAttackCol){
            SufrirDaño(dañoPlayer);
            if (hp > 0){
                anim.SetBool("hit", true);
            }
            
            Debug.Log("Hitted");
        }else{
            anim.SetBool("hit", false);
        }
    }
}
