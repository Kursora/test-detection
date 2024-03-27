using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingTower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject towerTarget;
    public bool choosed=false, edgescr;
    [SerializeField]private Camera MainC;
    float x,zoom=15f;
    public float scroolspeed=25f;
    void Update()
    {
        zoom-=Input.GetAxis("Mouse ScrollWheel")*2;
        x=Input.GetAxisRaw("Horizontal");
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Tower")
                {
                    if(towerTarget == null)
                    {
                        towerTarget = hit.collider.gameObject;
                        towerTarget.GetComponent<TowerAttack>().ischosen=true;
                    }
                    if(towerTarget != hit.collider.gameObject)
                    {
                        towerTarget.GetComponent<TowerAttack>().ischosen=false;
                        towerTarget = hit.collider.gameObject;
                        towerTarget.GetComponent<TowerAttack>().ischosen=true;
                    }
                    if(!choosed)
                        choosed=true;
                }
            }
        }
        if(towerTarget!=null)
        {
            if (x != 0)
            {
                Vector3 movement = new Vector3(x,0f,0f);
                movement = movement.normalized * towerTarget.GetComponent<TowerInfo>().tower.speedinfo()*0.025f*Time.deltaTime;
                towerTarget.transform.Translate(movement);
                MainC.transform.position= new Vector3(towerTarget.transform.position.x,towerTarget.transform.position.y,-10f);
            }        
            
        }
        //CAMERA STUFF!!!!!!

        //For camera zooming
        if(zoom<2.5f)
            zoom=2.5f;
        if(zoom>15f)
            zoom=15f;
        MainC.orthographicSize = zoom;
        //For edge scrolling
        if(edgescr)
        {
            if(Input.mousePosition.x> Screen.width - 10f)
            {
                MainC.transform.position +=new Vector3(scroolspeed * Time.deltaTime,0f,0f);
            }
            if(Input.mousePosition.x<10f)
            {
                MainC.transform.position -=new Vector3(scroolspeed * Time.deltaTime,0f,0f);
            }
            if(Input.mousePosition.y> Screen.height - 10f)
            {
                MainC.transform.position +=new Vector3(0f,scroolspeed * Time.deltaTime,0f);
            }
            if(Input.mousePosition.y<10f)
            {
                MainC.transform.position -=new Vector3(0f,scroolspeed * Time.deltaTime,0f);
            }
        }
    }
}
