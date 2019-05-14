using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform selectedCorn;
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
                    Debug.Log("score up");
                    // up the score
                }
            }

            if (!inBasket)
            {
                Destroy(selectedCorn);
            }

            corn_selected = false;
            selectedCorn = null;

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
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }


}
