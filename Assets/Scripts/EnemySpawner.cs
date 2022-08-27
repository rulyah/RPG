using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public PlayerController player;
    public GoldLoot goldLoot;
    
    void Start()
    {
       

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var enemy = Instantiate(prefab);
            enemy.gameObject.GetComponent<EnemyController>().player = player;
            enemy.gameObject.GetComponent<EnemyController>().goldLoot = goldLoot;
            enemy.gameObject.tag = "Enemy";
            enemy.transform.position = transform.position;
        }
    }
}
