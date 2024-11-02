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

    public GameObject playerPrefab; // Player prefab'�n� buraya ba�lay�n
    private PlayerMovement playerMovement; // PlayerMovement referans�
    public Button jumpButton; // H�z art�rma butonu

    private void Start()
    {
        // Player prefab'�ndan PlayerMovement bile�enini al
        playerMovement = playerPrefab.GetComponent<PlayerMovement>();

        // Butona t�klama olay� ekle
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    private void OnJumpButtonClicked()
    {
        // ChipManager �zerinden chip say�s�n� kontrol et
        if (ChipManager.Instance.SpendChip(1)) // Yeterli chip var m� kontrol et
        {
            playerMovement.jumpForce += 120; // H�z� art�r
            Debug.Log("Jump upgraded! New jump: " + playerMovement.jumpForce);
        }
        else
        {
            Debug.Log("Not enough chips!");
        }
    }
}