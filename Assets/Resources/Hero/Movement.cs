using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed, maxJump;
    public float strengthGravity;

    float gravityForce;
    CharacterController chController;
    public Vector3 moveVector;

    public bool flipRight = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        chController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
        //��������� ������� ��������
        moveVector = Vector3.zero;
        //�������� ������� �������� � ������������ ������� ����������� �� ��������
        
        moveVector.x = Input.GetAxisRaw("Horizontal") * maxSpeed;
        //���������� ����������
        moveVector.y = gravityForce;
        
        //������������ ��������� ���������� �� Time.deltaTime ��� ���������
        chController.Move(moveVector * Time.deltaTime);

        Gravity();

        if (moveVector.x > 0 && !flipRight)
            Flip();
        else if (moveVector.x < 0 && flipRight)
            Flip();

        if (moveVector.x != 0)
            anim.SetBool("move", true);
        else
            anim.SetBool("move", false);
    }

    void FixedUpdate()
    {

    }

    void Flip()
    {
        flipRight = !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
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
