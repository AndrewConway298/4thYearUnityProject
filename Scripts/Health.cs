using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Text healthText;

    // Update is called once per frame
    public void Update()
    {
        healthText.text = PlayerHealth.playerHealth.ToString();
    }

}
