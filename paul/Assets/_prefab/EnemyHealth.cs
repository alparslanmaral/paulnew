using UnityEngine;
using UnityEngine.AI; // NavMeshAgent i�in gerekli

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // D��man�n maksimum can�
    private int currentHealth;
    private Animator animator; // Animat�r bile�eni
    private NavMeshAgent navMeshAgent; // NavMeshAgent bile�eni
    private EnemyBehavior enemyBehavior; // D��man�n davran�� script'i
    private CapsuleCollider capsuleCollider; // D��man�n kaps�l collider'�

    void Start()
    {
        // Ba�lang��ta can� maksimum de�ere ayarla
        currentHealth = maxHealth;

        // Bile�enleri bul ve referans al
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
        // Di�er i�lemler
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

        // Chip kazand�rma
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddChip();
        }

        // D��man� yok et
        Destroy(gameObject, 2f); // �rne�in, 2 saniye sonra yok edebiliriz
    }

}
