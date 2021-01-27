using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject wallPrefabs;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnWall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWall()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));

        Instantiate(wallPrefabs, spawnPosition, Quaternion.identity);
    }
}
