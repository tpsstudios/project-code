using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;
    public AudioSource ammo;
    public AudioSource enemyDeath;
    public AudioSource enemyShot;
    public AudioSource gunshot;
    public AudioSource laserShot;
    public AudioSource health;
    public AudioSource playerHurt;
    public AudioSource weaponPickup;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAmmoPickup()
    {
        ammo.Stop();
        ammo.Play();
    }
    public void PlayEnemyDeath()
    {
        enemyDeath.Stop();
        enemyDeath.Play();
    }
    public void PlayEnemyShot()
    {
        enemyShot.Stop();
        enemyShot.Play();
    }
    public void PlayGunshot()
    {
        gunshot.Stop();
        gunshot.Play();
    }
    public void PlayLaserShot()
    {
        laserShot.Stop();
        laserShot.Play();
    }
    public void PlayHealthPickup()
    {
        health.Stop();
        health.Play();
    }
  
    public void PlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }

    public void PlayWeaponPickup()
    {
        weaponPickup.Stop();
        weaponPickup.Play();
    }

}
