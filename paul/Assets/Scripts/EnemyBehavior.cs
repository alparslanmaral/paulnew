using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public bool isDetected = false;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Animator animator;

    // Normal ve algýlama durumunda dönüþ hýzý
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
                Debug.LogWarning($"{gameObject.name} NavMesh üzerinde deðil ve geçerli bir pozisyon bulunamadý.");
            }
        }

        // Baþlangýçta normal dönüþ hýzýný ayarla
        navMeshAgent.angularSpeed = normalAngularSpeed;
    }

    void Update()
    {
        if (isDetected && navMeshAgent.isOnNavMesh)
        {
            // Algýlandýysa kaçýþ yönünü ayarla ve hýzlý dönüþ hýzý kullan
            Vector3 directionAwayFromPlayer = transform.position - player.transform.position;
            Vector3 destination = transform.position + directionAwayFromPlayer;
            navMeshAgent.SetDestination(destination);

            navMeshAgent.angularSpeed = detectedAngularSpeed;  // Hýzlý dönüþ
        }
        else
        {
            navMeshAgent.angularSpeed = normalAngularSpeed;  // Normal dönüþ
        }

        // Animator parametresine NavMeshAgent'ýn hýzý atanýr
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
