using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using TMPro;

public class Enemy : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;

    public Animator animator;
    public float attackInterval;
    Coroutine attackOrder;
    Tower detectedTower;

    private UIManager uiManager;

    void Start()
    {
        // Найдите компонент UIManager в сцене
        uiManager = FindObjectOfType<UIManager>();
        // Обновите текст жизней при старте
       // uiManager.UpdateHeartText();
    }

    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
    }

    IEnumerator Attack()
    {
        while (detectedTower)
        {
            animator.Play("Attack");
            yield return new WaitForSeconds(attackInterval);
            InflictDamage(); // Наносим урон
        }
    }

    void Move()
    {
        animator.Play("Move", 0, 0);
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public void InflictDamage()
    {
        if (detectedTower)
        {
            bool towerDied = detectedTower.LoseHealth(attackPower);

            if (towerDied)
            {
                detectedTower = null;
                StopCoroutine(attackOrder);
            }
        }
    }

    public void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());

        if (health <= 0)
            Destroy(gameObject);
    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.6f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tower" && detectedTower == null)
        {
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }

        if (collision.tag == "ExitEnemy")
        {
            HandleExitEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tower" && detectedTower != null)
        {
            detectedTower = null;
            StopCoroutine(attackOrder);
        }
    }

    private void HandleExitEnemy()
    {
        uiManager.Heart(); // Уменьшаем жизни через UIManager
        Destroy(gameObject);
    }
}