using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_conveer : MonoBehaviour
{
    public Transform Start_pos;
    public GameObject[] G_O= new GameObject[3];
    public float Speed_spawn;
    public bool End;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "G_O") 
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator Spawn() 
    {
        while (End==false) 
        {
            int k = Random.Range(0, 3);
           GameObject obj= Instantiate(G_O[k], Start_pos.transform.position, G_O[k].transform.rotation);
            obj.name = G_O[k].name;
            yield return new WaitForSeconds(Speed_spawn);
        }
    }
}
