using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaMachine : MonoBehaviour
{
  
    [Header("Prefab")]
    [SerializeField] private GameObject canPrefab;

    [Header("Location")]
    [SerializeField] private GameObject spawnPoint;

    private float spawnTime = .1f;
    bool canSpawn = true;

    private void Start()
    {
        Instantiate(canPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (canSpawn)
        {
            Instantiate(canPrefab, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTimer());
        }
    }

    private IEnumerator SpawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
