using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
  public enum ToolbarAction { Default, Select, Attach, Translate, Rotate, Scale }
  private GameController gameController;
  private Vector3 lastPosition;
  private Quaternion lastRotation;
  private Vector3 originalScale;
  private Color standardColor;
  private Color selectColor;
  private Color highlightColor;
  private float ScalingFactor = 20f;
  private float RotationFactor = 1f;
  private GameObject activeObject;
  public GameObject modelTarget;
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

  private ToolbarAction mode;
  public ToolbarAction Mode
  {
    get { return mode; }
    set
    {
      // Debug.Log(value);
      mode = value;
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    mode = ToolbarAction.Default;
    lastPosition = transform.position;
    lastRotation = transform.rotation;
    originalScale = new Vector3();
    standardColor = new Color32(202, 164, 114, 255);
    highlightColor = new Color32(184, 134, 69, 255);
    selectColor = new Color32(71, 121, 186, 255);

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
    if (gameControllerObject != null)
    {
      gameController = gameControllerObject.GetComponent<GameController>();
    }

    if (gameController == null)
    {
      // Debug.Log("Cannot find GameController");
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (activeObject != null)
    {
      switch (Mode)
      {
        case ToolbarAction.Translate:
          TranslateObject();
          break;
        case ToolbarAction.Rotate:
          RotateObject();
          break;
        case ToolbarAction.Scale:
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

    float rotationFactor = RotationFactor;

    activeObject.transform.rotation = transform.rotation;
  }


  private void ScaleObject()
  {
    Debug.Log("Scale");
    // Debug.Log("Lastposition:" + lastPosition);
    // Debug.Log("Position:" + transform.position);
    float scalingFactor = ScalingFactor;
    float deltaThreshold = 0.001f;
    // Debug.Log(transform.position.y - lastPosition.y);
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
      highlightedObject.GetComponent<Renderer>().material.color = standardColor;
    }

    highlightedObject = hlObject;

    if (highlightedObject != null)
    {
      highlightedObject.GetComponent<Renderer>().material.color = highlightColor;
    }

  }

  public void ConfirmSelection()
  {
    // Debug.Log("ConfirmSelection");
    activeObject = highlightedObject;
    originalScale = activeObject.transform.localScale;
    activeObject.GetComponent<Renderer>().material.color = selectColor;
    highlightedObject = null;
    Mode = ToolbarAction.Select;
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
    activeObject.GetComponent<Renderer>().material.color = standardColor;
    activeObject = null;
    originalScale = new Vector3();
    Mode = ToolbarAction.Default;
  }

  public void Detach()
  {
    // Debug.Log("detach");
    activeObject.transform.parent = modelTarget.transform;
    EndSelection();
  }

  public void Attach()
  {
    // Debug.Log("attach");
    ConfirmSelection();
    activeObject.transform.parent = transform.parent;
    Mode = ToolbarAction.Attach;
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("collision");
    if (activeObject == null)
    {
      HighlightObject(other.gameObject);
    }
  }

  private void OnTriggerExit(Collider other)
  {
    Debug.Log("exit");
    if (highlightedObject != null)
    {
      HighlightObject(null);
    }
  }
}
