using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.Pool;

public class EnemySpawnManager : MonoBehaviour
{
  //  [SerializeField] private PauseGameMiddleManSO pauseMMSO;
    [SerializeField] private bool isPaused = false;

    [SerializeField] private EnemiesDatabase enemiesDatabase;
    [SerializeField] private GameLevelManager gameLevelManager;

    private Dictionary<int, List<string>> minuteSpawnerDictionnary;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    [SerializeField] private int topMinute = 0;
    private float startTime;

    public int TopMinute { get { return topMinute; } }

    // Start is called before the first frame update
    public Camera mainCamera;
    public float startDelay = 2.0f;
    public float spawnDelay = 2000.0f;
    public float spawnMargin = 10f;

    public void Awake()
    {
        //pauseMMSO.OnPauseGame += setIsPause;
    }

    private void OnDisable()
    {
        //pauseMMSO.OnPauseGame -= setIsPause;
    }

    void Start()
    {
        startTime = Time.time;
        minuteSpawnerDictionnary = new Dictionary<int, List<string>>();
        fillMinuteSpawnerDictionnary();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        HandleMinuteChanged(0);

        StartCoroutine(SpawnEnemyWithDelay());
    }

    public void fillMinuteSpawnerDictionnary()
    {
        List<string> list = new List<string>();
        List<string> list2 = new List<string>();
        list.Add("type2");
        list2.Add("type2");
        minuteSpawnerDictionnary.Add(0, list);
        minuteSpawnerDictionnary.Add(1, list2);
    }

    public GameObject GetFromPool(string prefabName)
    {
        if (poolDictionary.ContainsKey(prefabName) && poolDictionary[prefabName].Count > 0)
        {
            //Vector2 spawnPosition = GetRandomPositionOutsideCamera();
            Vector3 spawnPosition = new Vector3(-40,30,25);
            GameObject obj = poolDictionary[prefabName].Dequeue();
            obj.transform.position = spawnPosition;
            
            obj.GetComponent<Enemy>().Initiate();
            obj.GetComponent<Enemy>().SetEnnemySpawnManager(this);
            obj.GetComponent<Enemy>().LevelManager = gameLevelManager; 
            obj.SetActive(true);

            NavMeshTriangulation triang = NavMesh.CalculateTriangulation();
            int ind = Random.Range(0, triang.vertices.Length);
            NavMeshHit Hit;
            if (NavMesh.SamplePosition(triang.vertices[ind], out Hit, 2f, 0))
            {
                obj.GetComponent<Enemy>().Agent.Warp(Hit.position);
                
            }


            obj.GetComponent<Enemy>().Agent.enabled = true;
            //ChangeObjectPositionClientRpc(obj.GameObjectId, obj.transform.position);

            //obj.SetActive(true);
            //obj.GetComponent<NavMeshAgent>().enabled = true;

            return obj;
        }
        return null; // Retourne null si le prefab n'est pas géré par le Pool Manager
    }

   

    public void ReturnToPool(string prefabName, GameObject obj)
    {
        if (poolDictionary.ContainsKey(prefabName))
        {
            DeactivateObject(obj);
            if (obj.GetComponent<Enemy>().MinutePrint != topMinute) // Check if ennemy is from the current minute pool or other, if other destroy the object
            {
                DeleteObject(obj);
            }
            else
            {
                poolDictionary[prefabName].Enqueue(obj);
            }
        }
        else
        {
            DeleteObject(obj);
        }
    }

    public void DeactivateObject(GameObject go)
    {
        // Obtenir le NetworkObject correspondant à l'ID réseau
            go.SetActive(false);
    }

    IEnumerator SpawnEnemyWithDelay()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            if (!isPaused)
            {
                int randomSpawnAmount = Random.Range(1, 20);
                for (int i = 0; i < randomSpawnAmount; i++)
                {
                    List<string> tempList = minuteSpawnerDictionnary[topMinute];
                    if (tempList != null)
                    {
                        int randomName = Random.Range(0, tempList.Count);

                        string name = minuteSpawnerDictionnary[topMinute][randomName];
                        GetFromPool(name);
                    }
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void setIsPause(bool value)
    {
        isPaused = value;
    }
    Vector2 GetRandomPositionOutsideCamera()
    {
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        // Déterminer un côté aléatoire pour l'apparition
        int side = Random.Range(0, 4);

        float x = 0, y = 0;
        switch (side)
        {
            case 0: // haut
                x = Random.Range(-width / 2 - spawnMargin, width / 2 + spawnMargin);
                y = height / 2 + spawnMargin;
                break;
            case 1: // bas
                x = Random.Range(-width / 2 - spawnMargin, width / 2 + spawnMargin);
                y = -height / 2 - spawnMargin;
                break;
            case 2: // gauche
                x = -width / 2 - spawnMargin;
                y = Random.Range(-height / 2 - spawnMargin, height / 2 + spawnMargin);
                break;
            case 3: // droite
                x = width / 2 + spawnMargin;
                y = Random.Range(-height / 2 - spawnMargin, height / 2 + spawnMargin);
                break;
        }

        // Convertir les coordonnées locales en coordonnées mondiales
        Vector2 spawnPosition = mainCamera.transform.position + new Vector3(x, y, 0);
        return spawnPosition;
    }

    public void Update()
    {
        float elapsedTime = Time.time - startTime;
        int currentMinutes = Mathf.FloorToInt(elapsedTime / 60);
        if (currentMinutes > topMinute)
        {
            topMinute++;
            HandleMinuteChanged(topMinute);
        }
    }

    private void HandleMinuteChanged(int minute)
    {
        CleanQueues();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        List<string> list = minuteSpawnerDictionnary[topMinute];
        EnemyMetaAttributes currentEnemy = null;
        Vector3 spawnPosition = new Vector3(-100, 50, 0);
        for (int i = 0; i < list.Count; i++)
        {
            currentEnemy = enemiesDatabase.getEnemyMetaAttributeByName(list[i]);
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int j = 0; j < currentEnemy.InstancesAmount; j++)
            {
                //InstantiateObject(currentEnemy.EnemyPrefab.gameObject);
                currentEnemy.EnemyPrefab.MinutePrint = topMinute;
                //NavMeshHit Hit;


                    GameObject obj = Instantiate(currentEnemy.EnemyPrefab.gameObject, spawnPosition, Quaternion.identity); 
                    obj.GetComponent<NavMeshAgent>().Warp(spawnPosition);
                    obj.GetComponent<Enemy>().Agent.enabled = false;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                


            }
            poolDictionary.Add(currentEnemy.Name, objectPool);
        }
    }

    private void CleanQueues()
    {
        foreach (KeyValuePair<string, Queue<GameObject>> entry in poolDictionary)
        {
            Queue<GameObject> queue = entry.Value;

            // Parcourir chaque élément de la queue
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = queue.Dequeue();
                DeleteObject(obj);
            }
        }
    }

    private void DeleteObject(GameObject netObject)
    {
        if (netObject != null)
        {
            // Détruire l'objet
            Destroy(netObject);
        }
    }
}
