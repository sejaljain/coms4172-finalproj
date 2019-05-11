using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

  private Dictionary<HandController.HandAction, string[]> helpTextDict;
  public GameObject[] components;
  public GameObject Toolbar;
  public GameObject MachineBase;
  private HandController handController;
  public float ScalingFactor { get; set; }
  public float RotationFactor { get; set; }
  public float TranslationFactor { get; set; }


  // Start is called before the first frame update
  void Start()
  {
    helpTextDict = new Dictionary<HandController.HandAction, string[]>();
    ScalingFactor = 20f;
    RotationFactor = 1f;
    handController = Toolbar.GetComponent<HandController>();
  }

  private void HandleTouch()
  {
    int nbTouches = Input.touchCount;

    if (nbTouches > 0)
    {
      for (int i = 0; i < nbTouches; i++)
      {
        Touch touch = Input.GetTouch(i);
        switch (touch.phase)
        {
          case TouchPhase.Began:
            SelectAction();
            break;
        }
      }
    }
  }

  private void SelectAction()
  {

    HandController.HandAction toolbarMode = handController.Mode;
    switch (toolbarMode)
    {

    }
  }

  void SpawnObject(int element)
  {
    Quaternion spawnRotation = new Quaternion();
    Vector3 spawnPosition = Toolbar.transform.position;
    Instantiate(components[element], spawnPosition, spawnRotation, MachineBase.transform);
    Debug.Log("Object spawned");

  }


  // Update is called once per frame
  void Update()
  {

    HandleTouch();
    //HandleTouchSym();
  }

  private void HandleTouchSym()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      SelectAction();
    }


  }
}
