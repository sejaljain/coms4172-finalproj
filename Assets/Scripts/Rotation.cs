using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform selectedPlanter;
    bool planter_selected;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float initialDistance;

    void Start()
    {
        planter_selected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && planter_selected)
        {
            float dist = Vector3.Distance(selectedPlanter.transform.position, transform.position);

            Vector3 center = selectedPlanter.GetComponent<Renderer>().bounds.center;
            transform.RotateAround(center, Vector3.up, dist * Time.deltaTime);

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "planter")
        {
            selectedPlanter = other.transform;
            planter_selected = true;
            other.GetComponent<Renderer>().material.color = Color.cyan;

            initialPosition = other.transform.position;
            initialRotation = other.transform.rotation;

            // initial distance between two points
            initialDistance = Vector3.Distance(other.transform.position, transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "planter")
        {
            selectedPlanter = null;
            planter_selected = false;
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }


}
