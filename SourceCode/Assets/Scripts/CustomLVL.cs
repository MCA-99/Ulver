using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CustomLVL : MonoBehaviour {

    public int customLVL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            next_scene();
        }
    }

    private void next_scene() {
        Initiate.Fade("lvl" + customLVL, Color.black, 0.3f);
    }
}
