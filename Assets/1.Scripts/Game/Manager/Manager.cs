using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Ins;

    public GameUI gameUI;
    public SpawnManager spawnMgr;
    public DataPawn dataPawn;

    void Awake()
    {
        Ins = this;  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
