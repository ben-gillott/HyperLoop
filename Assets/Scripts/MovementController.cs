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
    
    
    //Privates
    private int lane = 0; //Current lane
    private static float fPI = (float)Math.PI;
    private float t = 1.5f*fPI; //Position in the loop in spherical, from 0 to 2pi
    private float lastRotX = 0;

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

        // car.Rotate(-speed*Time.deltaTime, 0.0f, 0.0f, Space.Self);
        // car.Translate(Vector3.forward * Time.deltaTime * speed);

        //Position : spherical coords
        float x = trackWidth*lane;
        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;
        gameObject.transform.position = new Vector3(x,y,z);
        

        //Direction : tangent to circle

        // float vz = gameObject.transform.position.z - centerZ;
        // float vy = gameObject.transform.position.y - centerY;
        
        // Vector3 orthDirection = new Vector3(0f, -vz, vy);
        // Vector3 orthDirection = new Vector3(0f, (float)Math.Cos(t), (float)Math.Sin(t));
        // gameObject.transform.forward = orthDirection;

        float rotX = (360f*(-1)*t/(2f*fPI)-90f)%360f;
        // Debug.Log(xRot);
        // Vector3 eulers = gameObject.transform.rotation.eulerAngles;
        // gameObject.transform.rotation = Quaternion.Euler(new Vector3(xRot,eulers.y,eulers.z));
        Quaternion localRotation = Quaternion.Euler(rotX - lastRotX, 0f, 0f);
        transform.rotation = transform.rotation * localRotation;
        lastRotX = rotX;

        // Vector3 rot = gameObject.transform.eulerAngles;
        // gameObject.transform.eulerAngles = new Vector3(xRot, rot.y, rot.z);

        //update t


        t += speed * Time.deltaTime * fPI;
    }

    public void speedUp(){
        speed += speedIncrease;
    }
}
