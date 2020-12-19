using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class rotate_ : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera myCamera;
    public GameObject Gun;
    public GameObject Scar;
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.mousePosition - myCamera.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (dir.x < 0)
        {
            Gun.transform.localScale = new Vector3(1, -1, 1);
            Scar.transform.localScale = new Vector3(2.5f, -2.5f, 2.5f);
        }
        else
        {
            Gun.transform.localScale = new Vector3(1, 1, 1);
            Scar.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
    }
}
