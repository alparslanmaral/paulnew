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
        // Ýlk çarpýlan hedefe yapýþmayý saðla
        if (targetHit)
            return;

        targetHit = true;

        // Düþmana çarpýp çarpmadýðýný kontrol et
        BasicEnemyDone enemy = collision.gameObject.GetComponent<BasicEnemyDone>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            // Mermiyi yok et
            Destroy(gameObject);
            return;
        }

        // Hedefe yapýþma iþlemini gerçekleþtir
        rb.isKinematic = true;

        // Mermiyi çarpýlan nesnenin çocuðu yaparak yapýþmasýný saðla
        transform.SetParent(collision.transform);
    }
}
