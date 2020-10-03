using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Objects")]
    [Tooltip("Player object")]
    public Transform car; //Player'

    [Header("Variables")]
    [Tooltip("Current speed of the car")]
    public float forwardSpeed = 1f; 
    public float rotationSpeed = 1f; 
    [Tooltip("Width of each lane")]
    public float laneWidth = 3;
    private int lane = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move left
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

        car.Rotate(-rotationSpeed*Time.deltaTime, 0.0f, 0.0f, Space.Self);
        car.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

        // //Input version
        // else if((Input.GetButton("Fire1")))
        // {        
        //     car.Rotate(-10.0, 0.0f, 0.0f, Space.Self);
        // }
    }
}
