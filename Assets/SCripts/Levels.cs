using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels: MonoBehaviour
{

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSaturation(float a){

        material.SetFloat("_Levels", a );
    }

    public void activaShaders()
    {

    }
}
