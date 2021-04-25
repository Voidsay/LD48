using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHandle : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Variables.paused)
        {
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * Variables.MS * Variables.InvMX, 0);

            var temp = cam.transform.rotation;

            cam.transform.localRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * Variables.MS * Variables.InvMY, 0, 0);
            if (Vector3.Angle(transform.forward, cam.transform.forward) > 90)
            {
                cam.transform.rotation = temp;
            }
        }
    }
}
