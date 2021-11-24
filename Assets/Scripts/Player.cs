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

    // private const float _minimumHeldDuration = 0.25f;
    // private float _spacePressedTime = 0;
    // private bool _spaceHeld = false;
 

    // Start is called before the first frame update
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

        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
        //     // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.
        //     _spacePressedTime = Time.timeSinceLevelLoad;
        //     _spaceHeld = false;

        // } else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) {
        //     if (!_spaceHeld) {
        //         // Player has released the space key without holding it.
        //         // TODO: Perform the action for when Space is pressed.
        //         if (!PauseMenu.GameIsPaused)
        //         {
        //             rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //         }
        //     }
        //     _spaceHeld = false;
        // }
    
        // if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
        //     if (Time.timeSinceLevelLoad - _spacePressedTime > _minimumHeldDuration) {
        //         // Player has held the Space key for .25 seconds. Consider it "held"
        //         _spaceHeld = true;
        //         rb.AddForce(Vector2.up * jumpForce); 
        //     }
        // }
    }
}
