﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ImageAnchor : MonoBehaviour
{


    [SerializeField]
    private ARReferenceImage referenceImage;

    [SerializeField]
    private GameObject prefabToGenerate;

    private GameObject imageAnchorGO;

    public Camera mainCam;
    
    // Use this for initialization
    void Start()
    {
        UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
        UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpdateImageAnchor;
        //UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;

    }

    void AddImageAnchor(ARImageAnchor arImageAnchor)
    {
        Debug.LogFormat("image anchor added[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        if (arImageAnchor.referenceImageName == referenceImage.imageName)
        {
            Vector3 position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
            Quaternion rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);

            imageAnchorGO = Instantiate<GameObject>(prefabToGenerate, position, rotation);
            imageAnchorGO.transform.position = mainCam.transform.position + mainCam.transform.forward;
        }
    }

    void UpdateImageAnchor(ARImageAnchor arImageAnchor)
    {
        Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        if (arImageAnchor.referenceImageName == referenceImage.imageName)
        {
            if (arImageAnchor.isTracked)
            {
                if (!imageAnchorGO.activeSelf)
                {
                    imageAnchorGO.SetActive(true);
                }
                //imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                //imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);
                imageAnchorGO.transform.position = 0.2f*mainCam.transform.position + 0.8f*UnityARMatrixOps.GetPosition(arImageAnchor.transform) + 1.5f*mainCam.transform.forward;
            }
            else if (imageAnchorGO.activeSelf)
            {
                imageAnchorGO.SetActive(false);
            }
        }

    }

    //void RemoveImageAnchor(ARImageAnchor arImageAnchor)
    //{
    //    Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
    //    if (imageAnchorGO)
    //    {
    //        GameObject.Destroy(imageAnchorGO);
    //    }

    //}

    //void OnDestroy()
    //{
    //    UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
    //    UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpdateImageAnchor;
    //    UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;

    //}

    // Update is called once per frame
    void Update()
    {

    }
}
