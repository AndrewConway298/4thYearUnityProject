//X00121654 Andrew Conway 4th Year Project
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {
    //public variables
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirmPassword;
    //private variables
    private string Username;
    private string Email;
    private string Password;
    private string ConfirmPassword;

	
    //Register Button Submit
    public void RegisterButton()
    {
        StartCoroutine(Upload());
    }

	void Update () {
        //Tab Fuction
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            else if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            else if (password.GetComponent<InputField>().isFocused)
            {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
        //Enter for sumbit
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Email != "" && 
                Password != "" && ConfirmPassword != "")
            {
                RegisterButton();
            }
        }
        //Setting inputs
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
    }

    //Sending Data to DB
    IEnumerator Upload()
    {
        Debug.Log("Sending data request");
        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        form.AddField("Email", Email);
        form.AddField("Password", Password);
        //ScoresWebsite
        UnityWebRequest www = UnityWebRequest.Post("http://sharepointgames.azurewebsites.net/Player/UnityRegister", form);
        
        www.chunkedTransfer = false;
        Debug.Log(Username);
        yield return www.Send();

        Debug.Log(form.ToString());
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data: " + www.downloadHandler.text);
        }
    }
}
