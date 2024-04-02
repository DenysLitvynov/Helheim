using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    
    [SerializeField]
    public float velocidad = 10;
    public float salto = 10;
    // Start is called before the first frame update
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 10;
    }
    /*
    // Update is called once per frame
    void Update()
    {

        //Utilizamos delta time para que se mueva a m/s
        //transform.Translate(0, 0, velocidad * Time.deltaTime); ;//x,y,z. Z es para moverse para delante
        //1*400F= 400FPS | (1 * 1/400)*400= 1m/s
        //1*60F= 60FPS   | (1 * 1/60)*60= 1m/s
        //================================================================================================

        //Vector3 movimiento= new Vector3(0, 0, velocidad * Time.deltaTime);
        Vector3 movimiento = Vector3.zero;
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.z = Input.GetAxis("Vertical");
        movimiento *= velocidad * Time.deltaTime;

        transform.Translate(movimiento);
        
    
    }
    */

    private void FixedUpdate()//Utilizar esto para controlae las fisicas
    {
        //Debug.Log($"FixedUpdate{Time.deltaTime}");

        Vector3 movimiento = Vector3.zero;
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.z = Input.GetAxis("Vertical");
        movimiento *= velocidad * Time.deltaTime;

        rb.MovePosition(transform.position + movimiento);//Le asigna una nueva posicion al rigid body



        if (Input.GetButton("Jump"))//Salta
        {
            rb.AddForce(Vector3.up * salto,ForceMode.Impulse);
        }
    }
}
