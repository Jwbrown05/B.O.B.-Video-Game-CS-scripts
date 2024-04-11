using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2 : MonoBehaviour 
{
public Rigidbody2D rb;
public float moveSpeed;
private Vector2 moveDirection;
public Camera cam;
Vector2 mousePos;

void Update()
{
    ProcessInputs();
    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
}
void FixedUpdate()
{
    Move();

    Vector2 lookDir = mousePos - rb.position;
    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    rb.rotation = angle;
    }

void ProcessInputs()
{
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

  moveDirection = new Vector2(moveX, moveY).normalized;
}      

void Move()
{  
    rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
}
}
