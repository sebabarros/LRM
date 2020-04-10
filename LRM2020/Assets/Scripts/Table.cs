using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int TableNumber { get => tableNumber; set => tableNumber = value; }

    public enum TableState
    {
        free, parcial , ocupadided
    };


    private TableState stateOfTable;
   
    public TableState StateOfTable { get => stateOfTable; set => stateOfTable = value; }

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
        if (Customers > maxNumberOfCustomers && Customers < maxNumberOfCustomers)
        {
            StateOfTable = TableState.parcial;
        }
        else if (Customers >= maxNumberOfCustomers)
        {
            StateOfTable = TableState.ocupadided;
        }
    }

    public Table()
    {
        SittingCustomers = new List<CustomerBehaviour>();
      
    }





    // Start is called before the first frame update
    void Start()
    {
        maxNumberOfCustomers = 2;
        StateOfTable = TableState.free;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
