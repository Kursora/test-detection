using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public TowerIf tower;
}
[System.Serializable]
public class TowerIf
{
    public string Name;
    public int id;
    [SerializeField]private int hp;
    [SerializeField]private float speed;
    public float hpinfo()
    {
        return hp;
    }
    public float speedinfo()
    {
        return speed;
    }
}
