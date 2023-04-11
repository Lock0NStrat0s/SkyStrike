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
 Vector2 moveInput;                                 //get input from user
 Rigidbody2D myRigidbody;
 CapsuleCollider2D myBodyCollider;

 bool isAlive = true;
 void Start()
 {
  myRigidbody = GetComponent<Rigidbody2D>();
  myBodyCollider = GetComponent<CapsuleCollider2D>();
 }

 void Update()
 {

  Fly();
 }

 void OnMove(InputValue value)
 {
  moveInput = value.Get<Vector2>();
 }

 void Fly()
 {
  float moveAmount = moveSpeed * Time.deltaTime;
  float turnAmount = -moveInput.x * turnSpeed * Time.deltaTime;

  transform.Translate(-moveAmount, 0, 0);
  transform.Rotate(0, 0, turnAmount);
 }

 void OnFire(InputValue value)
 {
  Instantiate(bullet, gun.position, transform.rotation);
 }
}
