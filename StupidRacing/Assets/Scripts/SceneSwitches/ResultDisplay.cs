using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    [Header("Target")]
    public Text textFild1;
    public Text textFild2;
    public static string winner;
    public static string loser;
    
    private void Start()
    {
        DisplayResult();
    }
    // Start is called before the first frame update
    public void DisplayResult()
    {
        
        textFild1.text = winner ;
        textFild2.text = loser;

    }
}
