using UnityEngine;
using UnityEngine.UI;

public class BulletPickUp : MonoBehaviour
{
    public Image[] bulletSlots; // Bullet Canvas �zerindeki image slotlar�n� buraya ekleyin
    private int currentSlotIndex = 0; // Hangi slotun a��laca��n� takip eder
    private bool canPickup = false; // Pickup yap�l�p yap�lamayaca��n� kontrol etmek i�in
    private GameObject pickableObject; // Pickable objenin referans�

    void Update()
    {
        // Oyuncu pickup menzilindeyse ve F tu�una basarsa
        if (canPickup && Input.GetKeyDown(KeyCode.F))
        {
            PickupBullet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er objenin tag'i "PickableObject" ise pickup yap�labilir hale getir
        if (other.CompareTag("PickableObject"))
        {
            canPickup = true;
            pickableObject = other.gameObject; // Obje referans�n� saklay�n
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Pickup objesinden uzakla��ld���nda pickup yap�lamaz hale getir
        if (other.CompareTag("PickableObject"))
        {
            canPickup = false;
            pickableObject = null; // Referans� s�f�rlay�n
        }
    }

    void PickupBullet()
    {
        // Slot a�ma i�lemi
        if (currentSlotIndex < bulletSlots.Length)
        {
            bulletSlots[currentSlotIndex].enabled = true; // Slotu aktif hale getir
            currentSlotIndex++; // Sonraki slot i�in indexi artt�r
        }

        // Objenin yok edilmesi
        if (pickableObject != null)
        {
            Destroy(pickableObject);
        }
    }
}
