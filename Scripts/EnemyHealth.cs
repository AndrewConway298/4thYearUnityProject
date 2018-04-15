using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    //Variables
    public float enemyHealth = 100.0f;

    //Takes damage from bullet
    public void TakeDamage(float dmgIn)
    {
        enemyHealth -= dmgIn;
        if(enemyHealth <= 0)
        {
            Die();
        }
    }

     void Die()
    {
        Destroy(gameObject);
    }

}
