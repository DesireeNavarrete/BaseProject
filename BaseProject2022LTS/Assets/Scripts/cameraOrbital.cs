using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraOrbital : MonoBehaviour
{
    public GameObject target;
    public float hor;
    public float ver;
    public bool mov;
    public float x;
    public float y;
    public float suavidad = 2;

    //El desplazamiento inicial de la camara
    Vector3 desplazamiento;

    void Start()
    {
        desplazamiento = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CameraOrb());
    }

    IEnumerator CameraOrb()
    {
        Vector3 targetCamPos1 = target.transform.position + desplazamiento;
        //interpola la posicion con el pj
        transform.position = Vector3.Lerp(transform.position, target.transform.position + desplazamiento, suavidad * Time.deltaTime);

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        x += Input.GetAxis("Vertical") * suavidad;
        y += Input.GetAxis("Horizontal") * suavidad;
        
        //angulo muerto
        if (hor >= -0.1f && hor <= 0.1f)
        {
            y = 0;
        }

        if (hor<=1f && hor > 0.1f)
        {
            transform.RotateAround(target.transform.position, new Vector3(0, y, 0), 30 * Time.deltaTime);

        }

        if (hor >= -1f && hor < -0.1f)
        {
            transform.RotateAround(target.transform.position, new Vector3(0, y, 0), 30 * Time.deltaTime);

        }
        yield return null;
    }
}
