using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
 Vector2 screenBounds;                              //boundary of screen
 float objectWidth;
 float objectHeight;
 [SerializeField] PlayerMovement pm;
 bool hasTurned = false;
 void Start()
 {
  screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
  objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
  objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
 }

 //  void LateUpdate()
 //  {
 //   Vector3 viewPos = transform.position;
 //   if ((viewPos.x < -screenBounds.x + objectWidth || viewPos.x > screenBounds.x - objectWidth) && !hasTurned)
 //   {
 //    hasTurned = true;
 //    transform.localScale = new Vector2(-transform.localScale.x, 1f);
 //    pm.Fly(-pm.MoveSpeed);
 //   }
 //   else
 //   {
 //    hasTurned = false;
 //   }

 //   viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
 //   viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
 //   transform.position = viewPos;
 //  }

 private void OnCollisionEnter2D(Collision2D other)
 {
  transform.localScale = new Vector2(-transform.localScale.x, 1f);
  //   pm.moveSpeed = -pm.moveSpeed;
 }
}
