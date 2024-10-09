using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f; // Variabel offset untuk posisi Y
    public float xOffset = 0f; // Variabel offset untuk posisi X
    public Transform target;
    private float currentPosX;


    [SerializeField] private float aheadDistance;

    private float lookAhead;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset + + lookAhead, target.position.y + yOffset, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * target.localScale.x), Time.deltaTime * FollowSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
