using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    int d = 50;
    Transform a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 520) * Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //ExecuteAfterTime(1);
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); //
        }
    }
    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        d++;
        a.Rotate(0, 0, 1);
        yield return new WaitForSeconds(timeInSec);
       
    }
}
