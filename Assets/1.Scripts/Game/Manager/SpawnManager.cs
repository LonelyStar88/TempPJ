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

    float delayCreatTime = 0f;
 

   

    public void MySpawn(int index)
    {
        Spawn(myPawns, myTeamParent, myPawnPoints, index);
    }

    // 적 스폰 관련 부분

    // Update is called once per frame
    void Update()
    {
        delayCreatTime += Time.deltaTime;
        if (delayCreatTime > 2f)
        {
            //EnemySpawn(0);
            Spawn(enemyPawns, enemyTeamParent, enemyPawnPoints, 0);
            delayCreatTime = 0f;
        }
    }
    

    public void Spawn(GameObject[] pawns, Transform parent, GameObject[] points, int index)
    {
        GameObject pawnObj = Instantiate(pawns[index], parent);
        pawnObj.transform.position =
            points[Random.Range(0, points.Length)]
            .transform.position;
    }
}
