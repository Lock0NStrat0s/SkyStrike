using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_EnemyMovement : MonoBehaviour
{
 [SerializeField] float moveSpeed = 1f;
 [SerializeField] GameObject tankBullet;
 [SerializeField] Transform gun;
 [SerializeField] float fireRate = 1f;
 [SerializeField] float nextFire;
 Rigidbody2D myRigidbody;

 void Start()
 {
  myRigidbody = GetComponent<Rigidbody2D>();
  nextFire = Time.time;
 }

 void Update()
 {
  myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
  TimeToFire();
 }

 void OnTriggerExit2D(Collider2D other)
 {
  moveSpeed = -moveSpeed;
  FlipEnemyFacing();
 }

 void FlipEnemyFacing()
 {
  transform.localScale = new Vector2((Mathf.Sign(myRigidbody.velocity.x)), 1f);
 }

 void TimeToFire()
 {
  if (Time.time > nextFire)
  {
   Instantiate(tankBullet, gun.position, transform.rotation);
   nextFire = Time.time + fireRate;
  }
 }
}
