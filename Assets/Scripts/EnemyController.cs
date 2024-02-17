using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyDeepSea;
    public GameObject enemySpace;
    public float[] xPosRange = new float[2];
    public float[] yPosRange = new float[2];
    public float[] zPosRange = new float[2];
    public int initialEnemyCount;
    public int enemyRoundIncrement;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies(){
        int Enemies = initialEnemyCount + enemyRoundIncrement * GameModeController.GetRound();
        if(GameModeController.GetIsDeepSea()){
            while (Enemies > 0){
                float xPos = Random.Range(xPosRange[0], xPosRange[1]);
                float yPos = Random.Range(yPosRange[0], yPosRange[1]);
                float zPos = Random.Range(zPosRange[0], zPosRange[1]);

                Instantiate(enemyDeepSea, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                Enemies -= 1;
            }
        }

        if(GameModeController.GetIsSpace()){
            while (Enemies > 0){
                float xPos = Random.Range(xPosRange[0], xPosRange[1]);
                float yPos = Random.Range(yPosRange[0], yPosRange[1]);
                float zPos = Random.Range(zPosRange[0], zPosRange[1]);

                Instantiate(enemySpace, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                Enemies -= 1;
            }
        }
        
    }

    public void SetEnemy(){
        
    }
}