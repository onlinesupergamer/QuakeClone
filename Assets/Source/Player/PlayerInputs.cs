using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Vector2 MouseInput = Vector2.zero;

    [SerializeField]
    Vector2 MovementInput = Vector2.zero;

    /*
     * We can create simple inputs like this:
     * public bool bIsJumping = Input.GetKeyDown(KeyCode.Space);
     * This is useful to let the playercontroller check for the inputs this way 
     * and keep the inputs organized here
     *
     */


    void Start()
    {
        
    }

    
    void Update()
    {
        
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
