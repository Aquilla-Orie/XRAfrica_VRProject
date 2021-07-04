using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveController : MonoBehaviour
{
    bool isObjectOpen;
    bool isRotating;

    //[SerializeField]
    //GameObject mechanim;
    //Animator mechanimAnimator;

    bool isInstPanelOpen;
    [SerializeField]
    GameObject instantiatePanel;
    Animator instantiatePanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isObjectOpen = false;
        isInstPanelOpen = false;
        isRotating = false;

        //mechanimAnimator = mechanim.GetComponent<Animator>();
        instantiatePanelAnimator = instantiatePanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateMech()
    {
        //isObjectOpen = !isObjectOpen;
        //mechanimAnimator.SetBool("isOpen", isObjectOpen);
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
