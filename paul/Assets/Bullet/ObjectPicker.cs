using UnityEngine;
using UnityEngine.UI;

public class ObjectPicker : MonoBehaviour
{
    public float pickupRange = 2f;
    public Image[] inventorySlots; // 3 slot için image dizisi
    private int nextEmptySlot = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Oyuncunun ileri doðru baktýðý yön
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
            {
                if (hit.collider.CompareTag("PickableObject")) // Objelerin tag'i PickableObject
                {
                    PickupObject(hit.collider.gameObject);
                }
            }
        }
    }

    void PickupObject(GameObject obj)
    {
        if (nextEmptySlot < inventorySlots.Length)
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Slot'a sprite'ý ekle
                inventorySlots[nextEmptySlot].sprite = spriteRenderer.sprite;
                inventorySlots[nextEmptySlot].enabled = true; // Slot görünür olsun

                // Sýradaki boþ slota geç
                nextEmptySlot++;

                // Objeyi oyun alanýndan kaldýr
                Destroy(obj);
            }
        }
    }
}
