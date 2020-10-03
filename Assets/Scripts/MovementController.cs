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
    public float speed = 1f; 
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
        //Vector3 carDir = new Vector3(0f, 0f, 1f);

        car.Translate(Vector3.forward * Time.deltaTime * speed);

        //Move left
        if ((Input.GetKeyDown("left") || Input.GetKeyDown("a")) & lane > -1)
        {
            car.Translate(Vector3.left * laneWidth);
            lane -= 1;
        }
        else if((Input.GetKeyDown("right") || Input.GetKeyDown("a")) & lane < 1) 
        {        
            car.Translate(Vector3.right * laneWidth);
            lane += 1;
        }
    }
}
