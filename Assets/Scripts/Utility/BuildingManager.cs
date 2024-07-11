using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    [SerializeField] private BuildingsDatabase buildingDatabase;
    [SerializeField] private Vector2 pos;
    [SerializeField] private RaycastHit hitd;
    [SerializeField] private LayerMask layerMask;
    [SerializeField]
    private GameObject pendingBuilding;
    [SerializeField] private bool isBuildingMode;


    public void SelectObject(int Index)
    {
        pendingBuilding = buildingDatabase.getBuildingMetaDataById(Index).BuildingPrefab;
    }

    private void FixedUpdate()
    {

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log("Position d'impactDDD : " + ray.origin + " / "+ ray.direction) ;
        //if (Physics.Raycast(ray.origin, ray.direction, out hitd, 1000))
        //{
        //    pos = hitd.point;

        //    Debug.Log("Position d'impact : " + hitd.point);
        //}

        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convertir la position de la souris en coordonnées monde
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Ajuster la position de la souris en coordonnées monde pour être au-dessus du sol
        mouseWorldPosition.z = Camera.main.transform.position.z; // La caméra doit être au-dessus du plan XY

        // Définir la direction du raycast vers le bas
        Vector3 direction = Vector3.forward; // En 2D, le sol est généralement au niveau de z = 0


        //Debug.Log("Position d'impact : " + mouseScreenPosition + " / " + mouseWorldPosition + " / " + direction);

        // Effectuer le raycast depuis la position de la souris
        RaycastHit hit;
        Debug.DrawRay(mouseWorldPosition, direction* Mathf.Infinity, Color.red);
        if (Physics.Raycast(mouseWorldPosition, direction, out hit, Mathf.Infinity))
        {
            // Afficher la position d'impact dans la console
            Debug.Log("Position d'impact : " + hit.point);
        }

        RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit2d.collider != null)
        {
            Debug.Log("Target Position: " + hit2d.collider.gameObject.transform.position);
        }
    }

    public void PlacedObject()
    {
        pendingBuilding = null;
    }

}
