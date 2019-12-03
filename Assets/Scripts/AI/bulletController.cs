using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class bulletController : MonoBehaviour
{
    public GameObject target;
    public Vector3 targetPos;
    public Vector3 moveDirection;
    public Ray bulletPath;
    public Rigidbody rb;
    public bool setInitialMovement;
    public int bulletSpeed;

    public int maxReflectionsCount;
    public float maxStepDistance = 200;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ReflectableSurface")
        {
            ShootTowards(targetPos);
        }
        //target.GetComponent<playerController>().OnPlayerHit();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");

        //give the bullet an initial movement towards the pcs position
        rb = GetComponent<Rigidbody>();
        moveDirection = (target.transform.position - this.transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

        //set bullet to look at pc's initial position
        targetPos = target.transform.position;
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);
    }

    public void ShootTowards (Vector3 targetPos)
    {
        //move the bullet towards the intended point
        moveDirection = (targetPos - this.transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);

        //set bullet to look at the point
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);
    }

    //void OnDrawGizmos()
    //{
    //    Handles.color = Color.red;
    //    Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation, 0.5f, EventType.Repaint);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(this.transform.position, 0.25f);

    //    //this might be an issue
    //    DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionsCount);
    //}

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
