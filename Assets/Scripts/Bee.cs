using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {
    private NavMeshAgent agent;

    private float nectar = 0;

    public float moveSpeed = 5.0f;

    private Vector3 destination;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);

        //set up state change to return to hive once currency = 10
    }

    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }

   public void OnTriggerEnter(Collider otherObject)
    {
        //collecting the currency
        if (otherObject.tag == "Resource")
        {
            nectar += 2;
            Debug.Log("Recource Gained");
        }  
        
        //process to trancfer currency
        if(otherObject.tag == "QueenHive")
        {
            otherObject.GetComponent<QueenHive>().GiveNectar(nectar);
            Debug.Log("Ca$h Honey" + nectar);
            nectar = 0;
            
            // set bee state to wait ******
        }      
    }

}
