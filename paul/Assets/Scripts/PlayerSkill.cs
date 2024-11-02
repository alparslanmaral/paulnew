using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public float detectionRadius = 2f;
    public float skillCooldown = 5f;
    public Slider cooldownSlider;

    private bool canUseSkill = true;

    void Update()
    {
        // E tu�una bas�ld���nda yetenek kullan�labilir mi diye kontrol eder
        if (Input.GetKeyDown(KeyCode.E) && canUseSkill)
        {
            UseSkill();
        }

        // Cooldown s�resini slider ile g�ncelle
        if (!canUseSkill)
        {
            cooldownSlider.value += Time.deltaTime / skillCooldown;
        }
    }

    void UseSkill()
    {
        canUseSkill = false;
        cooldownSlider.value = 0;

        // �evredeki Enemy tagli objeleri alg�la
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
                if (enemyBehavior != null)
                {
                    enemyBehavior.isDetected = true;
                }
            }
        }

        // Cooldown s�recini ba�lat
        StartCoroutine(SkillCooldown());
    }

    IEnumerator SkillCooldown()
    {
        yield return new WaitForSeconds(skillCooldown);
        canUseSkill = true;
    }
}
