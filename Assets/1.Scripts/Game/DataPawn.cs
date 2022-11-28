using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPawn : MonoBehaviour
{
    public static DataPawn Ins;

    [System.Serializable]
    public class PawnData
    {
        public int index;
        public int price;
        public float delaymaxtime;
    }

    [System.Serializable]
    public class Pawn
    {
        public List<PawnData> pawn = new List<PawnData>();

        
    }

    [SerializeField]
    private TextAsset pawnDatajson;

    public Pawn pawnData = new Pawn();

    

    // Start is called before the first frame update
    void Start()
    {
        Ins = this;
        pawnData = JsonUtility.FromJson<Pawn>(pawnDatajson.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
