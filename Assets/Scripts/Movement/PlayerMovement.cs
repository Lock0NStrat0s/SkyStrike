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
 Vector2 temp;                                      //holds temp value to store
 Rigidbody2D myRigidbody;
 CapsuleCollider2D myBodyCollider;
 bool hasFlippedRight = false;                      //check orientation of plane
 bool hasFlippedLeft = true;
 bool hasRotated = true;                            //check if rotation to mouse click is complete
 float angle;                                       //angle to rotate towards
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
  if (!hasRotated)
  {
   RotatePlaneToPoint();
  }
 }
 void Fly()
 {
  float moveAmount = moveSpeed * Time.deltaTime;
  transform.Translate(-moveAmount, 0, 0);
 }

 void FlipSprite()
 {
  float orientation = transform.rotation.z * Mathf.Rad2Deg * 2;

  if (((orientation > 90 && orientation < 180) || (orientation > -180 && orientation < -90)) && !hasFlippedRight)
  {
   hasFlippedRight = true;
   hasFlippedLeft = false;
   transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
  }
  else if ((orientation > -90 && orientation < 90) && !hasFlippedLeft)
  {
   hasFlippedRight = false;
   hasFlippedLeft = true;
   transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
  }
 }

 void OnShoot(InputValue value)
 {
  Instantiate(bullet, gun.position, transform.rotation);
 }

 void OnClick(InputValue value)
 {
  Rotation();
 }
 void IsMouseBeingHeld()
 {
  if (Mouse.current.leftButton.isPressed)
  {
   if (temp != Mouse.current.position.ReadValue())
   {
    Rotation();
    temp = Mouse.current.position.ReadValue();
   }
  }
 }
 void Rotation()
 {
  Vector2 turn = (transform.position - mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
  angle = Mathf.Atan2(turn.y, turn.x) * Mathf.Rad2Deg;
  if (transform.rotation != Quaternion.Euler(0, 0, angle))
  {
   hasRotated = false;
  }
  else
  {
   hasRotated = true;
  }
 }
 void RotatePlaneToPoint()
 {
  transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * turnSpeed);
 }
}
