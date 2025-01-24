using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text lifeCountText;
    public int defaultHealthCount;
    public int healthCount;

    public void Init()
    {
        healthCount = defaultHealthCount;
        lifeCountText.text = healthCount.ToString();
    }

    public void LoseHeart()
    {
        if (healthCount < 1)
            return;

        healthCount--;
        lifeCountText.text = healthCount.ToString();

        CheckHealthCount(); 
    }

    public void CheckHealthCount()
    {
        if(healthCount < 1)
        {
            Debug.Log("loser");
        }
      
    }

}
