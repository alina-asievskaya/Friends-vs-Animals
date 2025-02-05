using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public int heart = 5;
    public TMP_Text heartText;

    public void UpdateHeartText(int hearts)
    {
        heartText.text = hearts.ToString();
    }


    public void Heart()
    {
        heart--;
        UpdateHeartText(heart);

        if (heart <= 0)
        {
            // Здесь можно вызвать метод для завершения игры
            Debug.Log("Game Over!"); // Пример
            SceneManager.LoadScene("Menu"); // Разкомментируйте, если нужно
        }
    }
}
