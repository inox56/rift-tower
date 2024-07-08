using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 20.0f;
    [SerializeField] private float baseDamage = 7.0f;
    [SerializeField] private float baseLife = 10;
    [SerializeField] private float life;
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    [SerializeField] private bool isDead = false; 
    [SerializeField] private bool isPaused = false;

    private Transform target;

    [SerializeField] private GameLevelManager levelManager;
    [SerializeField] private EnemySpawnManager enemySpawnManager;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int minutePrint;

    public float Damage => damage;
    public float Life => life;
    public NavMeshAgent Agent => agent;
    public Transform Target => target;
    public int MinutePrint { get { return minutePrint; } set { minutePrint = value; } }
    public GameLevelManager LevelManager { get { return levelManager; } set { levelManager = value; } }

    // Start is called before the first frame update
    public void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isDead) return;
        if(agent.isActiveAndEnabled)
        {

            agent.SetDestination(target.position);
        }
    }

    public void SetTarget()
    {
        target = levelManager.GetTarget();
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        // Vérifier si l'objet avec lequel l'ennemi entre en collision est le joueur
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("ok");
            // Appeler la fonction pour infliger des dégâts au joueur
            Target target = collision.gameObject.GetComponentInParent<Target>();
            target.getHit(damage);
        }
    }

    public void GetHit(float damage)
    {
        life -= damage;
        if (life < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Destroy(this);
        isDead = true;
        enemySpawnManager.ReturnToPool("type2",this.gameObject);
    }
    public void Initiate()
    {
        speed = baseSpeed;
        damage = baseDamage;
        life = baseLife;
        isDead = false;
    }

    public void SetEnnemySpawnManager(EnemySpawnManager esm)
    {
        enemySpawnManager = esm;
    }

}