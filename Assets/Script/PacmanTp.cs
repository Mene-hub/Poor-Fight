using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanTp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.position = new Vector3(new System.Random().Next(-30, 40), 0, 3);
    }
}
