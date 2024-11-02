using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer'� g�sterece�imiz TextMeshPro ��esi
    public string buyMenuSceneName = "BuyMenu"; // BuyMenu sahnesinin ad�
    public float gameTime = 300f; // 5 dakika (300 saniye)

    private float currentTime;

    void Start()
    {
        // Ba�lang�� zaman� ayarla
        currentTime = gameTime;
        DontDestroyOnLoad(gameObject); // GameManager yok edilmez

        // Cursor'u kilitle ve gizle
        LockCursor();

        // Timer UI'� g�ncelle
        UpdateTimerUI();
    }

    void Update()
    {
        // S�reyi azalt
        currentTime -= Time.deltaTime;

        // UI'� g�ncelle
        UpdateTimerUI();

        // S�re s�f�ra d��t���nde BuyMenu sahnesine ge�i� yap
        if (currentTime <= 0)
        {
            GoToBuyMenu();
        }
    }

    public void AddChip()
    {
        ChipManager.Instance.AddChips(1); // ChipManager �zerinden chip ekleyin
        Debug.Log("Chip Count: " + ChipManager.Instance.chipCount);
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}"; // Dakika ve saniye g�sterim format�
    }

    void GoToBuyMenu()
    {
        // BuyMenu sahnesine ge�i� yap ve cursor'u a�
        SceneManager.LoadScene(buyMenuSceneName);
        UnlockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // �mleci kilitle
        Cursor.visible = false; // �mleci gizle
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // �mleci serbest b�rak
        Cursor.visible = true; // �mleci g�r�n�r yap
    }
}
