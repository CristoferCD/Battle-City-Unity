using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    public float velocidad { get; set; }    //Velocidad del objeto, se multiplica por el input en Translate
    public GameObject IBala;    //Publico para pasarlo desde el editor
    private GameObject bala;
    private Rigidbody balaRb;   //RigidBody de la bala para acelerarla
    private float rotacion;
    private bool ejeX = false;  //Indica el eje sobre el que se hace la rotación
    private const float velocidadMax = 8.0f;
    private AudioSource disparo;

	// Use this for initialization
	void Start () {
        bala = Instantiate(IBala, new Vector3(0,-10,0), Quaternion.identity) as GameObject;
        balaRb = bala.GetComponent<Rigidbody>();
        disparo = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0.1)    //Z+
        {
            rotacion = 0.0f;
            velocidad = velocidadMax;
            ejeX = false;
        }
        else if (Input.GetAxis("Vertical") < -.1)   //Z-
        {
            rotacion = 180.0f;
            velocidad = -velocidadMax;
            ejeX = false;
        }
        else if (Input.GetAxis("Horizontal") > .1) //X+
        {
            rotacion = 90.0f;
            velocidad = velocidadMax;
            ejeX = true;
        }
        else if (Input.GetAxis("Horizontal") < -.1) //X-
        {
            rotacion = 270.0f;
            velocidad = -velocidadMax;
            ejeX = true;
        }
        else
            velocidad = 0;

        if (ejeX)
            transform.Translate(velocidad * Time.deltaTime, 0, 0, Space.World);
        else
            transform.Translate(0, 0, velocidad * Time.deltaTime, Space.World);
  
        transform.rotation = Quaternion.Euler(0, rotacion, 0);
        //Disparo
        if (Input.GetKeyDown(KeyCode.F) && bala.transform.position.y < 0) {
            disparo.Play();
            balaRb.velocity = Vector3.zero;
            bala.transform.position = transform.position + transform.forward * 1.5f;
            balaRb.AddForce(transform.forward * 50, ForceMode.Impulse);
        }
    }
}
