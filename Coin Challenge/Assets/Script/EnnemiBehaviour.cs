using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiBehaviour : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Update()
    {
        agent.SetDestination(target.position);     
    }


}
