using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image vida;
    private GameObject player;

    // Start is called before the first frame update
    void Awake() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float hp, float maxHp){
        // Controlar que el daño sufrido no pueda ser ni 0 ni la salud maxima del personaje
        vida.transform.localScale = new Vector2(hp/maxHp, 1);
    }
}
