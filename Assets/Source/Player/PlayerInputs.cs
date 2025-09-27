using System;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Vector2 MouseInput = Vector2.zero;

    [SerializeField]
    Vector2 MovementInput = Vector2.zero;

    public DeveloperConsole console;
    public float MouseScrollDelta;
    public bool bIsJumping = false;
    public bool bIsFiring = false;

    /*
     * We can create simple inputs like this:
     * public bool bIsJumping = Input.GetKeyDown(KeyCode.Space);
     * This is useful to let the playercontroller check for the inputs this way 
     * and keep the inputs organized here
     *
     *  -The Antman
     */


    void Start()
    {
        /*
            TEMP:
            This is just for a quick way to lock mouse, should probably be moved to a better location    
            
         */


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)) 
        {
            if (console.bIsConsoleOpen)
            {
                console.OpenConsole();
            }
            else 
            {
                console.OpenConsole();

            }

        }

        bIsFiring = Input.GetKeyDown(KeyCode.Mouse0);
        bIsJumping = Input.GetKeyDown(KeyCode.Space);
        MouseScrollDelta = Input.mouseScrollDelta[1];
    }

    public Vector2 GetMouseInput() 
    {
        MouseInput[0] = Input.GetAxisRaw("Mouse X");
        MouseInput[1] = Input.GetAxisRaw("Mouse Y");

        return MouseInput;
    }

    public Vector2 GetMovementInput() 
    {
        MovementInput[0] = Input.GetAxisRaw("Vertical");
        MovementInput[1] = Input.GetAxisRaw("Horizontal");

        return MovementInput;
    }
}
