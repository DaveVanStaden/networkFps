using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NadeExplode : NetworkBehaviour {

    private TerrainDestruction terrainD;

    private float offTime = 3f;
    private float raduis = 8f;
    private float force = 800f;
    private float damage = 300;
    private bool hasExploded = false;

    [SerializeField]
    private GameObject explosion;

    // Use this for initialization
    void Awake()
    {
        terrainD = GetComponent<TerrainDestruction>();
    }

    [ServerCallback]
    void Update()
    {
        if(offTime <= 0 && hasExploded == false)
        {
            Debug.Log("Boom");
            hasExploded = true;
            CmdExplode();
        }
        else if(hasExploded == false)
        {
            offTime -= Time.deltaTime;
        }
    }

    [Command]
    private void CmdExplode()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
        NetworkServer.Spawn(expl);
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, raduis);

        foreach (Collider nearObj in collidersToDestroy)
        {
            Target target = nearObj.GetComponent<Target>();
            PlayerTarget playerTarget = nearObj.GetComponent<PlayerTarget>();
            if (target != null)
            {
                target.TakeDmg(damage);
            }
            if (playerTarget != null)
            {
                playerTarget.TakeDmg(damage);
            }
        }

        foreach (Collider nearTerrain in collidersToDestroy)
        {
            Terrain terrain = nearTerrain.GetComponent<Terrain>();
            if (terrain != null)
            {
                terrainD.DestroyTerrain();
            }
            else
            {
                NetworkServer.Destroy(gameObject);
                Destroy(gameObject);
            }
        }


        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, raduis);

        foreach (Collider nearObj in collidersToMove)
        {
            Rigidbody rb = nearObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, raduis);
            }
        }
    }
}
