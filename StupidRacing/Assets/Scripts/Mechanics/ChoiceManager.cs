using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{

    public List<Choice> choices;

    private bool showPopUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        showPopUp = true;

    }

    public void ShowChoice(int i)
    {

    }

    public void ShowChoices()
    {

    }

    void OnGUI()
    {
        if (showPopUp)
        {
            GUILayout.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 250), ShowGUI, "Buy an Item");
        }
    }

    void ShowGUI(int windowID)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Title");
        GUILayout.EndHorizontal();

        foreach (Choice choice in choices)
        {
            GUILayout.BeginHorizontal();

            string s = choice.name + ": " + choice.description;
            GUILayout.Button(s); //change color i

            GUILayout.EndHorizontal();
        }

        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Confirm"))
        {
            showPopUp = false;
            // you may put other code to run according to your game too
        }
        else if (GUILayout.Button("Cancel"))
        {
            showPopUp = false;
            // you may put other code to run according to your game too
        }
        GUILayout.EndHorizontal();
    }
}

[System.Serializable]
public class Choice
{
    public string name;
    public string description;

    IAction action;

    public void SetOnChoice(IAction action)
    {
        this.action = action;
    }
}

public interface IAction
{
    void Action();
}
