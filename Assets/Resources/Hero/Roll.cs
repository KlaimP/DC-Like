using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    //��������� ��������, ���������� �� �������(false) 
    public bool rolling = false;
    //������� �������� �� ������� � ���������� 50 �������
    public int timer = 50;
    //�����, ���� ����� ����� �� ��������
    public int otkat = 500;
    //���������� ��� �������� 
    CharacterController RollMove;
    //���������� ��� ������, ����� �� ����� ���� ��������, ���� �����������
    public KeyCode KeyRoll = KeyCode.LeftShift;
    void Start()
    {
        //���������� ���������� ��� ��������
        RollMove = GetComponent<CharacterController>();
    }
    void Update()
    {
        //���� ���� �� ������� � ���� �����, �� ����� �������������
        if (rolling == false && otkat > 0)
        {
            otkat--;
        }
        //���� ������ ������ �������� � ��� ������ �� ���������� rolling �������� �� true
        if (Input.GetKeyUp(KeyRoll) && otkat <= 0)
        {
            rolling = true;
        }
        //���� ���������� rolling �������� �� true �����
        if (rolling == true )
        {
            //������ ����������, ���� ���� �������
            timer--;
            //����� � ��������� �����������
            Movement move = GetComponent<Movement>();
            move.enabled = false;
            //���� ������ �������� �� ������ � ��������� �������������, ����� �������� ������ � ������ ����� � 500 �������
            if (GetComponent<Movement>().moveVector.x > 1)
            {
                RollMove.Move(new Vector3(30f * Time.deltaTime, 0.0f, 0.0f));
                otkat = 500;
            }
            //���� ������ �������� �� ������ � ��������� ��������������, ����� �������� ����� � ������ ����� � 500 �������
            else if (GetComponent<Movement>().moveVector.x < -1)
            {
                RollMove.Move(new Vector3(-30f * Time.deltaTime, 0.0f, 0.0f));
                otkat = 500;
            }
            //���� ������ ��������, ����� rolling �������� �� false �������������� ����������� �������, �������������� ������, ����� � ��������� ����������
            if (timer < 0)
            {
                rolling = false;
                timer = 50;
                move.enabled = true;
            }
        }
    }
}
