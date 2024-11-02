using UnityEngine;
using UnityEngine.UI;

public class BulletPickUp : MonoBehaviour
{
    public Image[] bulletSlots; // Bullet Canvas üzerindeki image slotlarýný buraya ekleyin
    private int currentSlotIndex = 0; // Hangi slotun açýlacaðýný takip eder
    private bool canPickup = false; // Pickup yapýlýp yapýlamayacaðýný kontrol etmek için
    private GameObject pickableObject; // Pickable objenin referansý

    void Update()
    {
        // Oyuncu pickup menzilindeyse ve F tuþuna basarsa
        if (canPickup && Input.GetKeyDown(KeyCode.F))
        {
            PickupBullet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer objenin tag'i "PickableObject" ise pickup yapýlabilir hale getir
        if (other.CompareTag("PickableObject"))
        {
            canPickup = true;
            pickableObject = other.gameObject; // Obje referansýný saklayýn
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Pickup objesinden uzaklaþýldýðýnda pickup yapýlamaz hale getir
        if (other.CompareTag("PickableObject"))
        {
            canPickup = false;
            pickableObject = null; // Referansý sýfýrlayýn
        }
    }

    void PickupBullet()
    {
        // Slot açma iþlemi
        if (currentSlotIndex < bulletSlots.Length)
        {
            bulletSlots[currentSlotIndex].enabled = true; // Slotu aktif hale getir
            currentSlotIndex++; // Sonraki slot için indexi arttýr
        }

        // Objenin yok edilmesi
        if (pickableObject != null)
        {
            Destroy(pickableObject);
        }
    }
}
