using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBuy : MonoBehaviour
{
    //                            ,-.                               
    //___,---.__          /'|`\          __,---,___          
    // ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.       
    // ,'        |           ~'\     /`~           |        `.      
    // /      ___//              `. ,'          ,  , \___      \    
    //|    ,-'   `-.__   _         |        ,    __,-'   `-.    |    
    //|   /          /\_  `   .    |    ,      _/\          \   |   
    //\  |           \ \`-.___ \   |   / ___,-'/ /           |  /  
    //\  \           | `._   `\\  |  //'   _,' |           /  /      
    //`-.\         /'  _ `---'' , . ``---' _  `\         /,-'     
    //   ``       /     \    ,='/ \`=.    /     \       ''          
    //          |__   /|\_,--.,-.--,--._/|\   __|                  
    //          /  `./  \\`\ |  |  | /,//' \,'  \                  
    //eViL        /   /     ||--+--|--+-/-|     \   \                 
    //          |   |     /'\_\_\ | /_/_/`\     |   |                
    //          \   \__, \_     `~'     _/ .__/   /            
    //           `-._,-'   `-._______,-'   `-._,-'

    public GameObject playerPrefab; // Player prefab'ýný buraya baðlayýn
    private PlayerMovement playerMovement; // PlayerMovement referansý
    public Button jumpButton; // Hýz artýrma butonu

    private void Start()
    {
        // Player prefab'ýndan PlayerMovement bileþenini al
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();

        // Butona týklama olayý ekle
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    private void OnJumpButtonClicked()
    {
        // ChipManager üzerinden chip sayýsýný kontrol et
        if (ChipManager.Instance.SpendChip(1)) // Yeterli chip var mý kontrol et
        {
            playerMovement.jumpForce += 120; // Hýzý artýr
            Debug.Log("Jump upgraded! New jump: " + playerMovement.jumpForce);
        }
        else
        {
            Debug.Log("Not enough chips!");
        }
    }
}