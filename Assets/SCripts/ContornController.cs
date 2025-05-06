using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContornController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphere;
    public Material material;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeGruix(float a)
    {
        material.SetFloat("_Gruix", a);
    }

    public void activaShaders()
    {
        float current = material.GetFloat("_Visible");
        float next = (current == 0f) ? 1f : 0f;
        material.SetFloat("_Visible", next);
    }

    public void randomColor()
    {
        Color randomCol = new Color(Random.value, Random.value, Random.value);
        material.SetColor("_Color", randomCol);
    }
}
