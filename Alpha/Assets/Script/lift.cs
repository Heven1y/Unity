using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    bool storona = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(storona)transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        if(!storona)transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        if (transform.position.y >= 11.68f) {
            storona = false;
        }
        if(transform.position.y <= 4.4f)
        {
            storona = true;
        }
    }
}
