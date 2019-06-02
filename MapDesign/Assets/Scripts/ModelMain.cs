using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMain
{
    private ModelMain() { }
    private static ModelMain m_ModelMain;
    public static ModelMain Instance
    {
        get
        {
            if(m_ModelMain == null)
            {
                m_ModelMain = new ModelMain();
            }
            return m_ModelMain;
        }
    }
    
    public UISprite skill_1 { get; set; }
    public UISprite skill_2 { get; set; }
    public UISprite skill_3 { get; set; }
    public UISprite skill_4 { get; set; }
    public UISprite skill_5 { get; set; }
    public UISprite skill_6 { get; set; }
    public UISprite skill_7 { get; set; }
    public UISprite skill_8 { get; set; }
    public UISprite skill_9 { get; set; }
    public UISprite skill_10 { get; set; }
    public UISprite skill_11 { get; set; }
    public UISprite skill_12 { get; set; }

    



}
