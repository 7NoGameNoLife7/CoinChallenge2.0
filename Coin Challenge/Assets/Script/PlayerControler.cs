
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Vector3 inputDir;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float strafeSpeed = 8;
    [SerializeField] Rigidbody rb;
    float curentVelox;
    float smoothTime = 0.05f;
    [SerializeField] Camera cam;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));      //pour le control des touche 
        inputDir.Normalize ();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        PlayerMovement();                                                   //appel de la fonction 
    }
    void PlayerMovement ()                                             
    {
        //Forward dir
        Vector3 forwardDir = transform.forward*inputDir.z;
        forwardDir.Normalize ();
        forwardDir *= moveSpeed;

        //Strafe dir
        Vector3 strafeDir = Vector3.Cross(Vector3.up, transform.forward)*inputDir.x;
        strafeDir.Normalize ();
        strafeDir *= strafeSpeed;
        
        Vector3 moveDir = forwardDir + strafeDir;

        rb.MovePosition (transform.position + (moveDir*Time.deltaTime));

        //PlayerRotation
        float targetRotation = cam.transform.eulerAngles.y;

        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref curentVelox, smoothTime);
        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);
    }

    void UpdateAnimation ()
    {
        animator.SetFloat("ForwardMove", inputDir.z);
        animator.SetFloat("Straf", inputDir.x);
    }
}
