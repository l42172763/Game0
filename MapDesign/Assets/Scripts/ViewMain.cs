using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMain : MonoBehaviour
{
    ControllerMain m_ControllerMain;
    // Start is called before the first frame update

    public UISprite Skill;
    void Start()
    {
        m_ControllerMain = GameObject.Find("ScenesController").GetComponent<ControllerMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(m_ControllerMain.OnePointColliderObject()!=null)
            {
                string onClickName = m_ControllerMain.OnePointColliderObject().name;
                Debug.Log(onClickName + "view");
                m_ControllerMain.ButtonImageOnClick(onClickName);
                
            }
        }
        
    }
}
