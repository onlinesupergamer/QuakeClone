using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public Camera PlayerCamera;
    public PlayerInputs Inputs;
    public float MovementSpeed;


    void Start()
    {
        
    }

    
    void Update()
    {
        HandleMovement();
        HandleCamera();

    }

    void HandleMovement() 
    {
        Vector3 NewMovement;
        Vector3 ForwardVec = PlayerRigidbody.transform.forward * Inputs.GetMovementInput()[0];
        Vector3 RightVec = PlayerRigidbody.transform.right * Inputs.GetMovementInput()[1];
        NewMovement = ForwardVec + RightVec;


        PlayerRigidbody.AddForce(NewMovement * MovementSpeed);
    }

    void HandleCamera() 
    {
        Vector3 Rot = PlayerCamera.transform.rotation.eulerAngles;
        Vector3 BodyRot;
        BodyRot = PlayerCamera.transform.rotation.eulerAngles;
        Rot.y += Inputs.GetMouseInput()[0];
        PlayerCamera.transform.rotation = Quaternion.Euler(Rot);
        
        BodyRot.z = 0;
        BodyRot.x = 0;
        transform.rotation = Quaternion.Euler(BodyRot);
    }
}
