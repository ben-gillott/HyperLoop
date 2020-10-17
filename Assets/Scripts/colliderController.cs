using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colliderController : MonoBehaviour
{
    public GameObject levelLoader;

    void OnTriggerEnter(Collider collision){
        if(collision.tag == "Powerup"){
            //call any powerup animations in pickup and delete
            collision.GetComponent<powerupController>().removePowerup();

            gameObject.GetComponent<MovementController>().speedUp();
        }
        else if(collision.tag == "Spike"){
            //Stop moving, Animate player death

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
