using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerMain : MonoBehaviour
{   
    ViewMain m_ViewMain;
    private bool[] InCD = new bool[12];
    private float[] CD = new float[12];
    GameObject[] mask = new GameObject[12];
    // Start is called before the first frame update
    ModelMain m_ModelMain = ModelMain.Instance;
    //GameObject jiantou;
    GameObject bar;
    GameObject role;
    
    private void Awake()
    {
        //Resources_Get();
        m_ViewMain = GameObject.Find("ScenesController").GetComponent<ViewMain>();


    }


    public GameObject OnePointColliderObject()
    {
        
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray,out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
            return hit.transform.gameObject;
            
        }
            
            
        /*if (result.Count > 0)
            return result[0].gameObject;*/
        else
        {
            Debug.Log("没东西");
            return null;
            
        }
    }
    
    public void ButtonImageOnClick(string onClickName)
    {
        switch(onClickName)
        {
            case "Skill_1":
                Debug.Log(onClickName);
                cd(0);
                break;
            case "Skill_2":
                Debug.Log(onClickName);
                cd(1);
                break;
            case "Skill_3":
                Debug.Log(onClickName);
                cd(2);
                break;
            case "Skill_4":
                Debug.Log(onClickName);
                cd(3);
                break;
            case "Skill_5":
                Debug.Log(onClickName);
                cd(4);
                break;
            case "Skill_6":
                Debug.Log(onClickName);
                cd(5);
                break;
            case "Skill_7":
                Debug.Log(onClickName);
                cd(6);
                break;
            case "Skill_8":
                Debug.Log(onClickName);
                cd(7);
                break;
            case "Skill_9":
                Debug.Log(onClickName);
                cd(8);
                break;
            case "Skill_10":
                Debug.Log(onClickName);
                cd(9);
                break;
            case "Skill_11":
                Debug.Log(onClickName);
                cd(10);
                break;
            case "Skill_12":
                Debug.Log(onClickName);
                cd(11);
                break;
            
        }
    }
    void Start()
    {
        //jiantou = GameObject.Find("jianTou");
        bar = GameObject.Find("MoveBar");
        role = GameObject.Find("tinyplayer");
        for (int i = 0; i < InCD.Length; i++)
        {
            
            string skill = "Skill_" + (i+1);
            mask[i] = GameObject.Find(skill);
            mask[i].GetComponentInChildren<Image>().fillAmount = 0;
            mask[i].GetComponentInChildren<Text>().text = " ";

        }
        for (int i=0;i<InCD.Length;i++)
        {
            InCD[i] = false;
            CD[i] = 2;
        }
    }
    public void cd(int i)
    {
        if(!InCD[i])
        {
            InCD[i] = true;
            Debug.Log(i+"进cd");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
        for (int i =0;i<InCD.Length;i++)
        {
            if(InCD[i])
            {
                Debug.Log(i);
                CD[i] -= Time.deltaTime;
                //mask[i].GetComponent<Image>().fillAmount = CD[i]/2;
                string cd = "" + CD[i];
                mask[i].GetComponentInChildren<Image>().fillAmount = CD[i] / 2;
                mask[i].GetComponentInChildren<Text>().text = cd;
                if (CD[i] <= 0)
                {
                    CD[i] = 2;
                    InCD[i] = false;
                    mask[i].GetComponentInChildren<Text>().text = "";
                }
            }
        }
        

            bar.transform.position = new Vector3(role.transform.position.x, role.transform.position.y+(float)1.5, 0);

        
       // WorldToScreenPos();
    }
    /*void WorldToScreenPos()
    {
        Ray pt = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2 = new RaycastHit();
        Physics.Raycast(pt, out hit2);

        //jiantou.transform.LookAt(Input.mousePosition);
        Vector2 jianTouPos = Camera.main.ViewportToScreenPoint(jiantou.transform.position);
        Vector2 mousePos = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        mousePos.x -= 600;
        mousePos.y -= 300;
        Debug.Log("箭头屏幕坐标：" + jiantou.transform.position);
        Debug.Log("鼠标屏幕坐标：" + Input.mousePosition);
        
        float xiangJianY = hit2.point.y - jianTouPos.y;
        float xiangJianX = hit2.point.x - jianTouPos.x;
        float jianTouRotationZ = 0f;
        if (xiangJianX >= 0)
        {
            if (xiangJianX == 0)
            {
                if (xiangJianY > 0)
                {
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + 90f);
                }
                else if (xiangJianY < 0)
                {
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f - 90f);
                }
                else
                {
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + 90f);
                }
            }
            else
            {
                if (xiangJianY > 0)
                {
                    jianTouRotationZ = Mathf.Atan2(Mathf.Abs(xiangJianY), Mathf.Abs(xiangJianX)) * 180f / Mathf.PI;
                    Debug.Log("角度值：" + jianTouRotationZ);
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + jianTouRotationZ);
                }
                else if (xiangJianY < 0)
                {
                    jianTouRotationZ = Mathf.Atan2(Mathf.Abs(xiangJianY), Mathf.Abs(xiangJianX)) * 180f / Mathf.PI;
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f - jianTouRotationZ);
                }
                else
                {
                    jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f);
                }
            }
        }
        else
        {
            if (xiangJianY > 0)
            {
                jianTouRotationZ = Mathf.Atan2(Mathf.Abs(xiangJianY), Mathf.Abs(xiangJianX)) * 180f / Mathf.PI;
                jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + 180f - jianTouRotationZ);
            }
            else if (xiangJianY < 0)
            {
                jianTouRotationZ = Mathf.Atan2(Mathf.Abs(xiangJianY), Mathf.Abs(xiangJianX)) * 180f / Mathf.PI;
                jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + 180f + jianTouRotationZ);
            }
            else
            {
                jiantou.transform.rotation = Quaternion.Euler(0f, 0f, 360f + 180f);
            }
        }
    }*/

}
