using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectSwordController : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 reflectionTargetPos;

    //line renderer vars
    public LineRenderer trajecLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    //trail renderer vars
    public GameObject trailRendererParent;
    public TrailRenderer trailRenderer;

    void Start()
    {
        trajecLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        trailRendererParent = GameObject.Find("SwordTrail");
        trailRenderer = trailRendererParent.GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
    }

    private void Update()
    {
        //get the target of the reflection
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        mousePos.y = this.transform.position.y;

        if (Input.GetMouseButton(1))
        {
            this.GetComponentInParent<playerController>().moveSpeed = 15f; 
            trajecLineRenderer.enabled = true;
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, (Quaternion.Euler(0, -325, 0) * -transform.forward), out hit))
            {
                reflectionTargetPos = hit.point;
                trajecLineRenderer.SetPosition(0, this.transform.position);
                trajecLineRenderer.SetPosition(1, hit.point);
            }

            if (Input.GetMouseButtonDown(0))
            {
                trailRenderer.enabled = true;
                foreach (Transform child in transform)
                {
                    Debug.Log("enabling " + child);
                    child.GetComponent<Collider>().enabled = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                trailRenderer.enabled = false;
                foreach (Transform child in transform)
                {
                    Debug.Log("disabling " + child);
                    child.GetComponent<Collider>().enabled = false;
                }
            }

        }
        else
        {
            trajecLineRenderer.enabled = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            this.GetComponentInParent<playerController>().moveSpeed = this.GetComponentInParent<playerController>().defaultMoveSpeed;
            foreach (Transform child in transform)
            {
                Debug.Log("destroy " + child);
                Destroy(this.gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawLine(this.transform.position, Vector3.Cross(mousePos, transform.up));
    }
}
