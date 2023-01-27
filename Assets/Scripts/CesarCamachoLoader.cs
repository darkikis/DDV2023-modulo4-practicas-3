using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CesarCamachoLoader : MonoBehaviour
{

    public int segmentos = 1;
    public GameObject[] prefabs;
    
    
    private GameObject prefab1;
    private GameObject prefab2;

    private GameObject[] refPrefabs;

    private List<GameObject> refPrefabsList = new List<GameObject>();

    private int tamanioScene = 20;

    private int factorQuadratic = 1;

    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        refPrefabs = new GameObject[segmentos];
        calculateFactorQuadratic();
        
        //BuildWorld();
        BuildWorldMatricial();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //BuildWorld();
            segmentos++;
            calculateFactorQuadratic();
            BuildWorldMatricial();
        }
    }
    private void BuildWorld()
    {
        
        //Generacion de mundo usando prefabs
        //Destroy
        for (int i = 0; i < segmentos; i++){
            Destroy(refPrefabs[i]);

        }

        for (int i = 0; i < segmentos; i++) {
            if (i == 0)
            {
                prefab1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                 Vector3.zero,
                 Quaternion.identity);
                refPrefabs[i] = prefab1;
            }
            else {
                prefab1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                    Vector3.right * 20f*i,
                    Quaternion.identity);
                refPrefabs[i] = prefab1;
            }
           
            
        }
    }

    private void BuildWorldMatricial()
    {

        //Generacion de mundo usando prefabs
        //Destroy
        for (int i = 0; i < refPrefabsList.Count; i++)
        {
            Destroy(refPrefabsList[i]);

        }

        Vector3 positionObj = Vector3.zero;

        int counter = 1;

        for (int i = 0; i < factorQuadratic; i++)
        {
            for (int j = 0; j < factorQuadratic; j++) {

                if (counter < segmentos) {
                    positionObj.x = tamanioScene * i;
                    positionObj.y = 0;
                    positionObj.z = tamanioScene * j;
                    prefab1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                    positionObj,
                    Quaternion.identity);

                    refPrefabsList.Add(prefab1);
                    counter++;
                }
            }
        }
    }

    private void calculateFactorQuadratic() {
        for (int i = 1; i <= segmentos; i++)
        {
            if ((i * i) >= segmentos)
            {
                factorQuadratic = i;
                break;
            }
            else
            {
                continue;
            }

        }
        Debug.Log("Factor:" + factorQuadratic);
    }
}
