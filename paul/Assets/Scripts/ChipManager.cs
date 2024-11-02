using UnityEngine;

public class ChipManager : MonoBehaviour
{
    public static ChipManager Instance; // Singleton �rne�i

    public int chipCount = 0; // Chip say�s�

    private void Awake()
    {
        // Singleton kontrol�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Bu objeyi sahneler aras�nda kal�c� yap
        }
        else
        {
            Destroy(gameObject); // E�er bir �rnek varsa, mevcut olan� yok et
        }
    }

    public void AddChips(int amount)
    {
        chipCount += amount;
    }

    public bool SpendChip(int amount)
    {
        if (chipCount >= amount)
        {
            chipCount -= amount;
            return true;
        }
        return false;
    }

    // Chip say�s�n� kaydetme ve y�kleme fonksiyonlar� ekleyebilirsiniz
    public void SaveChips()
    {
        PlayerPrefs.SetInt("ChipCount", chipCount);
        PlayerPrefs.Save();
    }

    public void LoadChips()
    {
        chipCount = PlayerPrefs.GetInt("ChipCount", 0);
    }

    private void OnApplicationQuit()
    {
        SaveChips(); // Uygulama kapan�rken chip say�s�n� kaydet
    }

}
