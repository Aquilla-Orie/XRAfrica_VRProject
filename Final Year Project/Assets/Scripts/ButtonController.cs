using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonController : MonoBehaviour
{
    public PlacementObject obj { get; set; } //Object for which this button controlls


    List<ButtonController> buttonControllers;

    public void SelectObject()
    {
        buttonControllers = FindObjectsOfType<ButtonController>().ToList();
        buttonControllers.Select(c => { c.obj.isSelected = false; return c; }).ToList();
        obj.isSelected = true;
        Debug.Log(obj.transform.name + " has been selected");
    }

    private void Update()
    {
        if (!obj.isSelected)
        {
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
