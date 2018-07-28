using UnityEngine;
using System.Collections;

public class DetectorColisiones : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), gameObject.GetComponent<Collider>()); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ladrillo" || collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
        }
        gameObject.transform.Translate(0, -10, 0);
        //gameObject.SetActive(false);    //Desaparece la bala
    }
}
