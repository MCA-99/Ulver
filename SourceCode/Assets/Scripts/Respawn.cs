using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    private GameObject player;
    private GameObject respawn;

    // Start is called before the first frame update
    void Start() {
        tp_to_respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tp_to_respawn() {
        player = GameObject.Find("Player");
        respawn = GameObject.Find("Respawn");
        player.transform.position = new Vector3(respawn.transform.position.x, respawn.transform.position.y, -3);
    }
}
