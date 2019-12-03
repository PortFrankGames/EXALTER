using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectSwordHitbox : MonoBehaviour
{
   private void OnTriggerEnter(Collider bullet)
    {
        Debug.Log("entering trigger");
        //activate the bullet's reflection script with the reflection target
        if (bullet.gameObject.tag == "ReflectableBullet")
        {
            Debug.Log("shooting reflection");
            bullet.GetComponent<bulletController>().ShootTowards(GetComponentInParent<ReflectSwordController>().reflectionTargetPos);
        }
    }
}
