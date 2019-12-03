using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairController : MonoBehaviour
{
    public Vector3 mousePosInWorldSpace;
    public Camera playerCamera;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInWorldSpace.y = 15f;
        this.transform.position = mousePosInWorldSpace;
        //playerCamera.GetComponent<cameraController>().cameraFollow(this.transform.position);
        //Camera.main.GetComponent<cameraController>().cameraFollow(this.transform.position);
        //mousePosInWorldSpace = Input.mousePosition /*Camera.main.ScreenToWorldPoint(Input.mousePosition)*/;
        //Camera.main.GetComponent<cameraController>().cameraFollow(mousePosInWorldSpace);
    }

}
