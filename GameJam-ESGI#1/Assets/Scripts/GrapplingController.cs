using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingController : MonoBehaviour
{
    public Transform grapplingOrigin;
    public Transform grapplingHead;
    public Transform grapplingWire;

    public float grapplingPosClampX = 1;
    public float glapplingMovementSpeed = 1;
    public float pickupSpeed = 1;

    public float idlePos;
    public float endPos;

    private bool headIsAtOrigin;


    void Start()
    {
        
    }

    void Update()
    {

        GrapplingPickup();
        GrapplingMovements();
    }

    private void GrapplingMovements()
    {
        if (!headIsAtOrigin) return;

        float input = Input.GetAxisRaw("Horizontal");

        float finalPosX = grapplingOrigin.position.x + input * glapplingMovementSpeed * Time.deltaTime;
        finalPosX = Mathf.Clamp(finalPosX, -grapplingPosClampX, grapplingPosClampX);

        grapplingOrigin.position = new Vector3(finalPosX, grapplingOrigin.position.y, grapplingOrigin.position.z);
    }

    private void GrapplingPickup()
    {
        float finalPos = Input.GetKey(KeyCode.Space) ? endPos : idlePos;

        grapplingHead.localPosition = Vector3.Lerp(grapplingHead.localPosition, 
                                                new Vector3(grapplingHead.localPosition.x, finalPos, grapplingHead.localPosition.z), 
                                                Time.deltaTime * pickupSpeed);

        float distance = Mathf.Abs(grapplingHead.localPosition.y - grapplingOrigin.localPosition.y);
        headIsAtOrigin = distance > 0.2f ? false : true;

        grapplingWire.localPosition = new Vector3(grapplingWire.localPosition.x, - distance / 2f, 2);
        grapplingWire.localScale = new Vector3(0.1f, distance, 1);
    }
}
