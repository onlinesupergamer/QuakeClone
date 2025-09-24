using UnityEngine;

public class Shotgun : Weapon
{
    int FireSpread = 5;

    public override void FireWeapon()
    {
        RaycastHit Hit;
        Vector3 Spread = Quaternion.Euler(Random.Range(-FireSpread, FireSpread), Random.Range(-FireSpread, FireSpread), 0) * mPlayer.PlayerCamera.transform.forward;

        if (Physics.Raycast(mPlayer.PlayerCamera.transform.position, Spread, out Hit, Mathf.Infinity))
        {
            
        }

        Debug.DrawLine(mPlayer.PlayerCamera.transform.position, Spread * 35, Color.aliceBlue, 5.0f);


    }

}
