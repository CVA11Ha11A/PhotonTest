using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ItemSpawner : MonoBehaviourPun
{
    public GameObject spawnRange;

    private BoxCollider spawnRangeCollider;

    public GameObject hpPotion;
    private GameObject hpPotionClone;



    private float range_X;
    private float range_Z;
    private float spawnTime;


    void Start()
    {
        spawnRangeCollider = spawnRange.GetComponent<BoxCollider>();

        
    }

    
    void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 3)
        {
            ItemSpawn();
        }
    }

    private void ItemSpawn()
    {
        hpPotionClone = Instantiate(hpPotion, RandomSpawnPosition(), Quaternion.identity);
    }


    private Vector3 RandomSpawnPosition()
    {
        Vector3 originPosition = spawnRangeCollider.transform.position;

        range_X = spawnRangeCollider.bounds.size.x;
        range_Z = spawnRangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 randomPotision = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPotision = originPosition - randomPotision;

        return respawnPotision;

    }


}
