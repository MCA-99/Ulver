using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{   
    private GameObject player;
    Player playerScript;
    private SpriteRenderer sr;
    public float daño;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();       
        sr = GetComponent<SpriteRenderer>();
        daño = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player"){
            playerScript.SufrirDaño(daño);
            if (sr.flipY == true) {
                playerScript.GetComponent<Rigidbody2D>().AddForce(new Vector2(-50000f * Time.deltaTime, 0));
                playerScript.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15.5f), ForceMode2D.Impulse);
            } else if (sr.flipY == false) {
                playerScript.GetComponent<Rigidbody2D>().AddForce(new Vector2(50000f * Time.deltaTime, 0));
                playerScript.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15.5f), ForceMode2D.Impulse);
            }
        }
    }
}
