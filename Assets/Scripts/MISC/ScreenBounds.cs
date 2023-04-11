using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBounds : MonoBehaviour
{
 public Camera mainCamera;
 BoxCollider2D myBoxCollider;
 public UnityEvent<Collider2D> ExitTriggerFired;
 private float teleportOffset = 0.2f;

 void Awake()
 {
  this.mainCamera.transform.localScale = Vector3.one;
  myBoxCollider = GetComponent<BoxCollider2D>();
  myBoxCollider.isTrigger = true;
 }

 void Start()
 {
  transform.position = Vector3.zero;
  UpdateBoundsSize();
 }

 void UpdateBoundsSize()
 {
  //orthographicSize = half the size of the height of the screen
  float ySize = mainCamera.orthographicSize * 2;
  //width of the camera depends on the aspect ratio and the height
  Vector2 boxColliderSize = new Vector2(ySize * mainCamera.aspect, ySize);
  myBoxCollider.size = boxColliderSize;
 }

 void OnTriggerExit2D(Collider2D other)
 {
  ExitTriggerFired?.Invoke(other);
 }

 public bool AmIOutOfBounds(Vector3 worldPosition)
 {
  return Mathf.Abs(worldPosition.x) > Mathf.Abs(myBoxCollider.bounds.min.x) ||
  Mathf.Abs(worldPosition.y) > Mathf.Abs(myBoxCollider.bounds.min.y);
 }

 public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
 {
  bool xBoundResult = Mathf.Abs(worldPosition.x) > (Mathf.Abs(myBoxCollider.bounds.min.x));
  bool yBoundResult = Mathf.Abs(worldPosition.y) > (Mathf.Abs(myBoxCollider.bounds.min.y));
  Vector2 signWorldPosition = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

  if (xBoundResult && yBoundResult)
  {
   return Vector2.Scale(worldPosition, -Vector2.one) + Vector2.Scale(new Vector2(teleportOffset, teleportOffset), signWorldPosition);
  }
  else if (xBoundResult)
  {
   return new Vector2(-worldPosition.x, worldPosition.y) + new Vector2(teleportOffset * signWorldPosition.x, teleportOffset);
  }
  else if (yBoundResult)
  {
   return new Vector2(worldPosition.x, -worldPosition.y) + new Vector2(teleportOffset, teleportOffset * signWorldPosition.y);
  }
  else
  {
   return worldPosition;
  }
 }
}
