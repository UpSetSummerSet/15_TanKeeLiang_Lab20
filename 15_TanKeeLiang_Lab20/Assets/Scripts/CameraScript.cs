using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject PlayerGO;
    Vector3 posOffset = new Vector3(0, 5.0f, -10.0f);
    Vector3 TabOffset = new Vector3(0, 15.0f, 0);

    bool IsTabbed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + TabOffset, 0.1f);
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            IsTabbed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            transform.rotation = Quaternion.Euler(20.0f, 0, 0);
            IsTabbed = false;
        }
        if(IsTabbed == false)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posOffset, 0.1f);
        }
    }
}
