using UnityEngine;



public class Player : MonoBehaviour
{
    public CharacterController PlayerController;
    public Camera PlayerCamera;
    public Camera ViewmodelCamera;
    public PlayerInputs Inputs;
    public float MovementSpeed;
    
    public float GravityForce;

    [Header("In-Game Camera Settings")]

    public float MinMaxCameraPitch;
    public float CameraSensitivity;
    public float PlayerCameraFOV;
    public float ViewmodelFOV;
    public bool bCanUserInput = true;


    Vector3 GravityDir = new Vector3(0, -1, 0); //It's negative because gravity goes down


    [SerializeField] float XRot; //XRot is for the camera pitch rotation... it happens to be rotating the X axis so
                                 //try not to get confused about that, X is the Camera pitch

    void Start()
    {
        
    }

    
    void Update()
    {
        HandleMovement();
        HandleGravity();

        //This is just to debug in Editor:
        //If the player changes these in-game, we need a method to do this only when called manually

        //PlayerCamera.fieldOfView = PlayerCameraFOV;
        //ViewmodelCamera.fieldOfView = ViewmodelFOV;

    }

    private void LateUpdate()
    {
        HandleCamera();
    }

    void HandleMovement() 
    {
        if (!bCanUserInput) return;

        Vector3 NewMovement;
        Vector3 ForwardVec = transform.forward * Inputs.GetMovementInput()[0];
        Vector3 RightVec = transform.right * Inputs.GetMovementInput()[1];
        NewMovement = ForwardVec + RightVec;
        NewMovement.y = 0;

        //Currently working out which controller model would be best
        //It seems like a normal Character Controller will be it

        //PlayerRigidbody.AddForce(NewMovement * MovementSpeed); 
        PlayerController.Move(NewMovement * (MovementSpeed * Time.deltaTime));
    }

    void HandleCamera() 
    {
        if (!bCanUserInput) return;

        Vector3 Rot = PlayerCamera.transform.rotation.eulerAngles;
        XRot -= Inputs.GetMouseInput()[1] * (Time.deltaTime * CameraSensitivity);
        XRot = Mathf.Clamp(XRot, -MinMaxCameraPitch, MinMaxCameraPitch);

        Vector3 BodyRot;
        BodyRot = PlayerCamera.transform.rotation.eulerAngles;
        BodyRot.z = 0;
        BodyRot.x = 0;
        transform.rotation = Quaternion.Euler(BodyRot);
        //The player rotation must be set before the mouse input changes it or the rotation continues stacking


        Rot.x = XRot;
        
        Rot.y += Inputs.GetMouseInput()[0] * (Time.deltaTime * CameraSensitivity);

        PlayerCamera.transform.rotation = Quaternion.Euler(Rot);
        
        
    }

    public void SetCameraFOV(float FOV) 
    {
        PlayerCamera.fieldOfView = FOV;
    }
    public void SetViewmodelFOV(float FOV) 
    {
        ViewmodelCamera.fieldOfView = FOV;
    }

    void HandleGravity() 
    {
        //This is very simple, we want to do more here but this will work for now
        PlayerController.Move(GravityDir * (GravityForce * Time.deltaTime));
    }
}
