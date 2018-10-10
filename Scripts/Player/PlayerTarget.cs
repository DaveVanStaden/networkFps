using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerTarget : NetworkBehaviour {

    [SerializeField]
    private GameObject destroyedVersion;

    [SyncVar]
    private float health = 200f;

    public void TakeDmg(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            CmdDie();
        }
    }

    [Command]
    private void CmdDie()
    {
        GameObject destroyV = Instantiate(destroyedVersion, transform.position, transform.rotation);
        NetworkServer.Spawn(destroyV);
        health = 200f;
    }
}
