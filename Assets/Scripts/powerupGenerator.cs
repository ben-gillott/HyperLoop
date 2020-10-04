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
    public float fPI = (float)Math.PI;
    // public List<GameObject> powerups = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        PlacePowerup(0f, 0);
        // Debug.Log((0.5f)*(float)Math.PI);
        PlacePowerup(0.25f*fPI, 0);
        PlacePowerup(0.5f*fPI, 0);
        PlacePowerup(0.75f*fPI, 0);
        PlacePowerup(1f*fPI, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Random rnd = new Random();
    }

    void PlacePowerup(float t, int laneX){
        float x = (float)laneX; //-2, 0, or 2
        float z = radius*(float)Math.Cos(t) + centerZ;
        float y = radius*(float)Math.Sin(t) + centerY;

        GameObject powerup = Instantiate(powerupPrefab, powerupParent);
        powerup.transform.position = new Vector3(x,y,z);
        // powerups.add(powerup);

    }
}
