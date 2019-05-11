using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hotspot : MonoBehaviour, IGvrPointerHoverHandler
{

    private GameObject player;
    private Renderer rend;
    public Material regular;
    public Material hoverOver;
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        rend.material = regular;
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnGvrPointerHover(PointerEventData data)
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse button down");
            GameObject hotspot = data.pointerCurrentRaycast.gameObject;
            //Debug.Log(hotspot.transform.position);
            player.transform.localPosition = hotspot.transform.position;
            //Debug.Log(player.transform.position);
        }
    }


    public void onHotspotHoverEnter()
    {
        Debug.Log("pointer enter");
        rend.material = hoverOver;
    }


    public void onHotspotHoverExit()
    {
        Debug.Log("pointer exit");
        rend.material = regular;
    }




}
