using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    [SerializeField] private BuildingsDatabase buildingDatabase;
    //[SerializeField] private Vector2 pos;
    [SerializeField] private Vector3 pos;
    [SerializeField] private Vector3 cursorPosition;
    [SerializeField] private RaycastHit hitd;
    [SerializeField] private LayerMask layerMask;
    [SerializeField]
    private GameObject pendingBuilding;
    [SerializeField] private bool isBuildingMode;



    private void Update()
    {
        if (pendingBuilding != null)
        {
            pendingBuilding.transform.position = cursorPosition;
            if (pendingBuilding.ConvertTo<Building>().IsPlacable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceObject();
                }
            }
        } 
    }

    private void FixedUpdate()
    {
        // Ajuster la position de la souris en coordonnées monde pour être au-dessus du sol
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = Camera.main.transform.position.z; // La caméra doit être au-dessus du plan XY
        pos = mouseWorldPosition;
        cursorPosition.x = mouseWorldPosition.x;
        cursorPosition.y = mouseWorldPosition.y;
        cursorPosition.z = 0;

        // Définir la direction du raycast vers le bas
        // Vector3 direction = Vector3.forward; // En 2D, le sol est généralement au niveau de z = 0

        RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000 ,layerMask);

        if (hit2d.collider != null)
        {
            // Debug.Log("mouseWorldPosition Position: " + mouseWorldPosition);
            Debug.Log("Target Position: " + hit2d.collider.gameObject.transform.position);
        }
    }

    public void SelectObject(int Index)
    {
        pendingBuilding = Instantiate(buildingDatabase.getBuildingMetaDataById(Index).BuildingPrefab, pos,Quaternion.identity);
    }

    public void PlaceObject()
    {
        pendingBuilding.ConvertTo<Building>().IsPlaced = true ;
        pendingBuilding = null;
    }

}
