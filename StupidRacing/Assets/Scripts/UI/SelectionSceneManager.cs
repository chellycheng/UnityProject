using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionSceneManager : MonoBehaviour
{
    public string nextScene;

    public PlayerManager player1;
    public PlayerManager player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1.isReady && player2.isReady)//p2
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
