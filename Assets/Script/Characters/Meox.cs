using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meox : MonoBehaviour
{
    public TowerAttack checkenemy;
    public float cda1,cda2,cda3,cdp;
    public GameObject object1,object2,object3,pobject;
    public Transform parent;
    public void passiveattack()
    {
        Instantiate(pobject,transform.position,Quaternion.identity,parent);
    }
    public void attack1()
    {
        Instantiate(object1,transform.position,Quaternion.identity,parent);
    }
    public void attack2()
    {
        Instantiate(object1,transform.position,Quaternion.identity,parent);
    }
    public void attackpower()
    {
    }
    void Update()
    {
        if(checkenemy.enemies.Count>0)
        {
            cdp+=Time.deltaTime;
            if(cdp>1f)
            {
                passiveattack();
                cdp=0;
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                attack1();
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                attack2();
            }
        }
    }
}

