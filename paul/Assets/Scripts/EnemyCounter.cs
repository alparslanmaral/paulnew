using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText; // Buraya sahnedeki TextMeshPro objesini ba�layaca��z
    public string endSceneName = "End";    // D��man kalmad���nda ge�ilecek sahnenin ismi

    private void Update()
    {
        // Enemy tagli objelerin say�s�n� al
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Enemy say�s�n� TextMeshPro'ya yazd�r
        enemyCountText.text = "Enemies Left: " + enemyCount;

        // E�er enemy kalmad�ysa belirtilen sahneye ge�
        if (enemyCount == 0)
        {
            SceneManager.LoadScene(endSceneName);
        }
    }
}
