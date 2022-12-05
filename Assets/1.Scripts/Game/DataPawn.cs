using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DataPawn : MonoBehaviour
{

    #region My Pawn
    [Serializable]
    public class PawnData
    {
        public int index;
        public int price;
        public float damage;
        public float hp;
        public float delaymaxtime;
    }

    [Serializable]
    public class Pawn
    {
        public List<PawnData> pawn = new List<PawnData>();

        
    }

    [SerializeField]
    private TextAsset pawnDatajson;

    public Pawn pawnData = new Pawn();


    #endregion


    #region Enemy Pawn
    [Serializable]
    public class EnemyPawnData
    {
        public int index;
        public float damage;
        public float delaytime;
        public float hp;
        public float attackdelaytime;
    }
    
    [Serializable]
    public class EnemyPawn
    {
        public List<EnemyPawnData> monster = new List<EnemyPawnData>();
    }

    public EnemyPawn enemyPawn = new EnemyPawn();

    [SerializeField]
    private TextAsset enemyPawnDataJson;


    #endregion
    // Start is called before the first frame update
    void Awake()
    {
       
        pawnData = JsonUtility.FromJson<Pawn>(pawnDatajson.text);
        enemyPawn = JsonUtility.FromJson<EnemyPawn>(enemyPawnDataJson.text);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
