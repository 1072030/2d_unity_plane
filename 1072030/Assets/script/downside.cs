using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "Enemy_Bullet")
        {
            Destroy(col.gameObject);
        }
    }
}
