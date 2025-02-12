using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complexity : MonoBehaviour
{
    public GameObject LevelsMenu;
    public void Start()
    {
        Time.timeScale = 0f;
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EasyLevel()
    {
        Time.timeScale = 1f;
        EnemySpawner.Instance.StartSpawning(10, 0.2f); 
        LevelsMenu.SetActive(false);
    }

    public void NormalLevel()
    {
        Time.timeScale = 1f;
        EnemySpawner.Instance.StartSpawning(15, 0.5f); 
        LevelsMenu.SetActive(false);

    }

    public void HardLevel()
    {
        Time.timeScale = 1f;
        EnemySpawner.Instance.StartSpawning(20, 0.8f); 
        LevelsMenu.SetActive(false);

    }
}
