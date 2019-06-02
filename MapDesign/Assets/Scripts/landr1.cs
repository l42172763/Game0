using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landr1 : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Vector3 t;
    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        MoveControl();

    }

    void MoveControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            Vector2 v = rBody.velocity;
            v.x = horizontal * 1;
            v.y = vertical * 1;
            rBody.velocity = v;
        }
    }
}
