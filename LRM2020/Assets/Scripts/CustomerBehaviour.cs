using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform destination;    
    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    public float accuracy = 2.0f;
    GameObject[] tables;
    public enum State{
        Searching, Waiting, Eating, Leaving
    };
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        tables = GameObject.FindGameObjectsWithTag("Table");
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

    void Search()
    {
        if(destination == null)
        {
            ChooseDest();
            return;
        }

        agent.SetDestination(destination.position);

        Table tableControl = destination.gameObject.GetComponent<Table>();

        if(!tableControl.occupied)
        {
            if(Vector3.Distance(this.transform.position, destination.position) <= accuracy)
            {
            tableControl.customers++;
            if(tableControl.customers >= 2) tableControl.occupied = true;
            currentState = State.Waiting;
            }
        }
        else
        {
            ChooseDest();
        }
    }

    void ChooseDest()
    {
        
        float dist = 200.0f;

        foreach (GameObject table in tables)
        {
            if(table.GetComponent<Table>().occupied == false)
            {
                if(Vector3.Distance(this.transform.position, table.transform.position) < dist)                    
                {
                dist = Vector3.Distance(transform.position, table.transform.position);
                destination = table.transform;
                Debug.Log(dist);
                }
            }else{return;}
        }
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
