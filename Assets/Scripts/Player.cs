using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public int jumpForce;
    public Text healthUI;
    public GameObject gameOver;

    public int health = 3;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator animator;

    public bool isGrounded;

    public AudioSource BGM;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = health.ToString();

        if (health > numOfHearts) {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {

            if (i < health) {
                hearts[i].sprite = fullHeart; 
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            BGM.Stop();
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        if(isGrounded){
            animator.SetBool("isFlying", false);
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!PauseMenu.GameIsPaused)
            {
                rb.AddForce(Vector2.up * jumpForce); 
                animator.SetBool("isFlying", true);
            }
        }

    }
}
