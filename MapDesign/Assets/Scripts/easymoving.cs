using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easymoving : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator ani;
    private Vector3 t;
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame

    void Update()
    {

        MoveControl();

    }

    void MoveControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 player_postion = this.transform.position;
        Vector3 m_mousePosition = Input.mousePosition;
        player_postion = Camera.main.WorldToScreenPoint(player_postion);
        m_mousePosition.z = 0;
        t = m_mousePosition - player_postion;
        GetComponent<SpriteRenderer>().flipX = t.x > 0 ? true : false;
        if (horizontal != 0 || vertical != 0)
        {
            Vector2 v = rBody.velocity;
            v.x = horizontal * 1;
            v.y = vertical * 1;
            rBody.velocity = v;
        }
        if (horizontal != 0)
        {
            ani.SetBool("go", horizontal * t.x > 0 ? true : false);
            ani.SetBool("back", horizontal * t.x < 0 ? true : false);
        }
        else
        {
            ani.SetBool("go", false);
            ani.SetBool("back",false);
        }
    }
}