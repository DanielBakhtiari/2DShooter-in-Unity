using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
