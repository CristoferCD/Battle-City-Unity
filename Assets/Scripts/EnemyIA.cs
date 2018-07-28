using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour {

    public float velocidad { get; set; }    //Velocidad del objeto, se multiplica por el input en Translate
    public GameObject IBala;    //Publico para pasarlo desde el editor
    private GameObject bala;
    private Rigidbody balaRb;   //RigidBody de la bala para acelerarla
    private int rotacion;
    private AudioSource disparo;
    private int[] rotaciones = { 0, 90, 180, 270 };

	// Use this for initialization
	void Start () {
        velocidad = 8.0f;
        bala = Instantiate(IBala, new Vector3(0, -10, 0), Quaternion.identity) as GameObject;
        balaRb = bala.GetComponent<Rigidbody>();
        disparo = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //Cambio aleatorio de dirección
	    if(Random.Range(0,30) == 0.0f) {
            cambiarDireccion();
        }
        //Movimiento
        switch (rotacion) {
            case 0:
                transform.Translate(0, 0, velocidad * Time.deltaTime, Space.World);
                break;
            case 90:
                transform.Translate(velocidad * Time.deltaTime, 0, 0, Space.World);
                break;
            case 180:
                transform.Translate(0, 0, -velocidad * Time.deltaTime, Space.World);
                break;
            case 270:
                transform.Translate(-velocidad * Time.deltaTime, 0, 0, Space.World);
                break;
        }
        transform.rotation = Quaternion.Euler(0, rotacion, 0);
        //Disparo
        if (bala.transform.position.y < 0) {
            disparo.Play();
            balaRb.velocity = Vector3.zero;
            bala.transform.position = transform.position + transform.forward * 2.0f;
            balaRb.AddForce(transform.forward * 50, ForceMode.Impulse);
        }
    }

    void cambiarDireccion() {
        rotacion = rotaciones[Random.Range(0, 4)];
    }

    void OnCollisionEnter(Collision collision) {
        cambiarDireccion();
    }
}
