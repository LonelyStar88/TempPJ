using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] myPawns;
    [SerializeField]
    private GameObject[] enemyPawns;

    [SerializeField]
    private GameObject[] myPawnPoints;
    [SerializeField]
    private GameObject[] enemyPawnPoints;

    [SerializeField]
    private Transform myTeamParent;
    [SerializeField]
    private Transform enemyTeamParent;

    //float delayCreatTime = 0f;
    float enemyGage = 0;
    float enemyGageTime = 0;
    float enemyMaxGage = 150;
 

   

    public void MySpawn(int index)
    {
        Spawn(myPawns, myTeamParent, myPawnPoints, index);
    }

    // 적 스폰 관련 부분

    // Update is called once per frame
    void Update()
    {
        //delayCreatTime += Time.deltaTime;
        /*
        if (delayCreatTime > 2f)
        {
            //EnemySpawn(0);
            Spawn(enemyPawns, enemyTeamParent, enemyPawnPoints, 0);
            delayCreatTime = 0f;
        }*/
        enemyGageTime += Time.deltaTime;
        if(enemyGageTime > 0.1f)
        {
            enemyGageTime = 0;

            if(enemyGage <= enemyMaxGage)
            {
                enemyGage += 0.2f;
            }
            // 적 게이지에 따라 스폰 시킴
            int enemySpawnIndex = Random.Range(0, enemyPawns.Length);
            float enemySpawnGage = (enemySpawnIndex + 1) * 10f;
            if(enemyGage >= enemySpawnGage)
            {
                
                enemyGage -= (enemySpawnIndex + 1) * 10f;
                Spawn(enemyPawns, enemyTeamParent, enemyPawnPoints, enemySpawnIndex, false);

            }
        }
    }
    

    public void Spawn(GameObject[] pawns, Transform parent, GameObject[] points, int index, bool isMy = true)
    {
        GameObject pawnObj = Instantiate(pawns[index], parent);
        pawnObj.transform.position =
            points[Random.Range(0, points.Length)]
            .transform.position;

        if (isMy)
        {
            pawnObj.GetComponent<Monster>().Initialized(Manager.Ins.dataPawn.pawnData.pawn[index]);
        }
        else
        {
            pawnObj.GetComponent<EnemyMonster>().Initialized(Manager.Ins.dataPawn.enemyPawn.monster[index]);
        }
    }
}
