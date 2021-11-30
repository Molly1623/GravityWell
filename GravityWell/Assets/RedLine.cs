using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //´¥ÅöºìÉ«ÉäÏß
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("2");

 
        }
 
    }
 

}
