using System.Collections.Generic;
using UnityEngine;

namespace GravityWell.Bullet
{
    public class RejectObject : MonoBehaviour
{
    public float magnetForce = 100;
    private Vector2 rejectForce;
    private Vector2 dir;

    List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

    void FixedUpdate()
    {
        
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].AddForce(Vector2.up * magnetForce);
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
                r.velocity = new Vector2(r.velocity.x,40);
            }
        }
    }
}
}
