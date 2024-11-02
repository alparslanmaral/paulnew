using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotationSpeed = 500f; // X eksenindeki döndürme hýzý

    void Update()
    {
        // Mermiyi x ekseninde döndür
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    void Start()
    {
        // 5 saniye sonra mermiyi yok et
        Destroy(gameObject, 5f);
    }
}
