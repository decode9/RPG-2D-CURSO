using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Attributes attributes;
    public string name;
    public int exp;

    protected void DecirNombre(){
        Debug.Log("Hola soy " + name);
    }
}
