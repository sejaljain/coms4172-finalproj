using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

  private Dictionary<HandController.HandAction, string[]> helpTextDict;
  public GameObject[] components;
  public GameObject Hand;
  public GameObject MachineBase;
  private HandController handController;


  // Start is called before the first frame update
  void Start()
  {
    helpTextDict = new Dictionary<HandController.HandAction, string[]>();

    handController = Hand.GetComponent<HandController>();
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

    HandController.HandAction handMode = handController.Mode;
    switch (handMode)
    {
      case HandController.HandAction.Select:
        handController.Attach();
        break;
      case HandController.HandAction.Attach:
        handController.Detach();
        break;
      case HandController.HandAction.Scale:
      case HandController.HandAction.Rotate:
        handController.EndSelection();
        break;
    }
  }

  void SpawnObject(int element)
  {
    Quaternion spawnRotation = new Quaternion();
    Vector3 spawnPosition = Hand.transform.position;
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
