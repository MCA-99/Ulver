using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PrevLVL : MonoBehaviour
{
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
        var currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        string currentSceneNumber = currentSceneName.Substring(currentSceneName.Length - 1);
        
        int numero = System.Convert.ToInt32(currentSceneNumber);
        int nextSceneNumber = numero - 1;
        string nextSceneNumber_string = nextSceneNumber.ToString();

        Initiate.Fade("lvl" + nextSceneNumber_string, Color.black, 0.3f);
    }
}
