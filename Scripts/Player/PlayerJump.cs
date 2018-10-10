using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerJump : NetworkBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            return;
        }
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Debug.DrawRay(this.transform.position, -this.transform.up);
    }

    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 1.1f))
        {
            Debug.Log("ground?");
            rb.AddForce(transform.up * 275f);
            
        }
    }
}
