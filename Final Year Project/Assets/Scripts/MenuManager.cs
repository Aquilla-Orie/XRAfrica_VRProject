using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    static readonly string LOGINPANEL = "LoginPanel";
    static readonly string SIGNUPPANEL = "SignUpPanel";
    static readonly string HOMEPAGEPANEL = "HomepagePanel";
    static readonly string ASSESSMENTPANEL = "AssessmentPanel";
    static readonly string LEARNINGPANEL = "LearningPanel";
    static readonly string TESTPANEL = "TestPanel";


    [SerializeField]
    GameObject[] Panels;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SetPanelActive(LOGINPANEL);
    }

    void SetPanelActive(string panelName)
    {
        foreach(GameObject panel in Panels)
        {
            if(panel.gameObject.transform.name == panelName)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }

    public void BackButton()
    {
        SetPanelActive(HOMEPAGEPANEL);
    }

    public void SignUpSubmit()
    {
        SetPanelActive(LOGINPANEL);
    }

    public void LoginSubmit()
    {
        SetPanelActive(HOMEPAGEPANEL);
    }

    public void LectureModule()
    {
        SetPanelActive(LEARNINGPANEL);
    }

    public void PracticeModule()
    {
        SetPanelActive(ASSESSMENTPANEL);
    }

    public void PracticeArea()
    {
        SetPanelActive(LEARNINGPANEL);
    }

    public void TestModule()
    {
        SetPanelActive(TESTPANEL);
    }

    public void Logout()
    {
        SetPanelActive(LOGINPANEL);
    }

    public void Signup()
    {
        SetPanelActive(SIGNUPPANEL);
    }

    public void OpenInteractiveMenu()
    {
        SceneManager.LoadScene(1);
    }
}
