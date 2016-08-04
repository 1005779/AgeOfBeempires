using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {
    private NavMeshAgent agent;

    private float pollen = 0;

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
    }

    public void MoveTo(Vector3 newDestination)
    {
        destination = newDestination;
    }

   public void OnTriggerEnter(Collider recource)
    {
        if (recource.tag == "Resource")
        {
            pollen += 2;
            Debug.Log("Recource Gained");
        }            
    }

    // potentially to give poollen to hives pollen pool
    public void GiveNectar(float nectar)
    {
        nectar += pollen;
    }
    
}
