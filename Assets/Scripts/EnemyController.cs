using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    public float[] xPosRange = new float[2];
    public float[] yPosRange = new float[2];
    public float[] zPosRange = new float[2];
    public int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(EnemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies(int Enemies){
        while (Enemies > 0){
            float xPos = Random.Range(xPosRange[0], xPosRange[1]);
            float yPos = Random.Range(yPosRange[0], yPosRange[1]);
            float zPos = Random.Range(zPosRange[0], zPosRange[1]);

            Instantiate(Enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            Enemies -= 1;
        }
    }
}