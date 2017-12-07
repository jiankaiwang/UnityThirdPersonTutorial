using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlLogic : MonoBehaviour {

    #region Variables (private)

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float directionDampTime = .25f;
    [SerializeField]
    private float speedDampTime = .25f;

    private float speed = 0.0f;
    private float h = 0.0f;
    private float v = 0.0f;

    #endregion

    #region Properties (public)

    #endregion

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        if (animator.layerCount >= 2) {
            animator.SetLayerWeight(1, 1);
        }

        //Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        if (animator) {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            //speed = new Vector2(h,v).sqrMagnitude;
            speed = h * h + v * v;

            animator.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
            animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);

            if (Input.GetButtonDown("Vertical"))
            {
                //Debug.Log("Vertical Key Down");
                //Debug.Log(speed);
            }
            else if (Input.GetButtonDown("Horizontal"))
            {
                //Debug.Log("Horizontal Key Down");
                //Debug.Log(speed);
            }
            else if (Input.anyKeyDown)
            {
                //Debug.Log("Any Key Down");
            }
        }

        //if (Input.GetKeyDown("escape")) {
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }

    /// <summary>
	/// Debugging information should be put here.
	/// </summary>
	void OnDrawGizmos()
    {

    }
}
