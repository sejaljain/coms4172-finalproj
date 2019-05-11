using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Camera main_cam;
    private GvrPointerPhysicsRaycaster raycaster;
    private GvrPointerInputModule pointer_module;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
    }


}
