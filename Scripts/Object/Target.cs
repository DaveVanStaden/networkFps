using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Target : NetworkBehaviour {

    [SerializeField]
    private GameObject destroyedVersion;

    [SyncVar]
    [SerializeField]
    private float health = 50f;

    public void TakeDmg(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            CmdDie();
        }
    }

    [Command]
    private void CmdDie()
    {
        GameObject destroyV = Instantiate(destroyedVersion, transform.position, transform.rotation);
        NetworkServer.Spawn(destroyV);
        NetworkServer.Destroy(gameObject);
        Destroy(gameObject);
    }

}
