#define debugging

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class BattleMapGenerator : MonoBehaviour
{
    public GameObject[] town;
    public GameObject[] plain;
    public GameObject[] forest;
    public GameObject[] enemies;

    private bool doingSetup;
    private GameObject instance;

    private void Awake()
    {
        InitTest();
    }

    public void GenerateBattleMap(int type,int level)
    {
        doingSetup = true;

        GroundSetup(type);
        RoleSetup(type,level);

        doingSetup = false;
    }

    private void GroundSetup(int type)
    {
        if (type == Varibles.town)
        {
            int index = Random.Range(0, town.Length);
            instance = Instantiate(town[index], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (type == Varibles.plain)
        {
            int index = Random.Range(0, plain.Length);
            instance = Instantiate(plain[index], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (type == Varibles.forest)
        {
            int index = Random.Range(0, forest.Length);
            instance = Instantiate(forest[index], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
    }

    private void RoleSetup(int type,int level)
    {
        foreach(Transform child in transform)
        {
            UnityEngine.Debug.Log(child.gameObject.name);
        }
    }

    [Conditional("debugging")]
    private void InitTest()
    {
        GenerateBattleMap(Varibles.plain, 1);
    }
}
