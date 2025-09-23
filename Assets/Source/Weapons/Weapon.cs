using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player mPlayer;
    public WeaponData _WeaponData;


    public void Start()
    {
        mPlayer = transform.root.GetComponent<Player>();
    }

    public virtual void FireWeapon() 
    {

    }

    public virtual void Reload() 
    {

    }

}


