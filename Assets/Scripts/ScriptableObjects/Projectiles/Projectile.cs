using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, 25f * Time.deltaTime);

        // Mettre à jour la position de l'objet
        transform.position = newPosition;
    }

    public void SetTarget(GameObject go)
    {
        target = go;
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        // Vérifier si l'objet avec lequel l'ennemi entre en collision est le joueur
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Destroy(this.gameObject);
        }
    }
}
