using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkData : NetworkManager {

    public GameObject SniperScopeOverlay;

    [SerializeField]
    private Transform cam;
    [SerializeField]
    private GameObject MainScreen;

    [SerializeField]
    private GameObject terrain;
    [SerializeField]
    private GameObject map;

    private bool canRotate = true;

    public override void OnStartClient( NetworkClient client)
    {
        
    }

    public override void OnStartHost()
    {
        
    }

    public override void OnStopClient()
    {
        
    }

    public override void OnStopHost()
    {
        
    }

    void Update()
    {
        if (!canRotate)
        {
            return;
        }
    }
}
