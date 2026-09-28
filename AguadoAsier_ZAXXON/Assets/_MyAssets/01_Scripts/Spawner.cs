using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float interval = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //enemigos intermedios
    [SerializeField] float firstEnemyPositionZ = 500f;
    [SerializeField] float distanceBetweenEnemies = 15f;

    //PlayerManager
    [SerializeField] PlayerManager playerManager;
    void Start()
    {
       StartCoroutine("SpawnEnemy");
       InstanciarIntermedios();
    }

    void InstanciarIntermedios()
    {
        float firstEnemyOffset = transform.position.z - firstEnemyPositionZ;
        float n = firstEnemyOffset / distanceBetweenEnemies;
        int ciclos = Mathf.FloorToInt(n);
        for (int i = 0; i < ciclos; i++)
        {

            SacarEnemigo(firstEnemyOffset);
            firstEnemyOffset -= distanceBetweenEnemies;

        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
           SacarEnemigo(0f);
            interval = distanceBetweenEnemies / playerManager.moveSpeed;
            yield return new WaitForSeconds(interval);
        }
        
    }

    void SacarEnemigo(float offsetZ)
    {
        float posX = Random.Range(-100f, 100f);
        float posY = Random.Range(1f, 30f);
        Vector3 pos = new Vector3(posX, posY, transform.position.z - offsetZ);
        Instantiate(enemy, pos, Quaternion.identity);
    }
    }
