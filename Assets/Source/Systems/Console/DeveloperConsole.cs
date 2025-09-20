using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 *  This should be a persistant class; It exists at all times!
 *
 *
 *
 */




public class DeveloperConsole : MonoBehaviour
{

    public bool bIsConsoleOpen = false;
    public TMPro.TMP_InputField ConsoleInput;
    public GameObject ConsolePanel;
    public Player PlayerCharacter;
    public TMPro.TextMeshProUGUI ConsoleText;

    string InputText;
    List<string> PrevCommands;
    int PrevCommandIndex = 0;

    private void Start()
    {   
        PrevCommands = new List<string>();
        ConsoleInput.onSubmit.AddListener(SubmitInput);
        
    }

    private void Update()
    {
        PrevConsoleCommands();
        

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ConsolePanel.SetActive(false);
            bIsConsoleOpen = false;
            PlayerCharacter.bCanUserInput = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void PrevConsoleCommands() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && PrevCommands.Count != 0)
        {
            PrevCommandIndex--;
            PrevCommandIndex = Mathf.Clamp(PrevCommandIndex, 0, PrevCommands.Count - 1);

            ConsoleInput.text = PrevCommands[PrevCommandIndex];
            ConsoleInput.caretPosition = PrevCommands[PrevCommandIndex].Length;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && PrevCommands.Count != 0) 
        {
            PrevCommandIndex++;
            PrevCommandIndex = Mathf.Clamp(PrevCommandIndex, 0, PrevCommands.Count - 1);

            ConsoleInput.text = PrevCommands[PrevCommandIndex];
            ConsoleInput.caretPosition = PrevCommands[PrevCommandIndex].Length;


            //What the fuck is even happening here?

        }
    }

    public void SubmitInput(string SubmittedText) 
    {
        if (bIsConsoleOpen) 
        {
            string[] parts = SubmittedText.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            string command = parts[0].ToLower();

            ProcessInput(command, parts);

            PrevCommands.Add(SubmittedText);
            ConsoleText.text += SubmittedText + "\n";
            PrevCommandIndex = PrevCommands.Count;
            ConsoleInput.text = "";
            ConsoleInput.ActivateInputField();

        }
    }

    void ProcessInput(string _command, string[] _args) 
    {
        //This can be cleaned up in a separate file
        //But this works for now

        switch (_command) 
        {
            case "set_fov":
                int MaxArgs = 2; //This is what arg lengths are checked by (Includes the actual command at index 1, with args starting at 2)

                if (_args.Length > 2) 
                {
                    ConsoleLog("Too Many Arguments!");
                    return;
                }

                if (float.TryParse(_args[1], out float fov)) 
                {
                    //ConsoleText.text += "Setting main camera FOV\n";
                    PlayerCharacter.SetCameraFOV(fov);
                    ConsoleLog("Camera FOV Set");
                }

            break;

            case "set_weapon_fov":
                if (_args.Length > 2)
                {
                    return;
                }
                if(float.TryParse(_args[1], out float weaponfov)) 
                {
                    //ConsoleText.text += "Setting first person viewmodel FOV\n";
                    PlayerCharacter.SetViewmodelFOV(weaponfov);
                    ConsoleLog("Viewmodel Set");
                }
                break;
        }

        //Remember to log command outputs into the console! -----------------------------------
    }

    public void OpenConsole() 
    {
        if (bIsConsoleOpen)
        {
            ConsolePanel.SetActive(false);
            bIsConsoleOpen = false;
            PlayerCharacter.bCanUserInput = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else 
        {
            PlayerCharacter.bCanUserInput = false;
            ConsolePanel.SetActive(true);
            bIsConsoleOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ConsoleInput.ActivateInputField();
        }
    }

    public void ConsoleLog(string ConsoleFeedback) 
    {
        ConsoleText.text += "Console: " + ConsoleFeedback + "\n";

    }
}
