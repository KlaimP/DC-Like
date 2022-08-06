using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    //состояние переката, изначально не катится(false) 
    public bool rolling = false;
    //перекат построен на времени и состовляет 50 фреймов
    public int timer = 50;
    //откат, чтоб жизнь медом не казалась
    public int otkatPub = 200;
    public int otkat;
    //переменная для движения 
    CharacterController RollMove;
    //переменная для конпки, чтобы ее можно было поменять, если понадобится
    public KeyCode KeyRoll = KeyCode.LeftShift;
    void Start()
    {
        //объявление переменной для движения
        RollMove = GetComponent<CharacterController>();
        otkat = otkatPub;
    }
    void Update()
    {
        //если перс не катится и есть откат, то откат заканчивается
        if (rolling == false && otkat > 0)
        {
            otkat--;
        }
        //если нажата конпка переката и нет отката то переменная rolling ставится на true
        if (Input.GetKeyUp(KeyRoll) && otkat <= 0)
        {
            rolling = true;
        }
        //если переменная rolling ставится на true тоооо
        if (rolling == true )
        {
            //таймер убавляется, пока перс катится
            timer--;
            //класс с движением откоючается
            Movement move = GetComponent<Movement>();
            move.enabled = false;
            //если вектор движение из класса с движением положительний, тогда движется вправо и дается откат в 500 фреймов
            if (GetComponent<Movement>().moveVector.x > 1)
            {
                RollMove.Move(new Vector3(30f * Time.deltaTime, 0.0f, 0.0f));
                otkat = otkatPub;
            }
            //если вектор движение из класса с движением отридцательный, тогда движется влево и дается откат в 500 фреймов
            else if (GetComponent<Movement>().moveVector.x < -1)
            {
                RollMove.Move(new Vector3(-30f * Time.deltaTime, 0.0f, 0.0f));
                otkat = otkatPub;
            }
            //если таймер кончился, тогда rolling ставится на false соответственно отключается перекат, возобновляется таймер, класс с движением включается
            if (timer < 0)
            {
                rolling = false;
                timer = 50;
                move.enabled = true;
            }
        }
    }
}
