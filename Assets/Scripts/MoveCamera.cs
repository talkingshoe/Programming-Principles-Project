using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//taken from DaveGameDev on YT

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        //makes the camera always move with the player
        transform.position = cameraPosition.position;  
    }
}
