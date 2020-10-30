using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupController : MonoBehaviour
{
    // public GameObject sfx;
    private AudioSource source;
    private bool isPlaying = false;

    void Start(){
        source = GetComponent<AudioSource>();
    }

    public void hitPowerup(){
        //TODO: play shatter animation
        GetComponent<MeshRenderer>().enabled = false;
        
        isPlaying = true;
        StartCoroutine(WaitCoroutine());
    }

    public void removePowerup(){
        if (!isPlaying){
            Destroy(gameObject);
        }
    }

    IEnumerator WaitCoroutine()
    {
        source.Play();
        yield return new WaitForSeconds(1);
        isPlaying = false;
        Destroy(gameObject);
    }
}
