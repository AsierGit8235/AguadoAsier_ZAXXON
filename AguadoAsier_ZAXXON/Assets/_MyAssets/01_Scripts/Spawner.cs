using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float interval = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float posX = Random.Range(-17f, 17f);
            float posY = Random.Range(-1f, 17f);
            Vector3 pos = new Vector3();
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
        
    }
    }
