using UnityEngine.SceneManagement;
using UnityEngine;


public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void ToMap(string m)
    {
        SceneManager.LoadScene(m);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}


