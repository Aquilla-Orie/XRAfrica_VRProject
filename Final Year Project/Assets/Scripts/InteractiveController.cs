using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractiveController : MonoBehaviour
{
    bool isObjectOpen;
    bool isRotating;

    //[SerializeField]
    List<GameObject> mechanims;
    Animator mechanimAnimator;

    bool isInstPanelOpen;
    [SerializeField]
    GameObject instantiatePanel;
    Animator instantiatePanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        isObjectOpen = false;
        isInstPanelOpen = false;
        isRotating = false;

        mechanims = new List<GameObject>();

        
        instantiatePanelAnimator = instantiatePanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateMech()
    {
        mechanims.Clear();
        mechanims = GameObject.FindGameObjectsWithTag("PlacementObject").ToList();

        foreach (GameObject mechanim in mechanims)
        {
            mechanimAnimator = mechanim.GetComponent<Animator>();
            isObjectOpen = !isObjectOpen;
            mechanimAnimator.SetBool("isOpen", isObjectOpen);
        }
    }

    public void RotateMech()
    {
        isRotating = true;
    }

    public void OpenInstantiatePanel()
    {
        isInstPanelOpen = !isInstPanelOpen;
        if (isInstPanelOpen)
        {
            instantiatePanel.gameObject.SetActive(true);
        }
        else
        {
            instantiatePanelAnimator.SetTrigger("open");
            StartCoroutine(CloseInstantiationPanel(instantiatePanel));
        }
    }

    IEnumerator CloseInstantiationPanel(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }

}
