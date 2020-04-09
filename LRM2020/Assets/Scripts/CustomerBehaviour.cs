using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class CustomerBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    [SerializeField]
    private float speed = 10.0f;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField]
    private float rotSpeed = 10.0f;
    public float RotSpeed { get => rotSpeed; set => rotSpeed = value; }

    [SerializeField]
    private float accuracy = 10.0f;
    public float Accuracy { get => accuracy; set => accuracy = value; }

    private Table SelectedTable;
    List<Table> tables;
    public enum State{
        Searching, Waiting, Eating, Leaving
    };
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        
        tables = UnityEngine.Object.FindObjectsOfType<Table>().ToList();
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = State.Searching;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Searching:
            Search();
            break;

            case State.Waiting:
            Wait();
            break;

            case State.Eating:
            Eat();
            break;

            case State.Leaving:
            Leave();
            break;

        }
    }
    Table tableDestination;

    

    void Search()
    {
        tableDestination = ChooseDest();
        if (tableDestination != null)
        {                     
            agent.SetDestination(tableDestination.transform.position);
            if (Vector3.Distance(this.transform.position, tableDestination.transform.position) <= Accuracy)
            {                             
                tableDestination.Customers++;                
                tableDestination.SittingCustomers.Add(this);
                
                if (tableDestination.Customers >= 2)
                {
                    tableDestination.Occupied = true;                    
                }
                
                SelectedTable = tableDestination;
                currentState = State.Waiting;
            }            
        }
    }

    Table ChooseDest()
    {
        Table selectedTable = null;    
        float dist = 200.0f;

        foreach (Table table in tables.Where(a => a.Occupied == false).ToList())
        {
            if(Vector3.Distance(this.transform.position, table.transform.position) < dist)                    
            {
                dist = Vector3.Distance(transform.position, table.transform.position);
                selectedTable = table;            
            }
        }
        return selectedTable;
    }

    void Wait()
    {
        agent.isStopped = true;
    }

    void Eat()
    {

    }

    void Leave()
    {

    }
}
