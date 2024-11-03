using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText; // Buraya sahnedeki TextMeshPro objesini baðlayacaðýz
    public string endSceneName = "End";    // Düþman kalmadýðýnda geçilecek sahnenin ismi

    private void Update()
    {
        // Enemy tagli objelerin sayýsýný al
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Enemy sayýsýný TextMeshPro'ya yazdýr
        enemyCountText.text = "Enemies Left: " + enemyCount;

        // Eðer enemy kalmadýysa belirtilen sahneye geç
        if (enemyCount == 0)
        {
            SceneManager.LoadScene(endSceneName);
        }
    }
}
