using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colliderController : MonoBehaviour
{
    public GameObject levelLoader;
    // public GameObject powerupSFX;
    // private AudioSource powerupSource;
    
    // void Start(){
    //     powerupSource = powerupSFX.GetComponent<AudioSource>();
    // }

    void OnTriggerEnter(Collider collision){
        if(collision.tag == "Powerup"){
            //Speed up
            gameObject.GetComponent<MovementController>().speedUp();

            //call any powerup animations + sounds (or put in powerup and make deletes later)
            collision.GetComponent<powerupController>().hitPowerup();
        }
        else if(collision.tag == "Spike"){
            collision.GetComponent<powerupController>().hitPowerup();

            //Call car's hit script - stops car moving
            gameObject.GetComponent<MovementController>().hitSpike();

            //Tell level loader the player is dead, load game over after delay
            levelLoader.GetComponent<LevelLoader>().playerDied();
        }
        else{
            Debug.Log("Detected trigger between " + gameObject.name + " and " + collision.tag);
        }
            
    }
}
