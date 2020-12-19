using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float TTL;
    private bool hitted;
    void Start()
    {
        hitted = false;
        TTL = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitted == true)
        {
            if ((TTL -= Time.deltaTime) <= 0)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            hitted = true;
    }
}
