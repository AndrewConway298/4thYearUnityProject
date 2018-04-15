using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    float rotSpeed = 3.0f;
    float enemSpeed = 3.0f;
    float targetRange = 1.0f;
    float attack = 1.0f;
    float attackLeft;

    Transform targetAttacking;

    // Use this for initialization
    void Start () {
        targetAttacking = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //Looking for Player
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(targetAttacking.position - transform.position),
            rotSpeed * Time.deltaTime);
        //Moving to Player
        transform.position += transform.forward * enemSpeed * Time.deltaTime;
        //Attacking Player
        if(Vector3.Distance(transform.position, targetAttacking.position) <= targetRange)
        {
            Attack(targetAttacking);
        }
        if(attackLeft > 0.0f)
        {
            attackLeft -= Time.deltaTime;
        }
    }

    public void Attack(Transform target)
    {
        if(attackLeft <= 0.0f)
        {
            PlayerHealth plyrHealth = target.GetComponent<PlayerHealth>();
            attackLeft = attack;
            if (plyrHealth != null)
            {
                plyrHealth.TakeDamage(10.0f);
            }
        }
    }

}
