using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public int maxHealth = 100;
    public int attack = 20;
    private int health;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
   public void TakeDamage()
    {
        health -= attack;
        if (health <= 0)
        {

        }
    }
}
