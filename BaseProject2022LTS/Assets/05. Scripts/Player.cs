using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    Rigidbody rigi;
    float hor, ver;
    float vel = 2.5f;
    

    public string message;

    private Vector3 position;
    
    private void Awake()
    {
        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        
        //MOVIMIENTO MANDO
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal") * vel, rigi.velocity.y, Input.GetAxisRaw("Vertical") * vel);
        rigi.velocity = mov;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Quaternion rot = Quaternion.LookRotation(new Vector3(mov.x, 0, mov.z));
            rot = rot.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 6 * Time.deltaTime);
        }

        #region MOVIMIENTO ANDROID JOYSTICK
        /*Vector3 mov2 = new Vector3(analogico.Horizontal* vel, rigi.velocity.y, analogico.Vertical * vel);
        rigi.velocity = mov2;

        if (analogico.Horizontal != 0 || analogico.Vertical != 0)
        {
            Quaternion rot2 = Quaternion.LookRotation(new Vector3(mov2.x, 0, mov2.z));
            rot2 = rot2.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot2, 6 * Time.deltaTime);
        }*/
        #endregion

    }
}
