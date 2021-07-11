using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Private and global variables for the Unity GUI editor
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool canJump;
    private BoxCollider2D attack;

    private Text stringDinero;

    private GameObject barraVida;
    private BarraVida ScriptbarraVida;

    private GameObject Respawn;

    public int dinero;
    public float speed;
    public float jump_force;
    private float hp;
    public float maxHp = 100f;
    public float dañoAtaque = 30f;

    AudioSource runSound;
    AudioSource jumpSound;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        hp = maxHp;
    }

    /**
    * Start is called before the first frame update
    */
    void Start() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        attack = GetComponent<BoxCollider2D>();
        AudioSource[] sounds = GetComponents<AudioSource>();
        runSound = sounds[0];
        jumpSound = sounds[1];
    }

    /**
    * Update is called once per frame
    */
    void Update() {
        barraVida = GameObject.Find("BarraVida");
        ScriptbarraVida = barraVida.GetComponent<BarraVida>();
        Respawn = GameObject.Find("Respawn");

        // Detect if the character is moving towards any axis and perform animations / movement
        if (Input.GetKey("a") && Input.GetKey("k")==false) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed * Time.deltaTime, 0));
            anim.SetBool("Running", true);
            sr.flipX = true;
            if (!runSound.isPlaying && canJump) {
                runSound.Play();
            }
        } else if (Input.GetKey("d")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Time.deltaTime, 0));
            anim.SetBool("Running", true);
            sr.flipX = false;
            if (!runSound.isPlaying && canJump) {
                runSound.Play();
            }
        }else{
            anim.SetBool("Running", false);
        }
        if (Input.GetKey(KeyCode.Space) && canJump == true) {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
            jumpSound.Play();
        }

        // Animation system
        if(rb.velocity.y == 0){
            anim.SetBool("Jumping", false);
        }
        if(rb.velocity.y < 0){
            anim.SetBool("Falling", true);
        }else{
            anim.SetBool("Falling", false);
        }

        // Atack animation
        if(Input.GetKey("k")){
            anim.SetBool("Attack1", true);
        }else{
            anim.SetBool("Attack1", false);
        }

    }

    private void enableAttack(){
        attack.enabled = true;
    }

    private void disableAttack(){
        attack.enabled = false;
    }

    /**
    * Detect if the player is touching the ground and assign the corresponding variable
    */
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "map") {
            canJump = true;
        }
    }

    public void increasePoints(int incremento){
        dinero += incremento;
    }

    public void SufrirDaño(float daño){
        hp = Mathf.Clamp(hp - daño, 0f, maxHp);
        ScriptbarraVida.TakeDamage(hp, maxHp);
        if(hp < 1){
            var currentScene = SceneManager.GetActiveScene();
            string currentSceneName = currentScene.name;
            hp = maxHp;
            Initiate.Fade(currentSceneName, Color.black, 5f);
            gameObject.transform.position = Respawn.transform.position;
        }
    }
}
