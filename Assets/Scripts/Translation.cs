using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform selectedCorn;
    bool corn_selected;

    void Start()
    {
        corn_selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && corn_selected)
        {
            selectedCorn.transform.position = transform.position;
        }
        else if (Input.GetMouseButtonUp(0) && corn_selected)
        {
            // if corn is not colliding with a basket, destroy the corn and corn_selected = false otherwise up the score
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "corn")
        {
            selectedCorn = other.transform;
            corn_selected = true;
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "corn")
        {
            selectedCorn = null;
            corn_selected = false;
            other.GetComponent<Renderer>().material.color = Color.green;
        }
    }


}
