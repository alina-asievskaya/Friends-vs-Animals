using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Complexity : MonoBehaviour
{
   public GameObject LevelsMenu;
    public GameObject SettingImg;
    public GameObject PauseMenu;
    public GameObject WinPanel;

    public void Start()
    {
        Time.timeScale = 0f;
        SettingImg.SetActive(false);
        PauseMenu.SetActive(false);
        WinPanel.SetActive(false); // Скрываем панель победы при старте
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EasyLevel()
    {
        StartLevel(10, 0.2f);
    }

    public void NormalLevel()
    {
        StartLevel(15, 0.5f);
    }

    public void HardLevel()
    {
        StartLevel(20, 0.8f);
    }

    private void StartLevel(int enemyCount, float enemySpeed)
    {
        Time.timeScale = 1f;
        SettingImg.SetActive(true);
        PauseMenu.SetActive(true);
        EnemySpawner.Instance.StartSpawning(enemyCount, enemySpeed);
        LevelsMenu.SetActive(false);
    }

    public void Winner()
    {
        if (EnemySpawner.Instance.AreEnemiesDefeated())
        {
            StartCoroutine(ShowWinPanel());
        }
    }

    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0f;
        WinPanel.SetActive(true);
    }
}
