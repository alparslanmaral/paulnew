using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;
    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �lk �arp�lan hedefe yap��may� sa�la
        if (targetHit)
            return;

        targetHit = true;

        // D��mana �arp�p �arpmad���n� kontrol et
        BasicEnemyDone enemy = collision.gameObject.GetComponent<BasicEnemyDone>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            // Mermiyi yok et
            Destroy(gameObject);
            return;
        }

        // Hedefe yap��ma i�lemini ger�ekle�tir
        rb.isKinematic = true;

        // Mermiyi �arp�lan nesnenin �ocu�u yaparak yap��mas�n� sa�la
        transform.SetParent(collision.transform);
    }
}
