using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imageToActivate; // Devreye girmesi gereken image

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare butonun üzerine geldiðinde image aktif hale gelir
        if (imageToActivate != null)
            imageToActivate.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare butondan çýktýðýnda image devre dýþý olur
        if (imageToActivate != null)
            imageToActivate.SetActive(false);
    }
}
