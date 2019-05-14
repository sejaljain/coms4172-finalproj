using System.Collections;
using System.Collections.Generic;
using GoogleVR.HelloVR;
using UnityEngine;

public class Translation : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject selectedCorn;
    bool corn_selected;
    GameObject[] baskets;

    void Start()
    {
        corn_selected = false;
        baskets = GameObject.FindGameObjectsWithTag("basket");
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
            Collider cornCollider = selectedCorn.GetComponent<Collider>();

            bool inBasket = false;
            foreach (GameObject b in baskets)
            {
                Collider basketCollider = b.GetComponent<Collider>();
                inBasket = cornCollider.bounds.Intersects(basketCollider.bounds);

                if (inBasket)
                {
                    selectedCorn.GetComponent<Renderer>().material.color = Color.green;
                    selectedCorn.GetComponent<ObjectController>().UpdateScore();


                    Debug.Log("score up");
                    // up the score
                }
            }

            corn_selected = false;
            selectedCorn = null;

            if (!inBasket)
            {
                Destroy(selectedCorn);
            }



        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "corn")
        {
            selectedCorn = other.gameObject;
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
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }


}
