﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeWeapons : MonoBehaviour {
    int buffer;
    Gun gun;
    PlayerHealth playerhealth;
    public GameObject player;
    public GameObject[] weapons;
    AMMOTEST ammo1;
    AMMOTEST ammo2;
    public GameObject guntest;
	// Use this for initialization
	void Start () {
        playerhealth = player.GetComponent<PlayerHealth>();
       gun = guntest.GetComponent<Gun>();
        ammo1 = weapons[0].GetComponent<AMMOTEST>();
        ammo2 = weapons[1].GetComponent<AMMOTEST>();
        SelectWeapon(1);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Primary Weapon")) SelectWeapon(0);
        if (Input.GetButtonDown("Secondary Weapon")) SelectWeapon(1);

    }
   public void SelectWeapon(int index)
    {

        foreach (GameObject weapon in weapons) { weapon.SetActive(false); }
        weapons[index].SetActive(true);
    }
   public void addAmmo()
    {        
            ammo1.totalAmmo += 20;
            ammo2.totalAmmo += 40;
        if (ammo1.totalAmmo > 100) ammo1.totalAmmo = 100;
        if (ammo1.totalAmmo > 200) ammo1.totalAmmo = 200;

        //   SelectWeapon(1);
        //  gun.AddAmmo();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("ammo"))
        {

            addAmmo();

            Destroy(target.gameObject);
        }
        if (target.CompareTag("health"))
        {
            playerhealth.TakeDamage(-30);

            Destroy(target.gameObject);
        }
    }
}
