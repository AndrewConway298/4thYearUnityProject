using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private string plyrName;
    private int curScore;

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Logout()
    {
        StartCoroutine(SendScore());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SendScore()
    {
        plyrName = UserTracker.curUser;
        curScore = PlayerHealth.currentScore;
        WWWForm form = new WWWForm();
        form.AddField("Username", plyrName);
        form.AddField("Score", curScore);
        //ScoresWebsite
        Debug.Log("Name = " + plyrName);
        Debug.Log("Score = " + curScore);
        UnityWebRequest www = UnityWebRequest.Post("http://sharepointgames.azurewebsites.net/Player/UnityUpdateScore", form);
        www.chunkedTransfer = false;
        yield return www.Send();
    }
}
