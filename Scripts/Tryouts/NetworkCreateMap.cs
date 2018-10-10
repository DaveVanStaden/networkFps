using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCreateMap : NetworkBehaviour {

    [SerializeField]
    private GameObject map1;

	// Use this for initialization
	void Start () {
        CmdSpawnMap();
	}

    [Command]
    void CmdSpawnMap()
    {
        Debug.Log("spawnMap");
        GameObject map = Instantiate(map1, transform, transform);
        NetworkServer.Spawn(map);
    }
}
