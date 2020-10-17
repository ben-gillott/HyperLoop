using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupController : MonoBehaviour
{
    public void removePowerup(){
        Destroy(gameObject);
    }
}
