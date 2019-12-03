using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject bullet;

    //the float for the cooldown between shots
    public float shootCooldown;

    //the value the cooldown will be reset to after firing, to start the process again
    public float shootCooldownMax;

    ////where the bullet will be instantiated
    //public Vector3 bulletPos;

    //the player's position without accounting for y axis
    private Transform playerTransform;
    Vector3 playerPos;

    //movement values for speed, distance at which the ai stops before player, distance when ai retreats from player
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        playerPos = playerTransform.position;
        playerPos.y = this.transform.position.y;
        transform.LookAt(playerPos);

        if (Vector3.Distance(this.transform.position, playerTransform.position) > stoppingDistance)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }      
    
        else if (Vector3.Distance(this.transform.position, playerTransform.position) < stoppingDistance && Vector3.Distance(this.transform.position, playerTransform.position) > retreatDistance)
        {
            if (shootCooldown <= 0)
            {
                Shoot();
                shootCooldown = shootCooldownMax;
            }
            else
            {
                shootCooldown--;
            }
        }

        else if (Vector3.Distance(this.transform.position, playerTransform.position) < retreatDistance)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -enemySpeed * Time.deltaTime);
            
            if (shootCooldown <= 0)
            {
                Shoot();
                shootCooldown = shootCooldownMax;
            }
            else
            {
                shootCooldown--;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, this.transform.position, Quaternion.identity);
    }
}
