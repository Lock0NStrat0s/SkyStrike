using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 [SerializeField] float bulletSpeed = 20f;
 Rigidbody2D myRigidbody;
 float xSpeed;
 void Start()
 {
  myRigidbody = GetComponent<Rigidbody2D>();

 }

 void Update()
 {
  myRigidbody.velocity = new Vector2(0f, -bulletSpeed);
 }

 void OnTriggerEnter2D(Collider2D other)
 {
  if (other.tag == "Enemy")
  {
   Destroy(other.gameObject);
  }
  Destroy(gameObject);
 }

 void OnCollisionEnter2D(Collision2D other)
 {
  if (other.gameObject.tag != "Player")
  {
   Destroy(gameObject);
  }
 }
}
