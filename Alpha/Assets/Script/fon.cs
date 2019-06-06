using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fon : MonoBehaviour
{
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        transform.position = new Vector3(camera.position.x, camera.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camera.position.x, camera.position.y, transform.position.z);
    }
}
