using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private int customers = 0;
    private bool occupied = false;
    public int tableNumber;

    public int Customers { get => customers; set => customers = value; }
    public bool Occupied { get => occupied; set => occupied = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
