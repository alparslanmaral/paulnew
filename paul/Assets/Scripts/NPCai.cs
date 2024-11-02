using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCai : MonoBehaviour
{
    public float wanderRadius = 10f; // Dolaþma yarýçapý
    public float walkSpeed = 3.5f;   // Yürüme hýzý
    public float idleTime = 2f;      // Durma süresi

    private NavMeshAgent agent;
    private float idleTimer = 0f;
    private bool isIdle = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        WanderToNewLocation();
    }

    void Update()
    {
        // Eðer NPC hedefe ulaþtýysa
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!isIdle)
            {
                // Bir süre durmasý için bekleme moduna geç
                isIdle = true;
                idleTimer = idleTime;
            }
            else
            {
                // Bekleme süresini azalt
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
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius; // Rastgele bir yön
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
        {
            agent.SetDestination(hit.position); // Yeni rastgele pozisyona git
        }
    }
}