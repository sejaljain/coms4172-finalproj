using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 0.1f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // Get the horizontal and vertical axis.
    // By default they are mapped to the arrow keys.
    // The value is in the range -1 to 1
    float xMove = Input.GetAxis("Horizontal") * speed;
    float zMove = Input.GetAxis("Vertical") * speed;


    // Move translation along the object's z-axis
    transform.Translate(xMove, 0, zMove);

  }
}
