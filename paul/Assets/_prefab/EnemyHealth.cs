using UnityEngine;
using UnityEngine.AI; // NavMeshAgent için gerekli

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Düþmanýn maksimum caný
    private int currentHealth;
    private Animator animator; // Animatör bileþeni
    private NavMeshAgent navMeshAgent; // NavMeshAgent bileþeni
    private EnemyBehavior enemyBehavior; // Düþmanýn davranýþ script'i
    private CapsuleCollider capsuleCollider; // Düþmanýn kapsül collider'ý

    void Start()
    {
        // Baþlangýçta caný maksimum deðere ayarla
        currentHealth = maxHealth;

        // Bileþenleri bul ve referans al
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyBehavior = GetComponent<EnemyBehavior>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bullet hit the enemy!");
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Diðer iþlemler
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
        }
        if (enemyBehavior != null)
        {
            enemyBehavior.enabled = false;
        }
        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = false;
        }

        // Chip kazandýrma
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddChip();
        }

        // Düþmaný yok et
        Destroy(gameObject, 2f); // Örneðin, 2 saniye sonra yok edebiliriz
    }

}
