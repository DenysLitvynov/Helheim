using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss2_stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;
    private Aliado_stats aliado;

    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float dano_enemigo = 15f;//danyo que causa el enemigo(el aliado tomara esto como parametro en recibirDanyo())
    
    public NavMeshAgent Enemigo;
    public Transform Aliado;

    [SerializeField] private float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemigo.SetDestination(Aliado.position);
        shoot();
    }
    void shoot(){
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0 ) return;

        bulletTime = timer;
        
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }
}
