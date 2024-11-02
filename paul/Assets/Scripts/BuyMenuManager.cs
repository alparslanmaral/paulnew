using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyMenuManager : MonoBehaviour
{
    public string mainMapSceneName = "AnaMap"; // AnaMap sahnesinin adý

    public void ReturnToMainMap()
    {
        SceneManager.LoadScene(mainMapSceneName); // AnaMap sahnesine geçiþ yap
    }
}
