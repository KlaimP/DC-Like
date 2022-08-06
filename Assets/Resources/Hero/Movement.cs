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

    // Start is called before the first frame update
    void Start()
    {
        chController = GetComponent<CharacterController>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
        //Обнуление вектора движения
        moveVector = Vector3.zero;
        //Создание вектора движение в определенную сторону помноженная на скорость
        
        moveVector.x = Input.GetAxisRaw("Horizontal") * maxSpeed;
        //Выполнение гравитации
        moveVector.y = gravityForce;
        
        //Передвижение персонажа поноженная на Time.deltaTime для плавности
        chController.Move(moveVector * Time.deltaTime);

        Gravity();

        if (moveVector.x > 0 && !flipRight)
            Flip();
        else if (moveVector.x < 0 && flipRight)
            Flip();


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
        //Если объект находится не на земле, то опускаем персонажа на силу гравитации
        if (!chController.isGrounded)
            gravityForce -= strengthGravity * Time.deltaTime;
        else
            gravityForce = -1f;

        //Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && chController.isGrounded)
            gravityForce = maxJump;
    }
}
