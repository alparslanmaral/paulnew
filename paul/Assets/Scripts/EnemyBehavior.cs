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
    private bool hasPlayedSound = false; // Sesin bir kere �almas� i�in kontrol

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
                Debug.LogWarning($"{gameObject.name} NavMesh �zerinde de�il ve ge�erli bir pozisyon bulunamad�.");
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

            // Ses �alma i�lemi, sadece bir kere �als�n
            if (!hasPlayedSound && audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true; // Sadece bir kere �almas� i�in i�aretle
            }
        }
        else
        {
            navMeshAgent.angularSpeed = normalAngularSpeed;
            hasPlayedSound = false; // isDetected false oldu�unda resetleyerek sesin tekrar �al�nabilmesini sa�lar
        }

        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
