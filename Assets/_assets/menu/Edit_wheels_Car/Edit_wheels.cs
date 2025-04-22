using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit_wheels : MonoBehaviour
{

    public GameObject[] wheels;
    //public MeshFilter[] filter_Wheels;
    //public Material[] Materials_Wheels;

   

    // Start is called before the first frame update
   
    

    public void Edit_wheelsCar(Mesh filter_Wheels, Material Materials_Wheels)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            MeshFilter meshFilter = wheels[i].GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = wheels[i].GetComponent<MeshRenderer>();

            if (meshFilter != null && meshRenderer != null)
            {
                meshFilter.mesh = filter_Wheels;
                meshRenderer.material = Materials_Wheels;
            }
            else
            {
                Debug.LogWarning($"Wheel {wheels[i].name} is missing MeshFilter or MeshRenderer");
            }
        }
    }

    //public void Choose_Wheel(int index)
    //{
    //    index_wheel = index;
    //    Edit_wheelsCar();
    //}

}
