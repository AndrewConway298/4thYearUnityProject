//X00121654 Andrew Conway 4th Year Project
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    public GameObject username;
    public GameObject password;
    public static string Username;
    private string Password;

    public void LoginButton()
    {
        StartCoroutine(GetData());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                LoginButton();
            }
        }
        //Setting Inputs
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

    IEnumerator GetData()
    {
        Debug.Log("Sending data request");
        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        form.AddField("Password", Password);
        UnityWebRequest www = UnityWebRequest.Post("http://sharepointgames.azurewebsites.net/Player/UnityLogin", form);
        www.chunkedTransfer = false;
        Debug.Log(Username);
        yield return www.Send();
        PlayerPrefs.SetString("Username", Username);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log("Got the data!");
            Debug.Log(www.downloadHandler.text);
        }
    }
}
