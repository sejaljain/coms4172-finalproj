using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
  public enum HandAction { Default, Select, Attach, Rotate, Scale }
  private GameController gameController;
  private Vector3 lastPosition;
  private Quaternion lastRotation;
  private Vector3 originalScale;
  private Color selectColor;
  private Color highlightColor;

  private float scalingFactor;
  private float rotationFactor;
  private GameObject activeObject;
  public GameObject machineBaseTarget;
  public GameObject ActiveObject
  {
    get { return activeObject; }
    set { activeObject = value; }
  }
  private GameObject highlightedObject;
  public GameObject HighlightedObject
  {
    get { return highlightedObject; }
    set { highlightedObject = value; }
  }

  private HandAction mode;
  public HandAction Mode
  {
    get { return mode; }
    set
    {
      mode = value;
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    scalingFactor = 20f;
    rotationFactor = 1f;
    mode = HandAction.Default;
    lastPosition = transform.position;
    lastRotation = transform.rotation;
    originalScale = new Vector3();
    highlightColor = new Color32(0, 128, 128, 255);
    selectColor = new Color32(71, 121, 186, 255);

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
    if (gameControllerObject != null)
    {
      gameController = gameControllerObject.GetComponent<GameController>();
    }

    if (gameController == null)
    {
      Debug.Log("Cannot find GameController");
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (activeObject != null)
    {
      switch (Mode)
      {
        case HandAction.Rotate:
          RotateObject();
          break;
        case HandAction.Scale:
          ScaleObject();
          break;
      }
    }
    lastPosition = transform.position;
  }

  private void TranslateObject()
  {
    // Debug.Log("Translate");
    Vector3 delta = transform.position - lastPosition;
    activeObject.gameObject.transform.position += delta;
  }

  private void RotateObject()
  {
    // Debug.Log("Rotate");
    activeObject.transform.rotation = transform.rotation;
  }

  private void ScaleObject()
  {
    Debug.Log("Scale");

    float deltaThreshold = 0.001f;

    if (Mathf.Abs(transform.position.y - lastPosition.y) > deltaThreshold)
    {
      float deltaSize = Mathf.Min(Mathf.Max(1 + (transform.position.y - lastPosition.y) * scalingFactor, 0.2f), 4f);
      activeObject.transform.localScale *= deltaSize;
    }

  }

  private void HighlightObject(GameObject hlObject)
  {
    if (highlightedObject != null)
    {
      highlightedObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
    }

    highlightedObject = hlObject;

    if (highlightedObject != null)
    {
      highlightedObject.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

  }

  public void ConfirmSelection()
  {
    // Debug.Log("ConfirmSelection");
    activeObject = highlightedObject;
    originalScale = activeObject.transform.localScale;
    activeObject.GetComponent<Renderer>().material.color = selectColor;
    highlightedObject = null;
    Mode = HandAction.Select;
  }

  public void DeleteSelection()
  {
    // Debug.Log("DeleteSelection");
    if (activeObject != null)
    {
      Destroy(activeObject);
      activeObject = null;
    }
  }

  public void EndSelection()
  {
    // Debug.Log("EndSelection");
    activeObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse"); ;
    activeObject = null;
    originalScale = new Vector3();
    Mode = HandAction.Default;
  }

  public void Detach()
  {
    // Debug.Log("detach");
    activeObject.transform.parent = machineBaseTarget.transform;
    EndSelection();
  }

  public void Attach()
  {
    // Debug.Log("attach");
    ConfirmSelection();
    activeObject.transform.parent = transform.parent;
    Mode = HandAction.Attach;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (activeObject == null)
    {
      HighlightObject(other.gameObject);
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (highlightedObject != null)
    {
      HighlightObject(null);
    }
  }
}
