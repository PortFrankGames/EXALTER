using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHitboxController : MonoBehaviour
{
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "ReflectableBullet")
        {
            Destroy(transform.parent.gameObject);
        }

        if (bullet.gameObject.tag == "MeleeWeapon")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
