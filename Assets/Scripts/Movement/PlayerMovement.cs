using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
 [SerializeField] float moveSpeed = 5f;             //control forward speed of plane
 [SerializeField] float turnSpeed = 5f;             //controler turn speed of plane
 [SerializeField] GameObject bullet;
 [SerializeField] Transform gun;
 [SerializeField] Camera mainCam;
 Vector2 moveInput;                                 //get input from user
 Rigidbody2D myRigidbody;
 CapsuleCollider2D myBodyCollider;
 bool hasFlippedRight = false;
 bool hasFlippedLeft = true;
 bool isAlive = true;
 void Start()
 {
  myRigidbody = GetComponent<Rigidbody2D>();
  myBodyCollider = GetComponent<CapsuleCollider2D>();
 }

 void Update()
 {
  Fly();
  FlipSprite();
  IsMouseBeingHeld();

 }
 void Fly()
 {
  float moveAmount = moveSpeed * Time.deltaTime;
  transform.Translate(-moveAmount, 0, 0);
 }

 void FlipSprite()
 {
  var orientation = transform.rotation.z * Mathf.Rad2Deg * 2;
  Debug.Log(orientation);

  if (((orientation > 90 && orientation < 180) || (orientation > -180 && orientation < -90)) && !hasFlippedRight)
  {
   hasFlippedRight = true;
   hasFlippedLeft = false;
   transform.localScale = new Vector2(1f, -transform.localScale.y);
  }
  else if ((orientation > -90 && orientation < 90) && !hasFlippedLeft)
  {
   hasFlippedRight = false;
   hasFlippedLeft = true;
   transform.localScale = new Vector2(1f, -transform.localScale.y);
  }
 }

 void OnShoot(InputValue value)
 {
  Instantiate(bullet, gun.position, transform.rotation);
 }

 void OnClick(InputValue value)
 {
  RotateToMouse();
 }
 private void IsMouseBeingHeld()
 {
  if (Mouse.current.leftButton.isPressed)
  {
   RotateToMouse();
  }
 }
 private void RotateToMouse()
 {
  Vector2 turn = (transform.position - mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
  float angle = Mathf.Atan2(turn.y, turn.x) * Mathf.Rad2Deg;
  transform.rotation = Quaternion.Euler(0, 0, angle);
 }
}
