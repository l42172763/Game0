using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autogun : MonoBehaviour
{
    public Vector3 xxx;
    private void FixedUpdate()
    {
        Vector3 player_postion = this.transform.position;
        Vector3 m_mousePosition = Input.mousePosition;
        player_postion = Camera.main.WorldToScreenPoint(player_postion);
        // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        m_mousePosition.z = 0;
        // 武器朝向角度
        float m_weaponAngle = Vector2.Angle(m_mousePosition - player_postion, Vector2.up);
        if (player_postion.x < m_mousePosition.x)
        {
            m_weaponAngle = -m_weaponAngle;
        }
        //判断武器正反
        if (m_weaponAngle > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (m_weaponAngle < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // 变换最终角度
        transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);
        xxx = transform.eulerAngles;
    }
}