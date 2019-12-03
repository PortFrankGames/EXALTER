using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius;
    public float power;

    public int oldLayer;

    public ParticleSystem ps;

    public bool explosionClick;

    public int i;

    private void Start()
    {
        explosionClick = false;
        i = 0;
        oldLayer = gameObject.layer;
    }

    private void Update()
    {      
        
    }

    private void FixedUpdate()
    {
        if(explosionClick == true)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("holding down shift");
                if (Input.GetMouseButtonDown(0))
                {
                    ExplosionPower(this.transform.position, 50, 500, 5); ;
                }
            }
        }
    }

    public void ExplosionPower(Vector3 explosionPos, float radius, float power, float upwardsModifier)
    {
        //exclude player from explosion calculation
        Rigidbody playerRb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
        playerRb.useGravity = false;
        playerRb.constraints = RigidbodyConstraints.FreezeRotation;

        //make the explosion happen
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        gameObject.layer = oldLayer;
        foreach (Collider hit in colliders)
        {
            i++;
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upwardsModifier);
        }

        //instantiate explosion particles prefab then make its radius the same as the explosion's
        ps = Instantiate(Resources.Load("Explosion_particles"), explosionPos, Quaternion.Euler(90, 0, 0)) as ParticleSystem;
        var sh = ps.shape;
        sh.radius = radius;

        //make player use gravity again once explosion is done calculating
        if (i == colliders.Length)
        {
            i = 0;
            Debug.Log("gravity being used again");
            playerRb.useGravity = true;
            playerRb.constraints = RigidbodyConstraints.None;
        }

        //DEBUG
        Debug.Log("exploding" + colliders.Length);
    }

}
