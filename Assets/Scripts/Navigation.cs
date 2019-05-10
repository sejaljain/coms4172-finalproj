using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Vector3 lastPosition;
    public Camera main_cam;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {

    }


}
