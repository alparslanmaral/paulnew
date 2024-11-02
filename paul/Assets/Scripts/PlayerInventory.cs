using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject M1, M2, M3; // Canvas üzerindeki mermi görselleri
    public GameObject bulletPrefab; // Fýrlatýlacak mermi prefabý
    public float collectRange = 2.0f; // Mermiyi toplamak için gereken mesafe
    public int maxBullets = 3; // Maksimum mermi sayýsý

    private int currentBullets = 0; // Mevcut mermi sayýsý

    void Update()
    {
        // F tuþuna basarak mermi toplama
        if (Input.GetKeyDown(KeyCode.F))
        {
            CollectBullet();
        }

        // Sað týk ile mermi fýrlatma
        if (Input.GetMouseButtonDown(1) && currentBullets > 0)
        {
            FireBullet();
        }

        // Mermi görsellerini güncelleme
        UpdateBulletImages();
    }

    void CollectBullet()
    {
        // Oyuncunun etrafýndaki MB tagli objeleri bul
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, collectRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("MB"))
            {
                if (currentBullets < maxBullets)
                {
                    currentBullets++;
                    Destroy(hitCollider.gameObject); // MB objesini yok et
                }
                break;
            }
        }
    }

    void UpdateBulletImages()
    {
        M1.SetActive(currentBullets >= 1);
        M2.SetActive(currentBullets >= 2);
        M3.SetActive(currentBullets >= 3);
    }

    void FireBullet()
    {
        currentBullets--; // Mermiyi envanterden çýkar

        // Mermiyi oyuncunun baktýðý yöne doðru fýrlat
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 500); // Fýrlatma gücü

        UpdateBulletImages(); // Görselleri güncelle
    }
}
