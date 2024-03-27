using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowRange : MonoBehaviour
{
    public LineRenderer range;
    public int subd;
    public float radius;
    [SerializeField]private TowerAttack checkcon;
    [SerializeField]private GameObject rangeview;
    void Update()
    {
        if(checkcon.ischosen)
        {
            DrawCircleRange();
            rangeview.SetActive(true);
        }
        else
        {
            rangeview.SetActive(false);
        }
    }
    void DrawCircleRange()
    {
        float angle = 2f * Mathf.PI / subd;

        range.positionCount = subd;
        for (int i =0; i< subd;i++)
        {
            float xpos= radius * Mathf.Cos(angle *i);
            float ypos = radius * Mathf.Sin(angle *i);

            Vector3 circle = new Vector3(xpos,ypos,0f);
            range.SetPosition(i, circle);
        }
    }
    
}
