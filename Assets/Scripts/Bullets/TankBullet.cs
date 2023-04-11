using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
 [SerializeField] float moveSpeed = 5f;
 Rigidbody2D myRigidbody;
 PlayerMovement target;
 Vector2 moveDirection;
 void Start()
 {
  myRigidbody = GetComponent<Rigidbody2D>();
  target = FindObjectOfType<PlayerMovement>();
  moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
  myRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
  Destroy(gameObject, 3f);
 }

 void OnTriggerEnter2D(Collider2D other)
 {
  if (other.tag == "Player")
  {
   Destroy(gameObject);
   Debug.Log("HIT!!");
  }
 }
}
