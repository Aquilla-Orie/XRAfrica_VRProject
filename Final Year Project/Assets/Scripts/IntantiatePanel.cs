using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntantiatePanel : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;
    

    [SerializeField]
    Button obj1Button;
    [SerializeField]
    Button obj2Button;
    [SerializeField]
    Button obj3Button;

    [SerializeField]
    GameObject ARCamera;

    GameObject selectedObject;
    public void InstantiateObject1()
    {
        GameObject obj1 = Instantiate(objects[0], new Vector3(ARCamera.transform.position.x, ARCamera.transform.position.y, ARCamera.transform.position.z + 3), Quaternion.identity);
        obj1Button.interactable = true;
    }
    public void InstantiateObject2()
    {
        GameObject obj2 = Instantiate(objects[1], new Vector3(ARCamera.transform.position.x, ARCamera.transform.position.y + 1, ARCamera.transform.position.z + 3), Quaternion.identity);
        obj2Button.interactable = true;
    }
    public void InstantiateObject3()
    {
        GameObject obj3 = Instantiate(objects[2], new Vector3(ARCamera.transform.position.x, ARCamera.transform.position.y - 1, ARCamera.transform.position.z + 3), Quaternion.identity);
        obj3Button.interactable = true;
    }

    public void SelectObject1()
    {
        selectedObject = objects[0];
        foreach (GameObject obj in objects)
        {
            if (obj != selectedObject)
            {
                obj.GetComponent<Material>().color = Color.white;
            }
            selectedObject.GetComponent<Material>().color = Color.yellow;
        }
    }
    public void SelectObject2()
    {
        selectedObject = objects[1];
        foreach (GameObject obj in objects)
        {
            if (obj != selectedObject)
            {
                obj.GetComponent<Material>().color = Color.white;
            }
            selectedObject.GetComponent<Material>().color = Color.yellow;
        }
    }
    public void SelectObject3()
    {
        selectedObject = objects[3];
        foreach (GameObject obj in objects)
        {
            if (obj != selectedObject)
            {
                obj.GetComponent<Material>().color = Color.white;
            }
            selectedObject.GetComponent<Material>().color = Color.yellow;
        }
    }

}
