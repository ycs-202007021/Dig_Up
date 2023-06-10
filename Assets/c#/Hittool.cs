using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittool : MonoBehaviour
{
    float totalTime=3;
    int count = 0;
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)&&count ==0)//ÁÂÅ¬¸¯ ÇÏ¸é
        {
            transform.Rotate(0, 0, -80);
            count++;
            Debug.Log("1");
        }
        if (totalTime > 1 &&count==1)
        {
            totalTime -= Time.deltaTime;
            //Debug.Log(totalTime);
            if (totalTime < 1)
            {
                transform.Rotate(0, 0, +80);
                totalTime = 3;
                count--;
            }
        }
    }
}
