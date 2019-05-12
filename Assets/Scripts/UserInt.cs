using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInt : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
         camera = Camera.main;
    }

    // Update is called once per frame
    public void Update()
    {
    
        transform.LookAt(camera.transform, camera.transform.rotation * Vector3.up);

    }
}
