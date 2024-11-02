using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer'ý göstereceðimiz TextMeshPro öðesi
    public string buyMenuSceneName = "BuyMenu"; // BuyMenu sahnesinin adý
    public float gameTime = 300f; // 5 dakika (300 saniye)

    private float currentTime;

    void Start()
    {
        // Baþlangýç zamaný ayarla
        currentTime = gameTime;
        DontDestroyOnLoad(gameObject); // GameManager yok edilmez

        // Cursor'u kilitle ve gizle
        LockCursor();

        // Timer UI'ý güncelle
        UpdateTimerUI();
    }

    void Update()
    {
        // Süreyi azalt
        currentTime -= Time.deltaTime;

        // UI'ý güncelle
        UpdateTimerUI();

        // Süre sýfýra düþtüðünde BuyMenu sahnesine geçiþ yap
        if (currentTime <= 0)
        {
            GoToBuyMenu();
        }
    }

    public void AddChip()
    {
        ChipManager.Instance.AddChips(1); // ChipManager üzerinden chip ekleyin
        Debug.Log("Chip Count: " + ChipManager.Instance.chipCount);
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}"; // Dakika ve saniye gösterim formatý
    }

    void GoToBuyMenu()
    {
        // BuyMenu sahnesine geçiþ yap ve cursor'u aç
        SceneManager.LoadScene(buyMenuSceneName);
        UnlockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Ýmleci kilitle
        Cursor.visible = false; // Ýmleci gizle
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Ýmleci serbest býrak
        Cursor.visible = true; // Ýmleci görünür yap
    }
}
