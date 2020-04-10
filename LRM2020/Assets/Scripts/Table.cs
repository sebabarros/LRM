using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private int maxNumberOfCustomers;
    public int MaxNumberOfCustomers { get => maxNumberOfCustomers; set => maxNumberOfCustomers = value; }

    private int customers = 0;
    public int Customers { get => customers; set => customers = value; }

    private bool occupied = false;
    public bool Occupied { get => occupied; set => occupied = value; }

    private List<CustomerBehaviour> sittingCustomers;
    public List<CustomerBehaviour> SittingCustomers { get => sittingCustomers; set => sittingCustomers = value; }

    [SerializeField]
    private int tableNumber;

    public void AddCostumerToTable(CustomerBehaviour customer)
    {
        Customers++;
        SittingCustomers.Add(customer);
        if (Customers >= maxNumberOfCustomers)
        {
            Occupied = true;
        }
    }

    public Table()
    {
        SittingCustomers = new List<CustomerBehaviour>();
        
    }

    public int TableNumber { get => tableNumber; set => tableNumber = value; }
    



    // Start is called before the first frame update
    void Start()
    {
        maxNumberOfCustomers = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
