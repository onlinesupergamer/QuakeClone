using UnityEngine;

public class Shotgun : Weapon
{
    int FireSpread = 3;
    int Bullets = 9;

    public override void Update()
    {
        //base.Update();


    }

    public override void FireWeapon()
    {
        if (ShotTimer <= 0)
        {
           
        }

        
        for (int i = 0; i < Bullets; i++) 
        {
            RaycastHit Hit;
            Vector3 Spread = Quaternion.Euler(Random.Range(-FireSpread, FireSpread), Random.Range(-FireSpread, FireSpread), 0) * mPlayer.PlayerCamera.transform.forward;



            if (Physics.Raycast(mPlayer.PlayerCamera.transform.position, Spread, out Hit, Mathf.Infinity))
            {

            }

            Debug.DrawRay(mPlayer.PlayerCamera.transform.position, Spread * 15, Color.aliceBlue, 5.0f);
        }
        
        print("Shotgun Fire");
    }

}
