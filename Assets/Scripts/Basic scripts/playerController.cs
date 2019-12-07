using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float defaultMoveSpeed = 50f;
    public GameObject player;
    public Rigidbody rb;
    Vector3 lookAtMouse;
    Vector3 movement;
    public AudioSource hurtSound;
    public Animation anim;

    private void Awake()
    {
        player = this.gameObject;
        rb = this.GetComponent<Rigidbody>();
        Teleport tPort = gameObject.AddComponent<Teleport>() as Teleport;
        Explosion explo = gameObject.AddComponent<Explosion>() as Explosion;
        ReflectSword rSword = gameObject.AddComponent<ReflectSword>() as ReflectSword;
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        lookAtMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        lookAtMouse.y = this.transform.position.y;
        transform.LookAt(lookAtMouse);

        Camera.main.GetComponent<cameraController>().cameraFollow(this.transform.position);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.y = 0f;
        movement = movement.normalized;
    }
    public void OnPlayerHit()
    {
        hurtSound.Play();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
