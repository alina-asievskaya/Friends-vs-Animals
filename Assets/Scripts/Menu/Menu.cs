using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeScenes(string sceneMenu)
    {
        SceneManager.LoadScene(sceneMenu);
    }
}
