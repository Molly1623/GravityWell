using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
            horizontalmove = Input.GetAxis("Horizontal");
            facedirection = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(horizontalmove * speed,rb.velocity.y);
            
            if(facedirection != 0)
            {
                transform.localScale = new Vector3(facedirection,1,1);
            }
            if(Input.GetButtonDown("Jump"))
            {
                // if(coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
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

    }

}

