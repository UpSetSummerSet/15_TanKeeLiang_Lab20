using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject goalPrefabs;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 2.0f, Random.Range(minZ, maxZ));

        Instantiate(goalPrefabs, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(RGoalScript.isTouch == true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 2.0f, Random.Range(minZ, maxZ));

            Instantiate(goalPrefabs, spawnPosition, Quaternion.identity);

            RGoalScript.isTouch = false;
        }
    }

    public void GoalSpawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 2.0f, Random.Range(minZ, maxZ));

        Instantiate(goalPrefabs, spawnPosition, Quaternion.identity);
    }
}
