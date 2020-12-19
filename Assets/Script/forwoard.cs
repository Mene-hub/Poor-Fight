using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;
using UnityEngine.Rendering;

public class forwoard : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float TTL;
    private float define;
    public int damage;
    void Start()
    {
        TTL = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((TTL -= Time.deltaTime) <= 0)
            PhotonNetwork.Destroy(this.gameObject);
        this.gameObject.transform.Translate(speed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PhotonNetwork.Destroy(this.gameObject);
    } 
}
