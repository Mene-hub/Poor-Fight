using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networkplayer : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    public Shoot[] ShootScript;
    public rotate_ RotateScript;
    public  Player_Controller ControllerScript;
    void Start()
    {
        if(photonView.isMine)
        {
            ShootScript[0].enabled = true;
            ShootScript[1].enabled = true;
            RotateScript.enabled = true;
            ControllerScript.enabled = true;
            //WeaponSpawner.GetComponentInChildren<spawnWeapon>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
