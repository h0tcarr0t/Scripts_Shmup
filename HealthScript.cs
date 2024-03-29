﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
		/// <summary>
		/// Total hitpoints
		/// </summary>
		public int hp = 1;
		
		/// <summary>
		/// Enemy or player?
		/// </summary>
		public bool isEnemy = true;
		private Animator animator;
		/// <summary>
		/// Inflicts damage and check if the object should be destroyed
		/// </summary>
		/// <param name="damageCount"></param>
		/// void Awake()
		public void Awake()
		{
			animator = GetComponent<Animator>();
		}
		public void Damage(int damageCount)
		{
			hp -= damageCount;
			if (isEnemy == false) 
			{
				CounterHelper.Instance.displayLife(hp);
				animator.SetTrigger("Hit");
				Handheld.Vibrate();
			}
			if (hp <= 0)
			{
				// Explosion!
				SpecialEffectsHelper.Instance.Explosion(transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound();
				if (isEnemy)
				{
					CounterHelper.Instance.addCount();
				}
				// Dead!
				Destroy(gameObject);
			}
		}
		
		void OnTriggerEnter2D(Collider2D otherCollider)
		{
			// Is this a shot?
			ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				// Avoid friendly fire
				if (shot.isEnemyShot != isEnemy)
				{
					Damage(shot.damage);
					
					// Destroy the shot
					Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
				}
			}
		}
	}