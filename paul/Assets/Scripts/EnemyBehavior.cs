using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public bool isDetected = false;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Animator animator;

    // Normal ve alg�lama durumunda d�n�� h�z�
    public float normalAngularSpeed = 120f;
    public float detectedAngularSpeed = 300f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (!navMeshAgent.isOnNavMesh)
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                transform.position = hit.position;
                navMeshAgent.Warp(hit.position);
            }
            else
            {
                Debug.LogWarning($"{gameObject.name} NavMesh �zerinde de�il ve ge�erli bir pozisyon bulunamad�.");
            }
        }

        // Ba�lang��ta normal d�n�� h�z�n� ayarla
        navMeshAgent.angularSpeed = normalAngularSpeed;
    }

    void Update()
    {
        if (isDetected && navMeshAgent.isOnNavMesh)
        {
            // Alg�land�ysa ka��� y�n�n� ayarla ve h�zl� d�n�� h�z� kullan
            Vector3 directionAwayFromPlayer = transform.position - player.transform.position;
            Vector3 destination = transform.position + directionAwayFromPlayer;
            navMeshAgent.SetDestination(destination);

            navMeshAgent.angularSpeed = detectedAngularSpeed;  // H�zl� d�n��
        }
        else
        {
            navMeshAgent.angularSpeed = normalAngularSpeed;  // Normal d�n��
        }

        // Animator parametresine NavMeshAgent'�n h�z� atan�r
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
