using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WeaponUI : NetworkBehaviour {

    private GameObject ammoUIobj;
    private Text ammoUItext;

    private PlayerShoot shoot;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        ammoUIobj = GameObject.Find("AmmoUI");
        ammoUItext = ammoUIobj.GetComponent<Text>();
        shoot = GetComponent<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update () {
        ammoUItext.text = shoot.currentAmmo + "/" + shoot.maxAmmo + " ";
	}
}
