using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderCCC : MonoBehaviour
{
    public GameObject[] prefabs;
    private GameObject prefab1;
    private GameObject prefab2;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        BuildWorld();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            BuildWorld();
        }
    }
    private void BuildWorld()
    {
        ///Generacion de mundo usando carga de escenas
        //SceneManager.LoadScene(Random.Range(1, 5), LoadSceneMode.Single);
        //SceneManager.LoadScene(Random.Range(1, 5), LoadSceneMode.Additive);

        //Generacion de mundo usando prefabs
        Destroy(prefab1);
        Destroy(prefab2);
        /*prefab1 = null;
        prefab2 = null;*/

        prefab1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                    Vector3.zero,
                    Quaternion.identity);
        prefab2 = Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                    Vector3.right *20f,
                    Quaternion.identity);
    }
}
