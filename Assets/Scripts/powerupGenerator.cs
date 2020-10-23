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

        if (currentModT != lastModT){
            //Do powerup setup at LastModT - behind the player (or offset by more to give more space)
            PlacePowerups(fPI*lastModT/4f);

            lastModT = currentModT;
        }
    }

    /*
    @Input float t : the location in radians on the circle, non modulated
    */
    void PlacePowerups(float t){
        //Calculate pos
        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;

        //Remove existing powerups at the area
        Collider[] hits = Physics.OverlapSphere(new Vector3(0f, y, z), 4f);
        foreach (var collision in hits)
        {
            if (collision.tag == "Spike" || collision.tag == "Powerup"){
                collision.GetComponent<powerupController>().removePowerup();
            }
        }


        //Add powerups at t
        int index1 = rnd.Next(-1,2);
        int index2 = rnd.Next(-1,2);
        while (index1 == index2){
            index2 = rnd.Next(-1,2);
        }
        int index3 = ((-1)*index1) - index2;
        // Debug.Log("Generated: " + index1 + " : " + index2 + " : " + index3);

        //Powerup
        GameObject powerup = Instantiate(powerupPrefab, spawnParent);
        powerup.transform.position = new Vector3(trackWidth*index1,y,z);

        //Spikes
        int numSpikes = rnd.Next(0,3);

        if(numSpikes > 0){
            GameObject spike = Instantiate(spikePrefab, spawnParent);
            spike.transform.position = new Vector3(trackWidth*index2,y,z);
        }
        if(numSpikes > 1){
            GameObject spike = Instantiate(spikePrefab, spawnParent);
            spike.transform.position = new Vector3(trackWidth*index3,y,z);
        }
    }
}
