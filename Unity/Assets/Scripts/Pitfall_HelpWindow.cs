using UnityEngine;
using System.Collections;

public class Pitfall_HelpWindow : MonoBehaviour {

    public bool windowVisible = true;


    private string msg;

    Rect DialogueBoxLeft = new Rect(0 + Screen.width / 4, (Screen.height / 4) * 3 - ((Screen.height / 3) / 4), Screen.width - Screen.width / 4, Screen.height / 3);

    public GUIStyle MyStyle;
    public GUIStyle Right;

    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            windowVisible = !windowVisible;
        }
    }

    void OnGUI()
    {
        if (windowVisible)
        {
            GUILayout.BeginArea(DialogueBoxLeft);
            GUILayout.BeginHorizontal();

            string temp = "Drücke 'h' für Hilfe ein-/ausschalten.\n a - links gehen\n d - rechts gehen\n leertaste - springen\n w - betrete 'sealed doors'";
            GUILayout.Label(temp, MyStyle);
            
            GUILayout.EndHorizontal();

            GUILayout.EndArea();


        }
    }

}
