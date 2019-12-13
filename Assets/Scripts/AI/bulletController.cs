using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class bulletController : MonoBehaviour
{
    //use these when making homing bullets
    public bool isHoming = false;
    public GameObject target;

    //bread and butter for making the bullet work
    public Vector3 targetPos;
    public Vector3 moveDirection;
    public Ray bulletPath;
    public Rigidbody rb;
    public int bulletSpeed;

    //use these to have bullets reflect off surfaces
    public int maxReflectionsCount;
    public float maxStepDistance = 200;

    //private void Start()
    //{
    //    target = GameObject.FindWithTag("Player");
    //    targetPos = target.transform.position;

    //    if (isHoming == true)
    //    {
    //        targetPos = target.transform.position;
    //    }

    //    //give the bullet an initial movement towards the targets position
    //    moveDirection = (targetPos - this.transform.position).normalized * bulletSpeed;
    //    rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    //    //rb.AddForce(new Vector3(moveDirection.x, moveDirection.y, moveDirection.z));

    //    //set bullet to look at pc's initial position
    //    targetPos.y = this.transform.position.y;
    //    transform.LookAt(targetPos);
    //}

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public void ShootTowards (Vector3 targetPos)
    {
        Debug.Log("shooting towards" + targetPos);

        //move the bullet towards the intended point
        moveDirection = (targetPos - this.transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        //rb.AddForce(new Vector3(moveDirection.x, moveDirection.y, moveDirection.z));

        //set bullet to look at the point
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);
    }

    //calculate bullet's eventual reflection
    public void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
        }
        else
        {
            position += direction * maxStepDistance;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(startingPosition, position);
        targetPos = position;

        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }
}
