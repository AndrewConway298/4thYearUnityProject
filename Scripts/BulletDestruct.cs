using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruct : MonoBehaviour {

    public float duration = 0.01f;
	
	// Update is called once per frame
	void Update () {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            Destroy(gameObject);
        }
	}
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //collision.gameObject.tag = "Untagged";
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //    //Destroy(gameObject);
    //}
}
