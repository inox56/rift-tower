using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BuildingShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private List<GameObject> targetList;
    public float fireRate = 0.5f; // Cooldown entre chaque tir
    private bool canShoot = true;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(parentBuilding.IsPlaced)
        {
            addInList(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (parentBuilding.IsPlaced)
        {
            projectile.GetComponent<Projectile>().SetTarget(targetList[0]);
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (parentBuilding.IsPlaced)
        {
            RemoveFromList(collision.gameObject);
        }
    }

    private IEnumerator Shoot()
    {
        // Tirer le projectile
        Instantiate(projectile, this.transform.position, Quaternion.identity);
        // Désactiver le tir pendant la durée du cooldown
        canShoot = false;

        // Attendre la durée du cooldown
        yield return new WaitForSeconds(fireRate);

        // Réactiver le tir
        canShoot = true;
    }

    public void addInList(GameObject go)
    {
        targetList.Add(go);
    }
    public void RemoveFromList(GameObject go)
    {
        targetList.Remove(go);
    }

    void Update()
    {
        if (targetList.Count == 0)
            return;
        projectile.GetComponent<Projectile>().SetTarget(targetList[0]);
        // Vérifier la distance entre la tourelle et la cible
        if (canShoot)
            {
                StartCoroutine(Shoot());
            }
    }
}
