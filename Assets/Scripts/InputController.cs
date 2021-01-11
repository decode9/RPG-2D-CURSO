﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float[] vector { get; private set; } = {0,0};
    public bool atacar { get; private set; }
    public bool habilidad1 { get; private set; }
    public bool habilidad2 { get; private set; }
    public bool inventario { get; private set; }
    public bool interactuar { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Actions();
        Movements();
    }

    void Actions()
    {
        atacar = Input.GetButtonDown("Atacar");
        habilidad1 = Input.GetButtonDown("Habilidad1");
        habilidad2 = Input.GetButtonDown("Habilidad2");
        inventario = Input.GetButtonDown("Inventario");
        interactuar = Input.GetButtonDown("Interactuar");
    }

    void Movements()
    {
        float[] v = {Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")};
        vector = v;
    }

    public bool getAtacar()
    {
        return atacar;
    }
}