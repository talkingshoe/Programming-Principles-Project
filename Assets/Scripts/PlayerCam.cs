using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//taken from DaveGameDev on YT
public class PlayerCam : MonoBehaviour
{
    //custom sensitivity values
    public float sensX;
    public float sensY;

    //pc object
    public Transform orientation;

    //camera rotation
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        //lock mouse cursor to centre and make invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //var to hold mouse input multiplied by time and custom sense vars
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //???
        yRotation += mouseX;
        xRotation -= mouseY;

        //restrict rotation to only 90deg up&down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //first is camera object's rotation change, second is pc obj
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
