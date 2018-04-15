using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    //Variables
    public GameObject bullet_prefab;

    public int enemHit = 0;
    public static int score = 0;
    public int highScore;

    public float range = 100.0f;

    public float bulletCooldown = 0.1f;
    float cooldownTimeRemaining = 0;

    public float bulletDamage = 10.0f;

	void Update () {
        cooldownTimeRemaining -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1") || Input.GetButton("Fire2") && cooldownTimeRemaining <= 0)
        {
            cooldownTimeRemaining = bulletCooldown;
            Ray r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(r, out hitInfo, range))
            {
                Vector3 hitTarget = hitInfo.point;
                GameObject hitOb = hitInfo.collider.gameObject;
                Debug.Log("Hit Object: " + hitOb.name);

                EnemyHealth enemHealth = hitOb.GetComponent<EnemyHealth>();

                if (enemHealth != null)
                {
                    enemHealth.TakeDamage(bulletDamage);
                    enemHit++;
                    if(enemHit > 9)
                    {
                        enemHit = 0;
                        score++;
                        Debug.Log("Score is: " + score);
                    }
                }

                if (bullet_prefab != null)
                {
                    Instantiate(bullet_prefab, hitTarget, Quaternion.identity);
                }
            }
        }
	}
}
