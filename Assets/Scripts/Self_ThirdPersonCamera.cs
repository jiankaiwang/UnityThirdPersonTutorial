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
    [SerializeField]
    private CharacterControllerLogic followXform;
    private Vector3 targetPosition;
    #endregion

    // Use this for initialization
    void Start () {
        // notice set the character (Beta) with the tag to the Player
        follow = GameObject.FindWithTag("Player").transform;
        followXform = GameObject.FindWithTag("Player").GetComponent<CharacterControllerLogic>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        Vector3 characterOffSet = follow.position + new Vector3(0f, distanceUp, 0f);

        // set up the position to be the correct offset of the character
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosition, Color.magenta);

        // first is to check whether camera is against the wall or not
        CompensateForWalls(characterOffSet, ref targetPosition);
        // if not, making a smooth transition between it's current position and the position it wants to be in
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        // make sure the camera is looking the right way
        transform.LookAt(follow);
    }

    #region methods
    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        Debug.DrawLine(fromObject, toTarget, Color.cyan);
        // Compensate for walls between camera
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast(fromObject, toTarget, out wallHit)) {
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            // move the camera to the hitting position
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }
    }
    #endregion
}
