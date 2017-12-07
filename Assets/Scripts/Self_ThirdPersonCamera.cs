using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_ThirdPersonCamera : MonoBehaviour {

    #region Variable (private)
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;
    #endregion

    // Use this for initialization
    void Start () {
        // notice set the character (Beta) with the tag to the Player
        follow = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        // set up the position to be the correct offset of the character
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosition, Color.magenta);

        // making a smooth transition between it's current position and the position it wants to be in
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        // make sure the camera is looking the right way
        transform.LookAt(follow);
    }
}
