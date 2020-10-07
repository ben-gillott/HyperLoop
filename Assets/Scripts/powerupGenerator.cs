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
    public Transform powerupParent;
    public float trackWidth = 3f;
    private float fPI = (float)Math.PI;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        PlacePowerup(0f);
        PlacePowerup(0.25f*fPI);
        PlacePowerup(0.5f*fPI);
        PlacePowerup(0.75f*fPI);
        PlacePowerup(1f*fPI);
        PlacePowerup(1.25f*fPI);
        // PlacePowerup(1.5f*fPI); //Low point
        PlacePowerup(1.75f*fPI);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: When player passes go - y is less than 1

        //Remove all children

        //Spawn powerups at set intervals
    }

    void PlacePowerup(float t){
        float x = trackWidth*(((int)rnd.Next(3)) - 1);
        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;

        GameObject powerup = Instantiate(powerupPrefab, powerupParent);
        powerup.transform.position = new Vector3(x,y,z);
    }
}
