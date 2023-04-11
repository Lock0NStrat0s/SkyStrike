using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
 Vector2 screenBounds;                              //boundary of screen
 float objectWidth;
 float objectHeight;
 void Start()
 {
  screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
  objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
  objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
 }

 void LateUpdate()
 {
  Vector3 viewPos = transform.position;
  viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
  viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
  transform.position = viewPos;
 }
}
