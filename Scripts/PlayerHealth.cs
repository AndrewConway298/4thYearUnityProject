using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    //Variables
    public static float playerHealth = 250.0f;
    public static int currentScore;
    public int highScore;
    private string plyrName;

    //Takes damage from bullet
    public void TakeDamage(float dmgIn)
    {
        playerHealth -= dmgIn;
        Debug.Log("Player Health: " + playerHealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("The enemy has killed you!");
        CheckScore();
        Destroy(gameObject);
        Screen.lockCursor = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    void CheckScore()
    {
        currentScore = PlayerShooting.score;
    }

}
