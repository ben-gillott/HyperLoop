using UnityEngine;

public class CarCamera : MonoBehaviour
{
    [Header("Objects")]
    [Tooltip("Target to snap to")]
    public Transform target; //Player

    [Header("Variables")]
    [Tooltip("Higher value -> faster lock on")]
    public float smoothSpeed = 1; 
    public Vector3 offsetPos;
    public Quaternion offsetRot = Quaternion.identity;

    void LateUpdate() {
        // Vector3 desiredPosition = target.position + offsetPos;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;

        // Quaternion desiredRotation = target.rotation;// + offsetRot;
        // Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        // transform.rotation = desiredRotation;

        // transform.position = target.position - (new Vector3(0f,0f,10f));
        // transform.rotation = target.rotation;


        //Look at where the player currently is
        // transform.LookAt(target);
    }

}