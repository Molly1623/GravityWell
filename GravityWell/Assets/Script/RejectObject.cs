using System.Collections.Generic;
using UnityEngine;

public class RejectObject : MonoBehaviour
{
    public float magnetForce = 100;

    List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

    void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].AddForce(new Vector2(caughtRigidbodies[i].position.x - transform.position.x,caughtRigidbodies[i].position.y-transform.position.y) * magnetForce * Time.deltaTime);
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