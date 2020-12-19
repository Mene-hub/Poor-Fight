using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocco
{
    public Vector3 Position { get; set; }
    public string Name { get; set; }


    public Blocco(Vector3 p, string n) 
    {
        Position = p;
        Name = n;
    }

    public Blocco() { }
}
