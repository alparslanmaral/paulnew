using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject M1, M2, M3; // Canvas �zerindeki mermi g�rselleri
    public GameObject bulletPrefab; // F�rlat�lacak mermi prefab�
    public float collectRange = 2.0f; // Mermiyi toplamak i�in gereken mesafe
    public int maxBullets = 3; // Maksimum mermi say�s�

    private int currentBullets = 0; // Mevcut mermi say�s�

    void Update()
    {
        // F tu�una basarak mermi toplama
        if (Input.GetKeyDown(KeyCode.F))
        {
            CollectBullet();
        }

        // Sa� t�k ile mermi f�rlatma
        if (Input.GetMouseButtonDown(1) && currentBullets > 0)
        {
            FireBullet();
        }

        // Mermi g�rsellerini g�ncelleme
        UpdateBulletImages();
    }

    void CollectBullet()
    {
        // Oyuncunun etraf�ndaki MB tagli objeleri bul
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
        currentBullets--; // Mermiyi envanterden ��kar

        // Mermiyi oyuncunun bakt��� y�ne do�ru f�rlat
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 500); // F�rlatma g�c�

        UpdateBulletImages(); // G�rselleri g�ncelle
    }
}
