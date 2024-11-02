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
        // E tuþuna basýldýðýnda yetenek kullanýlabilir mi diye kontrol eder
        if (Input.GetKeyDown(KeyCode.E) && canUseSkill)
        {
            UseSkill();
        }

        // Cooldown süresini slider ile güncelle
        if (!canUseSkill)
        {
            cooldownSlider.value += Time.deltaTime / skillCooldown;
        }
    }

    void UseSkill()
    {
        canUseSkill = false;
        cooldownSlider.value = 0;

        // Çevredeki Enemy tagli objeleri algýla
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

        // Cooldown sürecini baþlat
        StartCoroutine(SkillCooldown());
    }

    IEnumerator SkillCooldown()
    {
        yield return new WaitForSeconds(skillCooldown);
        canUseSkill = true;
    }
}
