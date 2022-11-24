using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Main : MonoBehaviour
{
    [SerializeField]
    private Button moveBtn;
    // Start is called before the first frame update
    void Start()
    {
        moveBtn.onClick.AddListener(() => { OnGoGame(); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoGame()
    {
        SceneManager.LoadScene("Game");

    }
}
