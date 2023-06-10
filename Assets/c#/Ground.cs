using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public int nowHp,maxHp;

    public void SetGroundHp(int hp, int mhp)
    {
        nowHp=hp;
        maxHp=mhp;
    }

    void Start()
    {
        SetGroundHp(10, 10);
    }

    public void Damage(int hit)
    {
        nowHp -= hit;
        Debug.Log(nowHp);
        if(nowHp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
