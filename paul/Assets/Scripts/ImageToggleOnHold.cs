using UnityEngine;
using UnityEngine.UI;

public class ImageToggleOnHold : MonoBehaviour
{
    public Image targetImage; // Devre d��� b�rakmak istedi�in Image nesnesini buraya s�r�kle

    void Update()
    {
        if (Input.GetMouseButton(0)) // Sol t�k bas�l� tutuluyorsa
        {
            targetImage.enabled = false; // Image'i devre d��� b�rak
        }
        else // Sol t�k b�rak�ld���nda
        {
            targetImage.enabled = true; // Image'i etkinle�tir
        }
    }
}
