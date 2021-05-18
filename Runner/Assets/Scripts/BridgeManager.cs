using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class BridgeManager : MonoBehaviour
{
    public GameObject[] bridgePrefabs;
    //public GameObject[] extraObs;
    private Transform playerTransform;
    private float spawnZ = -7.62f;
    private float bridgePartLength = 7.62f;
    private int partsOnScreen = 7;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeParts;
    private int level = 1;
    private ScoreScript scoreScript;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.Find("Player").GetComponent<ScoreScript>();
        activeParts = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0 ; i<partsOnScreen ; i++){
            if(i < 3){
                SpawnParts(0);
            }else{
                SpawnParts(); // Remove argument
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        level = scoreScript.getLevel();
        if(playerTransform.position.z>(spawnZ-partsOnScreen * bridgePartLength)){
            SpawnParts();// remove argument
            DeleteParts();
        }
    }

    private void SpawnParts(int prefabIndex = -1){
        GameObject go;
        if(prefabIndex == -1){

                go = Instantiate(bridgePrefabs[RandomPrefabIndex()]) as GameObject;
            
        }else{
            go = Instantiate(bridgePrefabs[prefabIndex]) as GameObject;
        }
        
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += bridgePartLength;
        activeParts.Add(go);
    }
    private void DeleteParts(){

        Destroy(activeParts[0]);
        activeParts.RemoveAt(0);

    }
    private int RandomPrefabIndex(){
        
        if(bridgePrefabs.Length <=1){
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex){
            if(level<3){
                randomIndex = Random.Range(0,bridgePrefabs.Length-2);
            }else if(level>= 3 && level<5){
                randomIndex = Random.Range(0,bridgePrefabs.Length-1);
            }else{
                 randomIndex = Random.Range(0,bridgePrefabs.Length);
            }
            
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
