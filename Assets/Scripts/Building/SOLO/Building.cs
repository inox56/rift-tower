using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Building : MonoBehaviour
{

    [SerializeField] private float baseDamage = 7.0f;
    [SerializeField] private float baseLife = 10;


    [SerializeField] private float damage;
    [SerializeField] private float life;

    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isPaused = false;

    [SerializeField] 
    private GameObject target;

    [SerializeField] private GameLevelManager levelManager;


    public float Damage => damage;
    public float Life => life;
    public GameObject Target => target;
    public GameLevelManager LevelManager { get { return levelManager; } set { levelManager = value; } }

    // Start is called before the first frame update
    public void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        Initiate();
    }
    public void Initiate()
    {
        damage = baseDamage;
        life = baseLife;
        isDead = false;
    }


    // Update is called once per frame
    private void Update()
    {
        if (isDead) return;
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
        isDead = true;
        Destroy(this);
    }



}