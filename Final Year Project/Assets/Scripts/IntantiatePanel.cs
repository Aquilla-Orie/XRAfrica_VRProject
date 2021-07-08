using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class IntantiatePanel : MonoBehaviour
{
    [SerializeField]
    PlacementObject[] objects;

    [SerializeField]
    GameObject controlPanel;

    ButtonController buttonController;

    [SerializeField]
    GameObject ARCamera;

    GameObject selectedObject;

    private void Start()
    {
        buttonController = Resources.Load<ButtonController>("ObjButton");
    }
    public void InstantiateObject(int objectIndex)
    {
        PlacementObject obj1 = Instantiate(objects[objectIndex], PlacementController.RayCastToWorld().position + Vector3.one, Quaternion.identity);
        ButtonController button1 = Instantiate(buttonController);
        button1.transform.parent = controlPanel.transform;
        button1.obj = obj1;
    }
}
