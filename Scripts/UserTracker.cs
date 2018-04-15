using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserTracker : MonoBehaviour {

    public static string curUser;

    public Text userText;

	// Update is called once per frame
	void Update () {
        curUser = Login.Username;
        userText.text = curUser;
	}
}
