using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuQuit : MonoBehaviour {

    GameObject Player;

    // Start is called before the first frame update
    void Start() {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            Application.Quit();
        }
    }
}
