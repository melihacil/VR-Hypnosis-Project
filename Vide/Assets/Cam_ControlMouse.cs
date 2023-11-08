using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_ControlMouse : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private float m_sensitivity;

    // Update is called once per frame
    void Update()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * m_sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        transform.RotateAround(Vector3.zero, transform.right, rotateVertical * m_sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
    }
}
