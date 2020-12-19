using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    private float TTS;
    //public int multiply { get; set; }
    public string projectile;
    public Transform spawner;
    void Start()
    {
        TTS = 0.2f;
        //multiply = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && (TTS -= Time.deltaTime) <= 0)
        {
            TTS = 0.2f;
            PhotonNetwork.Instantiate(projectile, new Vector3(spawner.position.x, spawner.position.y, 3), spawner.rotation, 0);
        }
    }
}
