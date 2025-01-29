using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItems : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float flySpeed, rotateSpeed;


    public void Init(int dmg)
    {
        damage = dmg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }

    }

     void Update()
    {
        Rotate();
        FlyForward();
    }

     void Rotate()
    {
        graphics.Rotate(new Vector3(0, 0, -rotateSpeed*Time.deltaTime));
    }
    void FlyForward()
    {
        transform.Translate(transform.right*flySpeed*Time.deltaTime);
    }
}
