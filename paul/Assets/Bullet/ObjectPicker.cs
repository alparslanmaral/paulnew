using UnityEngine;
using UnityEngine.UI;

public class ObjectPicker : MonoBehaviour
{
    public float pickupRange = 2f;
    public Image[] inventorySlots; // 3 slot i�in image dizisi
    private int nextEmptySlot = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Oyuncunun ileri do�ru bakt��� y�n
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
                // Slot'a sprite'� ekle
                inventorySlots[nextEmptySlot].sprite = spriteRenderer.sprite;
                inventorySlots[nextEmptySlot].enabled = true; // Slot g�r�n�r olsun

                // S�radaki bo� slota ge�
                nextEmptySlot++;

                // Objeyi oyun alan�ndan kald�r
                Destroy(obj);
            }
        }
    }
}
