using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGoalScript : MonoBehaviour
{
    public static bool isTouch = false;
    bool isSpawned = false;
    Vector3 posOffset = new Vector3(0, 1.5f, 0);

    public ParticleSystem mushroomPrefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            Instantiate(mushroomPrefabs, transform.position + posOffset, Quaternion.identity);

            isSpawned = true;

            if (isSpawned == true)
            {
                Destroy(gameObject);

                isTouch = true;
            }
        }
    }
}
