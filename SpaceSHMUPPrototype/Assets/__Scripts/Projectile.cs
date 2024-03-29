﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private WeaponType _type;

	 //this public property masks the field _type & takes action when it is set
	 public WeaponType type {
		get {
			return(_type);
		}
		set {
			SetType (value);
		}
	 }

	// Use this for initialization
	void Awake () {
		//test to see whether this has passed off screen
		InvokeRepeating ("CheckOffScreen",2f,2f);
	}

	 public void SetType (WeaponType eType) {
		//set the type
		_type = eType;
		WeaponDefinition def = Main.GetWeaponDefinition( _type);
		GetComponent<Renderer>().material.color = def.projectileColor;
	 }

	 void CheckOffScreen() {
		if (Utils.ScreenBoundsCheck (GetComponent<Collider>().bounds, BoundsTest.offScreen) != Vector3.zero) {
			Destroy(this.gameObject);
		}
	 }
	
	// Update is called once per frame
	void Update () {
	
	}
}
