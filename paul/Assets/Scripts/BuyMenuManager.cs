using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyMenuManager : MonoBehaviour
{
    public string mainMapSceneName = "AnaMap"; // AnaMap sahnesinin ad�

    public void ReturnToMainMap()
    {
        SceneManager.LoadScene(mainMapSceneName); // AnaMap sahnesine ge�i� yap
    }
}
