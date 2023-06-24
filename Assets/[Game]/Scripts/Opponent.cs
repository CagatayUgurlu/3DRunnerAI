using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;

    Vector3 OpponentStartPos;
    public GameObject speedBoosterIcon;
    public float speedBoost;
    private void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
       if (GameManager.instance.isGameOver)
        {
            OpponentAgent.Stop();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            transform.position = OpponentStartPos;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("speedboost"))
        {
            speedBoosterIcon.SetActive(true);
            OpponentAgent.speed = OpponentAgent.speed + 3f;
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed = OpponentAgent.speed - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
