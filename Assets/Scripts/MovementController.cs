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
    public float speed = 10f;
    public float laneWidth = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision){
        Debug.Log("Detected collision between " + gameObject.name + " and " + collision.collider.name);
    }

    void OnTriggerEnter(Collider collision){
        Debug.Log("Detected trigger between " + gameObject.name + " and " + collision);
    }

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

        // if(car.position.y > maxHeight){
        //     maxHeight = car.position.y;
        //     Debug.Log(maxHeight);
        // }
    }
}
