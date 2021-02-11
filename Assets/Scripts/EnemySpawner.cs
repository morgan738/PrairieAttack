using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 9f; 
    float nextSpawn = 10.0f;
    float startTime;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* startTime = Time.deltaTime;
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            //randX = Random.Range(-140.4f, -141.4f);
            whereToSpawn = new Vector2(transform.position.x, transform.position.y);
            
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        } */

        StartCoroutine(SpawnEnemy());
        
    }

    IEnumerator SpawnEnemy(){
        startTime = Time.deltaTime;
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            //randX = Random.Range(-140.4f, -141.4f);
            whereToSpawn = new Vector2(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(3.0f);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

    }
}
