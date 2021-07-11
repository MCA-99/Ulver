using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextLVL : MonoBehaviour
{

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {

            var currentScene = SceneManager.GetActiveScene();
            string currentSceneName = currentScene.name;
            
            Debug.Log("current_scene: " + currentSceneName);

            if (currentSceneName == "Menu") {
                next_scene_fromMain();
            } else {
                next_scene();
            }
            
        }
    }

    private void next_scene_fromMain() {
        Initiate.Fade("lvl0", Color.black, 0.3f);
    }

    private void next_scene() {
        var currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        string currentSceneNumber = currentSceneName.Substring(currentSceneName.Length - 1);
        
        int numero = System.Convert.ToInt32(currentSceneNumber);
        int nextSceneNumber = numero + 1;
        string nextSceneNumber_string = nextSceneNumber.ToString();
        
        Initiate.Fade("lvl" + nextSceneNumber_string, Color.black, 0.3f);
    }
}
