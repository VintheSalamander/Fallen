using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    public GameObject DeepSea;
    public GameObject Space;
    public EnemyController enemyController;
    public PlayerController playerController;
    static bool isDeepSea;
    static bool isSpace;
    static int round;

    // Start is called before the first frame update
    void Awake()
    {
        round = 0;
        SetDeepSea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeEnviroment(){
        if(isDeepSea){
            SetSpace();
        }else if(isSpace){
            SetDeepSea();
        }
        round += 1;
        enemyController.DestroyEnemies();
        enemyController.SpawnEnemies();
    }

    void SetDeepSea(){
        DeepSea.SetActive(true);
        Space.SetActive(false);
        isDeepSea = true;
        isSpace = false;
        playerController.ChangeShipToDeepSea();
    }

    void SetSpace(){
        DeepSea.SetActive(false);
        Space.SetActive(true);
        isDeepSea = false;
        isSpace = true;
        playerController.ChangeShipToSpace();
    }

    public static bool GetIsDeepSea(){
        return isDeepSea;
    }

    public static bool GetIsSpace(){
        return isSpace;
    }

    public static int GetRound(){
        return round;
    }
}
