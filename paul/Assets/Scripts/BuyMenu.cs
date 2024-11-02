using UnityEngine;
using UnityEngine.UI;

public class BuyMenu : MonoBehaviour
{
    //     `;-.          ___,
    //       `.`\_...._/`.-"`
    //         \        /      ,
    //         /() () \    .' `-._
    //        |)  .    ()\  /   _.'
    //        \  -'-     ,; '. <
    //         ;.__     ,;|   > \
    //        / ,    / ,  |.-'.-'
    //       (_/    (_/ ,;|.<`
    //         \    ,     ;-`
    //          >   \    /
    //        (_,-'`> .'

    public GameObject playerPrefab; // Player prefab'ýný buraya baðlayýn
    private PlayerMovement playerMovement; // PlayerMovement referansý
    public Button upgradeButton; // Hýz artýrma butonu

    private void Start()
    {
        // Player prefab'ýndan PlayerMovement bileþenini al
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();

        // Butona týklama olayý ekle
        upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }

    private void OnUpgradeButtonClicked()
    {
        // ChipManager üzerinden chip sayýsýný kontrol et
        if (ChipManager.Instance.SpendChip(1)) // Yeterli chip var mý kontrol et
        {
            playerMovement.moveSpeed += 1000; // Hýzý artýr
            Debug.Log("Speed upgraded! New speed: " + playerMovement.moveSpeed);
        }
        else
        {
            Debug.Log("Not enough chips!");
        }
    }
}
