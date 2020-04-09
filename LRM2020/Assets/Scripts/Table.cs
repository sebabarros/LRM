using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private int customers = 0;
    public int Customers { get => customers; set => customers = value; }

    private bool occupied = false;
    public bool Occupied { get => occupied; set => occupied = value; }

    private List<CustomerBehaviour> sittingCustomers;
    public List<CustomerBehaviour> SittingCustomers { get => sittingCustomers; set => sittingCustomers = value; }

    [SerializeField]
    private int tableNumber;

    public Table()
    {
        SittingCustomers = new List<CustomerBehaviour>();
    }

    public int TableNumber { get => tableNumber; set => tableNumber = value; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
