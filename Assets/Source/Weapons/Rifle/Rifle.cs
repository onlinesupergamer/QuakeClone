using UnityEngine;

public class Rifle : Weapon
{


    public override void FireWeapon()
    {
        RaycastHit Hit;
        Ray ray = mPlayer.PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
        {

        }

    }

}
