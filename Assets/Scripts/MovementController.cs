using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    [Header("Objects")]
    [Tooltip("Player object")]
    public Transform car; //Player'

    [Header("Positioners")]
    public float centerZ;
    public float centerY;
    public float radius;
    public float trackWidth;
    
    [Header("Variables")]
    public float speed;
    public float speedIncrease;
    public float xLerpSpeed;
    
    //Privates
    private int lane = 0; //Current lane
    private static float fPI = (float)Math.PI;
    private float t = 1.5f*fPI; //Position in the loop in spherical, from 0 to 2pi
    private float lastRotX = 0;
    private float targetX = 0;
    private float x = 0;

    // Update is called once per frame
    void Update()
    {
        //Controls
        if ((Input.GetKeyDown("left") || Input.GetKeyDown("a")) & lane > -1)
        {
            lane -= 1;
        }
        else if((Input.GetKeyDown("right") || Input.GetKeyDown("d")) & lane < 1) 
        {      
            lane += 1;
        }


        //Position : spherical coords
        targetX = trackWidth*lane; //Set target
        x = Mathf.Lerp(x, targetX, Time.deltaTime * xLerpSpeed);//Lerp x towards target

        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;
        gameObject.transform.position = new Vector3(x,y,z);
        

        //Direction : tangent to circle
        float rotX = (360f*(-1)*t/(2f*fPI)-90f)%360f;
        Quaternion localRotation = Quaternion.Euler(rotX - lastRotX, 0f, 0f);
        transform.rotation = transform.rotation * localRotation;
        lastRotX = rotX;

        //Update T
        t += speed * Time.deltaTime * fPI;
    }

    public void speedUp(){
        speed += speedIncrease;
        //TODO: Speedup animations and effects

    }

    public void hitSpike(){
        speed = 0;
        //TODO: Hitspike animation for player
        //TODO: Call transition to game over state
    }
}
