using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPts;
    private GameObject[] enemies;   //Instancias creadas de enemigo
    private int maxEneSim = 4;      //Máximo de enemigos simultáneos
    private int maxEne = 12;        //Máximo de enemigos del nivel
    private int totalEne = 0;       //Enemigos totales creados

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0, 1);
	}
	
    void Spawn() {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= maxEneSim && totalEne < maxEne) {
            int i = Random.Range(0, spawnPts.Length);
            Instantiate(enemy, spawnPts[i].position, spawnPts[i].rotation);

        }
    }
}
