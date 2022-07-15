using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed, maxJump;
    public float strengthGravity;

    float gravityForce;
    CharacterController chController;
    Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //��������� ������� ��������
        moveVector = Vector3.zero;
        //�������� ������� �������� � ������������ ������� ����������� �� ��������
        moveVector.x = Input.GetAxisRaw("Horizontal") * maxSpeed;
        if (moveVector.x < 0)
        {
            transform.Rotate(new Vector3(0, 0, 9999) * Time.deltaTime);
        }
        else if (moveVector.x > 0)
        {
            transform.Rotate(new Vector3(0, 0, -9999) * Time.deltaTime);
        }


        //���������� ����������
        moveVector.y = gravityForce;

        //������������ ��������� ���������� �� Time.deltaTime ��� ���������
        chController.Move(moveVector * Time.deltaTime);

        Gravity();
    }

    void FixedUpdate()
    {

    }

    private void Gravity()
    {
        //���� ������ ��������� �� �� �����, �� �������� ��������� �� ���� ����������
        if (!chController.isGrounded)
            gravityForce -= strengthGravity * Time.deltaTime;
        else
            gravityForce = -1f;

        //������
        if (Input.GetKeyDown(KeyCode.Space) && chController.isGrounded)
            gravityForce = maxJump;
    }
}
