using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public bool isDetected = false;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Animator animator;
    private AudioSource audioSource;

    public float normalAngularSpeed = 120f;
    public float detectedAngularSpeed = 300f;
    private bool hasPlayedSound = false; // Sesin bir kere çalmasý için kontrol

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                Debug.LogWarning($"{gameObject.name} NavMesh üzerinde deðil ve geçerli bir pozisyon bulunamadý.");
            }
        }

        navMeshAgent.angularSpeed = normalAngularSpeed;
    }

    void Update()
    {
        if (isDetected && navMeshAgent.isOnNavMesh)
        {
            Vector3 directionAwayFromPlayer = transform.position - player.transform.position;
            Vector3 destination = transform.position + directionAwayFromPlayer;
            navMeshAgent.SetDestination(destination);

            navMeshAgent.angularSpeed = detectedAngularSpeed;

            // Ses çalma iþlemi, sadece bir kere çalsýn
            if (!hasPlayedSound && audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true; // Sadece bir kere çalmasý için iþaretle
            }
        }
        else
        {
            navMeshAgent.angularSpeed = normalAngularSpeed;
            hasPlayedSound = false; // isDetected false olduðunda resetleyerek sesin tekrar çalýnabilmesini saðlar
        }

        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
