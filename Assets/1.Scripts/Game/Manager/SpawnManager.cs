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
    private GameObject[] enemyPoints;

    [SerializeField]
    private Transform myTeamParent;
    [SerializeField]
    private Transform enemyTeamParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MySpawn(int index)
    {
        GameObject pawnObj = Instantiate(myPawns[index], myTeamParent);
        pawnObj.transform.position = 
            myPawnPoints[Random.Range(0, myPawnPoints.Length)]
            .transform.position;
    }

    public void EnemySpawn()
    {

    }
}
