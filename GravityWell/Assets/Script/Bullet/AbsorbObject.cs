using System.Collections.Generic;
using UnityEngine;
using GravityWell.Weapon;

namespace GravityWell.Bullet
{
    public class AbsorbObject : MonoBehaviour
{
    public float magnetForce = 100;
    List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

    void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].velocity = (transform.position - caughtRigidbodies[i].transform.position) * magnetForce * Time.deltaTime ;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D r = other.GetComponent<Rigidbody2D>();

            if(!caughtRigidbodies.Contains(r))
            {
                //Add Rigidbody
                caughtRigidbodies.Add(r);
                Debug.Log(other.tag);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D r = other.GetComponent<Rigidbody2D>();

            if (caughtRigidbodies.Contains(r))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(r);
                Debug.Log(other.tag);
            }
        }
    }

}
}   
