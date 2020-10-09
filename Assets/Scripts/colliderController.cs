using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderController : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        if(collision.tag == "Powerup"){
            //call any powerup animations in pickup and delete
            collision.GetComponent<powerupController>().pickUp();

            gameObject.GetComponent<MovementController>().speedUp();
        }
        else if(collision.tag == "Spike"){
            //Stop moving, Animate player death
            gameObject.GetComponent<MovementController>().hitSpike();
        }
        else{
            Debug.Log("Detected trigger between " + gameObject.name + " and " + collision.tag);
        }
            
    }
}
