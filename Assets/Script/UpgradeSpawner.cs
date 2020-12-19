using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    private float UpgradeSpawnRate;
    private float HealSpawnRate;
    private float SpeedSpawnRate;
    public Transform[] spawnPoint;
    void Start()
    {
        UpgradeSpawnRate = 50f;
        HealSpawnRate = 15f;
        SpeedSpawnRate = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((UpgradeSpawnRate -= Time.deltaTime) <= 0)
        {
            int tmp = new System.Random().Next(0, spawnPoint.Length);
            if(new System.Random().Next(0,2)==1)
                PhotonNetwork.Instantiate("BulletUpgrade", spawnPoint[tmp].position, spawnPoint[tmp].rotation, 0);
            else
                PhotonNetwork.Instantiate("Jump", spawnPoint[tmp].position, spawnPoint[tmp].rotation, 0);
            UpgradeSpawnRate = 25f;
        }

        if ((HealSpawnRate -= Time.deltaTime) <= 0)
        {
            int tmp = new System.Random().Next(0, spawnPoint.Length);
            PhotonNetwork.Instantiate("Heal", spawnPoint[tmp].position, spawnPoint[tmp].rotation, 0);
            HealSpawnRate = 15f;
        }

        if ((SpeedSpawnRate -= Time.deltaTime) <= 0)
        {
            int tmp = new System.Random().Next(0, spawnPoint.Length);
            PhotonNetwork.Instantiate("Speed", spawnPoint[tmp].position, spawnPoint[tmp].rotation, 0);
            SpeedSpawnRate = 5f;
        }
    }
}
