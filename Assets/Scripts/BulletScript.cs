using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float deathTime = 2f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 7;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Can"))
        {
            collision.rigidbody.AddForceAtPosition(transform.forward.normalized * 2, collision.contacts[0].point, ForceMode.Impulse);
            ScoreController.instance.IncreaseScore();
           
        }
        StartCoroutine(StartDeathTime());
    }

    private IEnumerator StartDeathTime()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
