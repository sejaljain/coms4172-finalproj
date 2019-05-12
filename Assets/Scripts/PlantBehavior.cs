using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlantBehavior : MonoBehaviour
{

    public GameObject babyPlant;
    public GameObject childPlant;
    public GameObject grownPlant;
    public GameObject yeildPlant;

    private int state;
    private int clock;

    private System.Random prng;
    
    // Start is called before the first frame update
    void Start() {
    clock = 0;
    state = 0;

    int seed = (int)(
        this.transform.position.x +
        this.transform.position.y + 
        this.transform.position.z + 
        this.transform.rotation.x +
        this.transform.rotation.y +
        this.transform.rotation.z
        );

    prng = new System.Random(seed);

    babyPlant.SetActive(false);
    childPlant.SetActive(false);
    grownPlant.SetActive(false);
    yeildPlant.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    int num = prng.Next(10);
    clock = num % 2 == 0 ? 0 : clock + num;

    if (clock > 30 && state < 4) {
        state += 1;
        clock = 0;
        switch (state) {
        case 0: 
            babyPlant.SetActive(false);
            childPlant.SetActive(false);
            grownPlant.SetActive(false);
            yeildPlant.SetActive(false);
            break;
        case 1: 
            babyPlant.SetActive(true);
            childPlant.SetActive(false);
            grownPlant.SetActive(false);
            yeildPlant.SetActive(false);
            break;
        case 2:
            babyPlant.SetActive(false);
            childPlant.SetActive(true);
            grownPlant.SetActive(false);
            yeildPlant.SetActive(false);
            break;
        case 3:
            babyPlant.SetActive(false);
            childPlant.SetActive(false);
            grownPlant.SetActive(true);
            yeildPlant.SetActive(false);
            break;
        case 4:
            babyPlant.SetActive(false);
            childPlant.SetActive(false);
            grownPlant.SetActive(true);
            yeildPlant.SetActive(true);
            break;
        }
    }
    }
}