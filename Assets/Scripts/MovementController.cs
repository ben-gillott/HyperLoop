using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Objects")]
    [Tooltip("Player object")]
    public Transform car; //Player'

    [Header("Variables")]
    private int lane = 0; //Current lane
    public float speed;
    public float speedIncrease;
    public float laneWidth = 3f;

    // Update is called once per frame
    void Update()
    {
        //Controls
        if ((Input.GetKeyDown("left") || Input.GetKeyDown("a")) & lane > -1)
        {
            car.Translate(Vector3.left * laneWidth);
            lane -= 1;
        }
        else if((Input.GetKeyDown("right") || Input.GetKeyDown("d")) & lane < 1) 
        {        
            car.Translate(Vector3.right * laneWidth);
            lane += 1;
        }

        car.Rotate(-speed*Time.deltaTime, 0.0f, 0.0f, Space.Self);
        car.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void speedUp(){
        speed += speedIncrease;
    }
}
