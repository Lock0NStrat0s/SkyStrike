using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
 [SerializeField] float moveSpeed = 5f;
 [SerializeField] float turnSpeed = 5f;
 Vector2 moveInput;
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
  transform.Translate(0, moveSpeed, 0);
  transform.Rotate(0, 0, -moveInput.x * turnSpeed);
 }
}
