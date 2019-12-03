using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ReflectSword : MonoBehaviour
{
    //sword variables
    public Vector3 swordHitboxPos;
    public Object ReflexColliderItem;
    public float swordHitboxOffset;
    public int reflexCooldown;
    public int reflexCooldownMax;
    public int maxStepDistance;
    public Animator anim;
    public bool preparingToStrike;

    //player location variable
    public Transform playerTransform;

    private void Start()
    {
        swordHitboxOffset = 0.45f;
        reflexCooldown = reflexCooldownMax; 
        playerTransform = this.transform;
        anim = GetComponent<Animator>();
        anim.ResetTrigger("SwordSwing");
    }

    private void Update()
    {
        reflexCooldown--;
        reflexCooldown = Mathf.Clamp(reflexCooldown, -5, 100);

        if (Input.GetMouseButtonDown(1))
        {
            preparingToStrike = true;
            swordHitboxPos = playerTransform.position + playerTransform.forward * swordHitboxOffset;
            ReflexColliderItem = Instantiate(Resources.Load("ReflectSwordHitbox"), swordHitboxPos, playerTransform.rotation * Quaternion.Euler(0, 90, 0), transform);
            reflexCooldown = reflexCooldownMax;
        }

        if (Input.GetMouseButtonUp(1))
        {
            preparingToStrike = false;
        }

        if (preparingToStrike == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("setting trigger");
                anim.SetTrigger("SwordSwing");
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("resetting trigger");
                anim.SetTrigger("SwordSwing");
            }
        }

    }
}
