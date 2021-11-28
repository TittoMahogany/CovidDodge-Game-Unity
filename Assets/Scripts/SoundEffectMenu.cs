using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectMenu : MonoBehaviour
{
    public AudioSource clickSFX;  
  
    
    public void BtnClick(){
        clickSFX.Play();
    }
}
