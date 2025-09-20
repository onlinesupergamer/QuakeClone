using UnityEngine;



public class Player : MonoBehaviour
{
    public CharacterController PlayerController;
    public Camera PlayerCamera;
    public PlayerInputs Inputs;
    public float MovementSpeed;
    public float CameraSensitivity;

    Vector3 GravityDir = new Vector3(0, -1, 0); //It's negative because gravity goes down


    void Start()
    {
        
    }

    
    void Update()
    {
        HandleMovement();

    }

    private void LateUpdate()
    {
        HandleCamera();
    }

    void HandleMovement() 
    {
        Vector3 NewMovement;
        Vector3 ForwardVec = transform.forward * Inputs.GetMovementInput()[0];
        Vector3 RightVec = transform.right * Inputs.GetMovementInput()[1];
        NewMovement = ForwardVec + RightVec;
        NewMovement.y = 0;

        //Currently working out which controller model would be best
        //PlayerRigidbody.AddForce(NewMovement * MovementSpeed); 
        PlayerController.Move(NewMovement * (MovementSpeed * Time.deltaTime));
    }

    void HandleCamera() 
    {
        Vector3 Rot = PlayerCamera.transform.rotation.eulerAngles;
        Vector3 BodyRot;
        BodyRot = PlayerCamera.transform.rotation.eulerAngles;
        BodyRot.z = 0;
        BodyRot.x = 0;
        transform.rotation = Quaternion.Euler(BodyRot);
        //The player rotation must be set before the mouse input changes it or the rotation continues stacking

        Rot.y += Inputs.GetMouseInput()[0] * (Time.deltaTime * CameraSensitivity);
        Rot.x -= Inputs.GetMouseInput()[1] * (Time.deltaTime * CameraSensitivity);
        PlayerCamera.transform.rotation = Quaternion.Euler(Rot);
        
        
    }
}
