using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportPosOffset;

    public bool explosionAfterTeleport;

    private void Start()
    {
        explosionAfterTeleport = true;
        teleportPosOffset = -5f;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetButton("LeftShift"))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    TeleportPower(hit.point);
                }
            }
        }
    }

    public void TeleportPower(Vector3 teleportPos)
    {
        teleportPos.y = teleportPos.y - teleportPosOffset;
        this.transform.position = teleportPos;
        Debug.Log("teleporting");

        if (explosionAfterTeleport == true)
        {
            Explosion explo = GetComponent<Explosion>();
            explo.ExplosionPower(teleportPos, 5, 500, 5);
            Debug.Log("exploding after teleport!");
        }
    }
}
