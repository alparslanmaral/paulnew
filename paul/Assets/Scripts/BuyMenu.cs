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

    public GameObject playerPrefab; // Player prefab'�n� buraya ba�lay�n
    private PlayerMovement playerMovement; // PlayerMovement referans�
    public Button upgradeButton; // H�z art�rma butonu

    private void Start()
    {
        // Player prefab'�ndan PlayerMovement bile�enini al
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();

        // Butona t�klama olay� ekle
        upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }

    private void OnUpgradeButtonClicked()
    {
        // ChipManager �zerinden chip say�s�n� kontrol et
        if (ChipManager.Instance.SpendChip(1)) // Yeterli chip var m� kontrol et
        {
            playerMovement.moveSpeed += 1000; // H�z� art�r
            Debug.Log("Speed upgraded! New speed: " + playerMovement.moveSpeed);
        }
        else
        {
            Debug.Log("Not enough chips!");
        }
    }
}
