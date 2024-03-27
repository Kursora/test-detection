using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public EnemyHP enemy;
    void Update()
    {
        if(enemy.hpinfo()==0f)
        {
            Destroy(gameObject);
        }
    }
    
}
[System.Serializable]
public class EnemyHP
{
    [SerializeField]private float hp;
    public float hpinfo()
    {
        return hp;
    }
    public void damaged(float damage)
    {
        hp-=damage;
    }
}

