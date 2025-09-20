using System.Collections.Generic;
using UnityEngine;

public class DeveloperConsole : MonoBehaviour
{

    public bool bIsConsoleOpen = false;
    public TMPro.TMP_InputField ConsoleInput;
    public GameObject ConsolePanel;
    public Player PlayerCharacter;

    string InputText;
    List<string> PrevCommands;

    private void Start()
    {
        ConsoleInput.onSubmit.AddListener(SubmitInput);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && PrevCommands.Count > 0) 
        {
            int PrevCommandIndex;
        }
    }

    public void SubmitInput(string SubmittedText) 
    {
        if (bIsConsoleOpen) 
        {
            string[] parts = SubmittedText.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            string command = parts[0].ToLower();

            ProcessInput(command, parts);

            //PrevCommands.Add(SubmittedText);
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
                int MaxArgs = 2; //This includes initial command

                if (_args.Length > 2) 
                {
                    print("Too Many Arguments!");
                    return;
                }

                if (float.TryParse(_args[1], out float fov)) 
                {
                    print($"FOV set to {fov}!");
                    PlayerCharacter.SetCameraFOV(fov);
                }

            break;

            case "set_weapon_fov":
                if (_args.Length > 2)
                {
                    return;
                }
                if(float.TryParse(_args[1], out float weaponfov)) 
                {
                    PlayerCharacter.SetViewmodelFOV(weaponfov);
                }
                    break;

        }
    }

    public void OpenConsole() 
    {
        if (bIsConsoleOpen)
        {
            ConsolePanel.SetActive(false);
            bIsConsoleOpen = false;
            PlayerCharacter.bCanUserInput = true;
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
}
