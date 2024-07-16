using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Building : MonoBehaviour
{

    [SerializeField] private int ConstructionDelayPhase = 1;
    [SerializeField] private float ConstructionDelayTime = 1;
    [SerializeField] private float baseCooldown = 7.0f;
    [SerializeField] private float baseDamage = 7.0f;
    [SerializeField] private float baseLife = 10;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    

    [SerializeField] private float damage;
    [SerializeField] private float life;
    [SerializeField] private float cooldown;
    [SerializeField] private string type;

    [SerializeField] private bool isPlacable;
    [SerializeField] private bool isPlaced;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isPaused = false;

    [SerializeField] 
    private GameObject target;

    [SerializeField] private GameLevelManager levelManager;

    public float Damage => damage;
    public float Life => life;
    public GameObject Target => target;
    public bool IsPlacable => isPlacable;
    public bool IsPlaced
    {
        get { return isPlaced; }
        set { isPlaced = value ; }
    }

    public GameLevelManager LevelManager { get { return levelManager; } set { levelManager = value; } }

    // Start is called before the first frame update
    public void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        Initiate();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }
    public void Initiate()
    {
        damage = baseDamage;
        life = baseLife;
        isDead = false;
        isPlaced = false;
        isPlacable = true;
    }


    // Update is called once per frame
    private void Update()
    {
        if (isDead) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //    if (collision.gameObject.CompareTag("Target"))
        if (spriteRenderer != null && !isPlaced)
        {
            isPlacable = false;
            spriteRenderer.color = Color.red;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (spriteRenderer != null && !isPlaced)
        {
            isPlacable = false;
            spriteRenderer.color = Color.red;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (spriteRenderer != null && !isPlaced)
        {
            isPlacable = true;
            spriteRenderer.color = originalColor;
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