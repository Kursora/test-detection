using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField]private CircleCollider2D circlerange;
    [SerializeField]private BoxCollider2D boxrange;
    public List<GameObject> enemies;
    [SerializeField]private bool areaattack=false;
    public int AttackType; //default 0 = first, 1 = last, 2 = mosthp, 3 = random
    public bool ischosen=false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(circlerange!=null)
        {
            if(circlerange.IsTouching(other))
            {
                if(other.tag=="Enemy")
                {
                    enemies.Add(other.gameObject);
                }
            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(circlerange!=null)
        {
            if(other.tag=="Enemy")
            {
                enemies.Remove(other.gameObject);
            }
        }
    }
    
}
