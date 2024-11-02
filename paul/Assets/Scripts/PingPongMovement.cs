using UnityEngine;

public class TeleportMovement : MonoBehaviour
{
    public float distance = 120f; // Ýleri gitme mesafesi
    public float speed = 5f;      // Hareket hýzý

    private Vector3 startPos;     // Baþlangýç pozisyonu
    private Vector3 targetPos;    // Hedef pozisyonu

    void Start()
    {
        startPos = transform.position;         // Baþlangýç pozisyonunu kaydet
        targetPos = startPos + transform.forward * distance; // Ýleri hedef pozisyonunu hesapla
    }

    void Update()
    {
        // Objeyi hedef pozisyona doðru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Hedef pozisyona ulaþtýðýnda baþlangýç pozisyonuna ýþýnlan
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            transform.position = startPos;
        }
    }
}
