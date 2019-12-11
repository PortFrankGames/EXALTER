using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float shootCooldown;
    public float shootCooldownMax;

    public Vector3 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        mousePos.y = this.transform.position.y;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (shootCooldown <= 0)
                {
                    Shoot();
                    shootCooldown = shootCooldownMax;
                }
            }
        }

        shootCooldown--;
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        bulletInstance.GetComponent<bulletController>().ShootTowards(mousePos);
    }
}
