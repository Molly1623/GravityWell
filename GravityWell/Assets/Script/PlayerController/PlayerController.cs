using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GravityWell.Weapon;

namespace GravityWell.PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        private float horizontalmove;
        private float facedirection;
        private Rigidbody2D rb;
        public LayerMask Ground;
        public Collider2D coll;
        public Transform Weapon;
        public Transform center;
        public Animator anim;
        public float speed;
        public float jumpforce;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
        //  SetFirePoint();
            RotateWeapon();
            Movement();
        }

        //角色控制
        void Movement()
        {
            //获取鼠标位置
            Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
            
            horizontalmove = Input.GetAxis("Horizontal");
            float mosdirction = mousePosition.x - transform.position.x;
            rb.velocity = new Vector2(horizontalmove * speed,rb.velocity.y);
            
            if(mosdirction != 0)
            {
                if(mosdirction > 0)
                    transform.localScale = new Vector3(1,1,1);
                else
                    transform.localScale = new Vector3(-1,1,1);
            }
            if(horizontalmove != 0) 
                anim.SetBool("isMove",true);
            else    
                anim.SetBool("isMove",false);
            if(Input.GetButtonDown("Jump"))
            {
                 if(coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                    anim.SetBool("isJump",true);
                }
            }
        }

        void SetFirePoint()
        {
            Weapon.position = transform.position;
            Vector2 firepath = new Vector2();
            float angle = Mathf.Atan2(firepath.y,firepath.x)*Mathf.Rad2Deg;
            Weapon.transform.rotation = Quaternion.Euler(0,0,angle);
        //  Debug.DrawRay(Weapon.position,firepath,Color.white,0.1f,false);
        }

        void RotateWeapon()
        {
            Weapon.position = transform.position;
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - center.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            Weapon.transform.rotation = Quaternion.Euler(0,0,angle);
            Debug.DrawRay(Weapon.position,dir,Color.white,0.01f,false);
        }

        void SwitchAnim()
        {
        anim.SetBool("Idle",false);
        if(anim.GetBool("isJump"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("isJump",false);
                anim.SetBool("isFall",true);
            }
        }
        else if(coll.IsTouchingLayers(Ground))
        {
            anim.SetBool("isFall",false);
            anim.SetBool("Idle",true);
        }
        }

    }

}

