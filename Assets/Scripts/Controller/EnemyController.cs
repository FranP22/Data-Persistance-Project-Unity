using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{

    private Animator animator;
    private NavMeshAgent agent;
    private GameObject diamond = null;
    private GameObject diamondSight = null;
    private BoxCollider box;

    private int scale = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        box = GetComponent<BoxCollider>();
        box.size = new Vector3(scale, 0.5f, scale);
    }

    void Update()
    {
        if (Game.timeLeft < 0) {
            agent.ResetPath();
            return;
        }

        float speedRes = Mathf.Sqrt(Mathf.Pow(agent.velocity.x, 2) + Mathf.Pow(agent.velocity.z, 2));
        animator.SetFloat("Speed", speedRes);

        if (diamond == null || diamond.IsDestroyed())
        {
            FindRandomDiamond();
        }
        else
        {
            if (diamondSight == null || diamondSight.IsDestroyed())
            {
                agent.SetDestination(diamond.transform.position);
            }
            else
            {
                agent.SetDestination(diamondSight.transform.position);
            }
        }
    }

    void FindRandomDiamond()
    {
        GameObject[] diamonds = GameObject.FindGameObjectsWithTag("Diamond");

        if (diamonds.Length == 0) return;

        diamond = diamonds[Random.Range(0, diamonds.Length)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond") || other.gameObject.CompareTag("Pickup"))
        {
            diamondSight = other.gameObject;
        }
    }
}
