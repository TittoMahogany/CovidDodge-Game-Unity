using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource damageSfx;
    public AudioSource gameOverSfx;
    
    private int playerHealth;

    // Update is called once per frame
    void Update()
    {
        if(player){
            if(player.GetComponent<Player>().health < 1) {
                gameOverSfx.Play();
            }
        }
    }

    public void DamageHit(bool collision)
    {
        damageSfx.Play(); 
    }
}
