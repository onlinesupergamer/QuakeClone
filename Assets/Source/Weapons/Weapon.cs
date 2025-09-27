using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player mPlayer;
    public WeaponData _WeaponData;
    public Texture2D WeaponCrosshairTexture;
    public float TimeBetweenShots = 5.0f;
    public float ShotTimer = 5.0f;
    public bool bHasFired = false;

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

    public virtual void Update() 
    {

    }

}


