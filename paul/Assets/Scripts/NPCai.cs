using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCai : MonoBehaviour
{
    public float wanderRadius = 10f; // Dola�ma yar��ap�
    public float walkSpeed = 3.5f;   // Y�r�me h�z�
    public float idleTime = 2f;      // Durma s�resi

    private NavMeshAgent agent;
    private float idleTimer = 0f;
    private bool isIdle = false;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = walkSpeed;
        WanderToNewLocation();
    }

    void Update()
    {
        // Animator'a h�z de�erini ge�ir
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        // E�er NPC hedefe ula�t�ysa
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isIdle)
            {
                // Bir s�re durmas� i�in bekleme moduna ge�
                isIdle = true;
                idleTimer = idleTime;
            }
            else
            {
                // Bekleme s�resini azalt
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0f)
                {
                    isIdle = false;
                    WanderToNewLocation();
                }
            }
        }
    }

    void WanderToNewLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius; // Rastgele bir y�n
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
        {
            agent.SetDestination(hit.position); // Yeni rastgele pozisyona git
        }
    }
}