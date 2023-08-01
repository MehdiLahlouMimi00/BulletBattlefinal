using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class FirstProcessing : MonoBehaviour
{
    
    public List<GameObject> walls;


    [SerializeField] private Material material;



    private void Start()
    {
        colorMaterial(material);
        applyMaterial(material);
    }

    private void colorMaterial(Material material)
    {
        int randomR, randomG, randomB;
        randomR = Random.Range(0, 220);
        randomG = Random.Range(0, 220);
        randomB = Random.Range(0, 220);

        Debug.Log(randomR + " " + randomG + " " + randomB);


        material.SetColor("_Color", new Color(randomR, randomG, randomB)) ;
    }


    private void applyMaterial(Material material)
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<MeshRenderer>().material = material;
        }
    }
}
