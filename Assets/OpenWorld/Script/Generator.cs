using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Security.Policy;
using Unity.Mathematics;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] WorldBlocks;
    public GameObject[] WorldStructure;
    //0 - erba
    //1 - percorso
    //2 - dark stone
    //3 - stone
    private quaternion rotate = new quaternion();
    private float x;
    public float y;
    private float current_x;
    private List<Blocco> World;
    private int index;
    public int Castle_percent = 1;

    //camera View -11 < camera > 11
    void Start()
    {
        if(File.Exists("World.xml")==true)
            World = GestioneFileXml.ReadConfig();

        current_x = -11;
        index = 0;
        rotate = quaternion.Euler(0,0,0);
        x = -11;
        //randomizzo la posizione 0 di spawn
        y += new System.Random().Next(-3, 2);
        //Instantiate(WorldBlocks[0], new Vector3(x, y, 0), rotate);;
    }

    // Update is called once per frame
    void Update()
    {
        ProceduralWorld(4);
    }

    void ProceduralWorld(int h)
    {
        
        if(Camera.main.transform.position.x + 11f >= current_x - 1.28F)
        {
            if (File.Exists("World.xml") == true && World.Count-1 > current_x + 11f)
            {
                if (World[index].Name != "Castle")
                    Instantiate(WorldBlocks[0], World[index++].Position, rotate);
                else
                {
                    Instantiate(WorldStructure[0], World[index++].Position, rotate);
                    current_x += 32 * 1.28f;
                }


                current_x += 1.28F;
            }
            else
            {
                if (World == null)
                    World = new List<Blocco>();

                if (new System.Random().Next(1, 100) > Castle_percent)
                {
                    World.Add(new Blocco(new Vector3(current_x, Mathf.PerlinNoise(current_x / 30f, 0f) * h, 1), "grass"));
                    Instantiate(WorldBlocks[0], World[World.Count - 1].Position, rotate);
                    GestioneFileXml.SaveConfig(World);
                    current_x += 1.28F;
                }
                else
                {
                    World.Add(new Blocco(new Vector3(current_x, Mathf.PerlinNoise(current_x / 30f, 0f) * h, 1), "Castle"));
                    Instantiate(WorldStructure[0], World[World.Count-1].Position, rotate);
                    current_x += 32*1.28f;
                    GestioneFileXml.SaveConfig(World);
                }
            }
        }
    }

    /*
    void perlin()
    {
        if (File.Exists("World.xml") == false)
        {
            World = new List<Vector3>();
            float current_y;
            for (float i = 0; i < 100; i += 1.28f)
            {
                current_y = Mathf.PerlinNoise(i / 30f, 0f) * 4f;
                y = current_y > y ? y + 1.28f : y - 1.28f;
                World.Add(new Vector3(x + i, Mathf.PerlinNoise(i / 30f, 0f) * 4f, 1));
                Instantiate(WorldBlocks[0], World[World.Count - 1], rotate);
            }
            GestioneFileXml.SaveConfig(World);
        } else
        {
            foreach (var block in World)
            {
                Instantiate(WorldBlocks[0], block, rotate);
            }
        }
    }
    private void Plan()
    {
        int plan_x = new System.Random().Next(6, 15);
        for (float i = 0; i < plan_x; i += 1.28f)
        {
            Instantiate(WorldBlocks[0], new Vector3(x + i, y, 1), rotate);
            Instantiate(WorldBlocks[3], new Vector3(x + i, y-1.28f, 1), rotate);
            current_x = i +1.28f;
        }
        x += current_x;
        plan_x = new System.Random().Next(6, 15);
        if (y > -2)
            y -= 1.28f;
        else
            y += 1.28f;
        for (float i = 0; i < plan_x; i += 1.28f)
        {
            Instantiate(WorldBlocks[0], new Vector3(x + i, y, 1), rotate);
            Instantiate(WorldBlocks[3], new Vector3(x + i, y-1.28f, 1), rotate);
            current_x = i + 1.28f;
        }
        x += current_x;
    }

    private void mountain()
    {
        float current_y;
        int width = new System.Random().Next(30, 60);
        float tmp;
        for (float i = 0; i < width/2; i += 1.28f)
        {
            current_y = y + (i * new System.Random().Next(1, 5));
            if (current_y >= 20)
                current_y = 20;
            Instantiate(WorldBlocks[0], new Vector3(x + i,current_y, 1), rotate);
            //Instantiate(WorldBlocks[0], new Vector3(x + width-i, current_y, 1), rotate) ;
            for (float j = (current_y - 1.28f); j >= -4; j -= 1.28f)
            {
                //while (Camera.main.transform.position.x+12f < x + i);
                Instantiate(WorldBlocks[3], new Vector3(x + i, j, 1), rotate);
                //Instantiate(WorldBlocks[3], new Vector3(x + width-i, j, 1), rotate);
            }
            current_x = i + 1.28f;
        }
        x += current_x;
        //Instantiate(WorldBlocks[0], new Vector3(x, max_h*1.28f, 1), rotate);

    }
*/
}
