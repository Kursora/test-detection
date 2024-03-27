using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectiletype;//1: follow, 2: straight, 3:spawn, 4:round
    public float pspeed,damage;
    public string projectowner;
    public GameObject Owner,targeting;
    public float dieafter;
    void Awake()
    {
        Owner=GameObject.Find(projectowner);
    }
    void Start()
    {
        Destroy(gameObject , dieafter);
    }
    void Update()
    {
        if(Owner.GetComponent<TowerAttack>().enemies.Count>0)
        {
            switch(projectiletype)
            {
                case 1:
                    targeting=Owner.GetComponent<TowerAttack>().enemies[0];
                    transform.position=Vector3.MoveTowards(transform.position,targeting.transform.position,pspeed*Time.deltaTime);
                    break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(projectiletype==1)
        {
            if(other.tag=="Enemy")
            {
                targeting.GetComponent<EnemyInfo>().enemy.damaged(damage);
                Destroy(gameObject);    
            }
        }
    }
}
