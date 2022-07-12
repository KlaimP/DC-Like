using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10, maxJump = 1;
    int move = 0;
    public float time = 0;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(new Vector3(0, maxJump * 10, 0));
            //rb.velocity = new Vector2(rb.velocity.x, maxJump);
    }

    void FixedUpdate()
    {
        //� �� ����� ����������� ��������� ������ � ����� ������ ����� ���.
        //��� ������ ��� ������ ����� ������� ��������� ���������� � ����.
        //�� ����� ���� ����� ������������ ��� ���������� � ��������, ��� �������� ������.
        move = (int)Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        
    }
}
