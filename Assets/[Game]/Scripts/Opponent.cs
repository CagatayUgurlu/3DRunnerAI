using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;

    private void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);

    }
}
