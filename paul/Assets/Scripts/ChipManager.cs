using UnityEngine;

public class ChipManager : MonoBehaviour
{
    public static ChipManager Instance; // Singleton örneði

    public int chipCount = 0; // Chip sayýsý

    private void Awake()
    {
        // Singleton kontrolü
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Bu objeyi sahneler arasýnda kalýcý yap
        }
        else
        {
            Destroy(gameObject); // Eðer bir örnek varsa, mevcut olaný yok et
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

    // Chip sayýsýný kaydetme ve yükleme fonksiyonlarý ekleyebilirsiniz
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
        SaveChips(); // Uygulama kapanýrken chip sayýsýný kaydet
    }

}
