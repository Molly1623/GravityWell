using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 mousePosition;
    private RaycastHit2D hitInfo;
    private Vector2 TowardHit;
    private Vector2 TowardMous;
    public Transform firePoint;
    public GameObject bullet_0;
    public GameObject bullet_1;
    public LineRenderer fireRay_0;
    public LineRenderer fireRay_1;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot(fireRay_0));
            SetBullet(bullet_0);
            DestroyBullet();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Shoot(fireRay_1));
            SetBullet(bullet_1);
            DestroyBullet();
        }
    }

    IEnumerator Shoot(LineRenderer lineRenderer)
    {
        //指针坐标转换
        mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0); 
        //射线碰撞物体   
        int bulletLayer = 6;
        hitInfo = Physics2D.Raycast(firePoint.position, mousePosition - transform.position,Mathf.Infinity,~(1<<bulletLayer));
        if(hitInfo)
        {
            Vector2 TowardHit = new Vector2(hitInfo.point.x - transform.position.x,hitInfo.point.y - transform.position.y);
            Vector2 TowardMous = new Vector2(mousePosition.x - transform.position.x,mousePosition.y - transform.position.y);
            Debug.Log(hitInfo.transform.name);
            lineRenderer.SetPosition(0,firePoint.position);
            
            if(TowardMous.magnitude > TowardHit.magnitude)   
                lineRenderer.SetPosition(1,hitInfo.point);
            else
                lineRenderer.SetPosition(1,mousePosition);
            
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, mousePosition);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }

    void SetBullet(GameObject bullet)
    {
        if(!Input.GetKey(KeyCode.Q))
        {
            Vector2 bulletPosition = mousePosition;
            if(hitInfo)
            {
                if(TowardHit.magnitude > TowardMous.magnitude)
                {
                    Instantiate(bullet, mousePosition, bullet.transform.rotation);
                }
            }
            else
            {
                Instantiate(bullet, mousePosition, bullet.transform.rotation);
            }
        }
    }

    void DestroyBullet()
    {
         if(Input.GetKey(KeyCode.Q))
        {
            var hit = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), Vector3.zero, Mathf.Infinity);
            if(hit.collider.gameObject.tag == "Bullet")
            {
                Destroy(hit.collider.gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
