using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterController : MonoBehaviour
{
  private float rotationSpeed;
  // Start is called before the first frame update
  void Start()
  {
    rotationSpeed = 0f;
  }

  // Update is called once per frame
  void Update()
  {
    if (this.rotationSpeed > 0)
    {
      Vector3 center = GetComponent<Renderer>().bounds.center;
      //transform.Rotate(Vector3.right * angle * Time.deltaTime);
      transform.RotateAround(center, Vector3.up, this.rotationSpeed * Time.deltaTime);
    }

  }

  public void SetRotationSpeed(float speed)
  {
    this.rotationSpeed = speed;
  }
}
