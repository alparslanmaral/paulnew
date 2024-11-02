using UnityEngine;
using UnityEngine.UI;

public class ImageToggleOnHold : MonoBehaviour
{
    public Image targetImage; // Devre dýþý býrakmak istediðin Image nesnesini buraya sürükle

    void Update()
    {
        if (Input.GetMouseButton(0)) // Sol týk basýlý tutuluyorsa
        {
            targetImage.enabled = false; // Image'i devre dýþý býrak
        }
        else // Sol týk býrakýldýðýnda
        {
            targetImage.enabled = true; // Image'i etkinleþtir
        }
    }
}
