using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public float speed = 20f;
    private float moveVert;
    private float moveHor;

    private Vector3 movement;

    Rigidbody rb;

    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        moveVert = Input.GetAxis("Vertical");
        moveHor = Input.GetAxis("Horizontal");


        movement = new Vector3(moveHor * speed, 0.0f, moveVert * speed);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        rb.MovePosition(transform.position + movement);

        if(transform.position.y <= -50)
        {
            rb.MovePosition(transform.position + new Vector3(0,200,0));
        }
    }
}
