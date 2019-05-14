using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    // Start is called before the first frame update
    Transform selectedBasket;
    bool basket_selected;

    void Start()
    {
        basket_selected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && basket_selected)
        {
            float dist = Vector3.Distance(selectedBasket.transform.position, transform.position);
            selectedBasket.transform.localScale = new Vector3(dist, dist, dist);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "basket")
        {
            selectedBasket = other.transform;
            basket_selected = true;
            other.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "basket")
        {
            selectedBasket = null;
            basket_selected = false;
        }
    }


}
