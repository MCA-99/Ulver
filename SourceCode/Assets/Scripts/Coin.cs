using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int valorMoneda = 1;
    private AudioSource getSound;
    private GameObject player;
    Rigidbody rb;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        getSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        getSound.Play();
        playerScript.increasePoints(valorMoneda);
        Destroy(gameObject, 0.15f);
    }
}
