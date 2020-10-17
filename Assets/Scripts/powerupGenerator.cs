using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class powerupGenerator : MonoBehaviour
{
    public float radius;
    public float centerZ = 0f;
    public float centerY;
    public GameObject powerupPrefab;
    public GameObject spikePrefab;
    public GameObject player;
    public Transform spawnParent;
    public float trackWidth = 3f;
    private float fPI = (float)Math.PI;
    System.Random rnd = new System.Random();
    private float lastModT = 5; //Starts at low point of loop
    private float currentModT = 6;

    // Start is called before the first frame update
    void Start()
    {
        PlacePowerups(0f);
        PlacePowerups(0.25f*fPI);
        PlacePowerups(0.5f*fPI);
        PlacePowerups(0.75f*fPI);
        PlacePowerups(1f*fPI);
        PlacePowerups(1.25f*fPI);
        // PlacePowerups(1.5f*fPI); //Low point
        PlacePowerups(1.75f*fPI);
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn powerups at set intervals
        float t = player.GetComponent<MovementController>().getT();
        

        currentModT = (float)Math.Floor(4f*((t/fPI)%2f));

        Debug.Log(currentModT);

        if (currentModT != lastModT){
            //Do powerup setup at LastModT - behind the player (or offset by more to give more space)


            lastModT = currentModT;
        }
    }

    /*
    @Input float t : the location in radians on the circle, non modulated
    */
    void PlacePowerups(float t){
        float x = trackWidth*(((int)rnd.Next(3)) - 1);
        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;

        //Remove existing powerups at the area


        //Add powerup
        GameObject powerup = Instantiate(powerupPrefab, spawnParent);
        powerup.transform.position = new Vector3(x,y,z);
        

        //Temp - add spike to the left
        GameObject spike = Instantiate(spikePrefab, spawnParent);
        spike.transform.position = new Vector3(x-2f,y,z);
    }
}
