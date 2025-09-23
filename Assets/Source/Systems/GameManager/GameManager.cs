using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DefaultPrimary;
    public GameObject DefaultSecondary;



    public Player mPlayer;

    private void Start()
    {
        mPlayer.PrimaryWeapon = DefaultPrimary; //This is a fallback in case nothing is set properly
        mPlayer.SecondaryWeapon = DefaultSecondary;

        mPlayer.PrimaryWeapon = Instantiate(DefaultPrimary, mPlayer.WeaponTransform.transform.position, Quaternion.identity);
        mPlayer.SecondaryWeapon = Instantiate(DefaultSecondary, mPlayer.WeaponTransform.transform.position, Quaternion.identity);

        mPlayer.PrimaryWeapon.transform.parent = mPlayer.WeaponTransform.transform;
        mPlayer.SecondaryWeapon.transform.parent = mPlayer.WeaponTransform.transform;


        mPlayer.CurrentWeapon = mPlayer.PrimaryWeapon; //Should call a method that with assign the proper weapon and disables the unused one
        mPlayer.SecondaryWeapon.SetActive(false);

    }

}
