using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupController : MonoBehaviour
{
    // public GameObject sfx;
    private AudioSource source;

    void Start(){
        source = GetComponent<AudioSource>();
    }

    public void removePowerup(){
        // source.Play();

        // Destroy(gameObject); 
        //Gets destroyed by generator anyways
        //Need animation tho
    }
}
