using UnityEngine;

public class TeleportMovement : MonoBehaviour
{
    public float distance = 120f; // �leri gitme mesafesi
    public float speed = 5f;      // Hareket h�z�

    private Vector3 startPos;     // Ba�lang�� pozisyonu
    private Vector3 targetPos;    // Hedef pozisyonu

    void Start()
    {
        startPos = transform.position;         // Ba�lang�� pozisyonunu kaydet
        targetPos = startPos + transform.forward * distance; // �leri hedef pozisyonunu hesapla
    }

    void Update()
    {
        // Objeyi hedef pozisyona do�ru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Hedef pozisyona ula�t���nda ba�lang�� pozisyonuna ���nlan
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            transform.position = startPos;
        }
    }
}
