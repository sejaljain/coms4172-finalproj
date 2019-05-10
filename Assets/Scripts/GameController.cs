using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public float speed = 10.0f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    HandleSymInput();
  }

  private void HandleSymInput()
  {
    float horizontalMove = Input.GetAxis("Vertical") * speed;
    float verticalMove = Input.GetAxis("Horizontal") * speed;
  }

}
