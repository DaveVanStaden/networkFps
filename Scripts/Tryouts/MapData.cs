using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapData : NetworkBehaviour {

    [SerializeField]
    private GameObject map;

    [SerializeField]
    private GameObject terrain;

    public override void OnStartServer()
    {
        //NetworkServer.Spawn(map);
        GameObject terrainNet = Instantiate(terrain, transform.position, transform.rotation);
        NetworkServer.Spawn(terrainNet);
    }
}
