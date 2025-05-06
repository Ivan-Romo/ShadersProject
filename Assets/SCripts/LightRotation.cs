using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject sphere;
    float red = 0;
    float blue = 0;
    float green = 0;

    Color newColor = Color.blue;

    public float rotationSpeed = 10f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }


    public void changeRed(float a){
        red = a;
        print(red);
        changeColor();
    }
    public void changeBlue(float a){
        blue = a;
        print(blue);
        changeColor();
    }
    public void changeGreen(float a){
        green = a;
        print(green);
        changeColor();
    }

    void changeColor(){
        print("Color canviao");
        sphere.GetComponent<Renderer>().material.SetColor("_Color", new Color(red,blue,green,1));
    }

    public void changeNormalMode(int option){
        sphere.GetComponent<Renderer>().material.DisableKeyword("_NORMALTYPE_WORLD");
        sphere.GetComponent<Renderer>().material.DisableKeyword("_NORMALTYPE_OBJECT");
        sphere.GetComponent<Renderer>().material.DisableKeyword("_NORMALTYPE_VIEW");

        if (option == 0)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_NORMALTYPE_WORLD");
        }
        else if (option == 1)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_NORMALTYPE_OBJECT");
        }
        else if (option == 2)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_NORMALTYPE_VIEW");
        }
            
    }

    public void changeMode(int option){
        sphere.GetComponent<Renderer>().material.DisableKeyword("_TYPE_JUST_COLOR");
        sphere.GetComponent<Renderer>().material.DisableKeyword("_TYPE_FUNCTION");
        sphere.GetComponent<Renderer>().material.DisableKeyword("_TYPE_C");

        if (option == 0)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_TYPE_JUST_COLOR");
        }
        else if (option == 1)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_TYPE_FUNCTION");
        }
        else if (option == 2)
        {
            sphere.GetComponent<Renderer>().material.EnableKeyword("_TYPE_C");
        }       
    }
}
