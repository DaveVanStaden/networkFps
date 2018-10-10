using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerThrowNade : NetworkBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject nade;

    [SerializeField]
    private Transform hand;

    private Vector3 handPos;
    private Quaternion handRot;

    private bool throwable = true;
    private float tbn; //Time between nades

    [SerializeField]
    private float force = 10f;

    [SerializeField]
    private float defaultTbn = 1f;

    void Start()
    {
        tbn = defaultTbn;
    }

    // Update is called once per frame
    void Update () {
        if (player.GetComponent<NetworkIdentity>().isLocalPlayer == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q) && throwable)
        {
            Debug.Log("Throws nade");
            CmdThrowNade();
        }

        if (tbn <= 0)
        {
            throwable = true;
            tbn = defaultTbn;
        }
        else if(throwable == false)
        {
            tbn -= Time.deltaTime;
        }
    }

    [Command]
    void CmdThrowNade()
    {
        throwable = false;
        GameObject grenade = Instantiate(nade, hand.transform.position, hand.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(hand.transform.forward * force, ForceMode.VelocityChange);

        NetworkServer.Spawn(grenade);
    }
}
