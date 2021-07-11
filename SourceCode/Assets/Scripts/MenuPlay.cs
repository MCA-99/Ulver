using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuPlay : MonoBehaviour {

    GameObject Player;
    AudioSource thunderSound;

    // Start is called before the first frame update
    void Start() {
        AudioSource[] sounds = GetComponents<AudioSource>();
        thunderSound = sounds[0];
        Player = GameObject.Find("Player");
    }

    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {

           thunderSound.Play();
            Initiate.Fade("lvl0", Color.black, 0.3f);
            
        }
    }
}
