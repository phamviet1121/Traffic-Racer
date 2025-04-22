using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_bool_Array : MonoBehaviour
{
    public int cars;



    public BoolArraySaver BoolArraySaver;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool load_classifyS_0(int classifyS)
    {
        return BoolArraySaver.index_Cars[cars].Classifys[0].var_bool[classifyS];
    }
    public bool load_classifyS_1(int classifyS)
    {
        return BoolArraySaver.index_Cars[cars].Classifys[1].var_bool[classifyS];
    }
    public bool load_classifyS_2(int classifyS)
    {
        return BoolArraySaver.index_Cars[cars].Classifys[2].var_bool[classifyS];
    }


    public void saver_classifyS_0(int classifyS, bool a)
    {
        BoolArraySaver.index_Cars[cars].Classifys[0].var_bool[classifyS] = a;
    }
    public void Saver_classifyS_1(int classifyS, bool a)
    {
        BoolArraySaver.index_Cars[cars].Classifys[1].var_bool[classifyS] = a;
    }
    public void Saver_classifyS_2(int classifyS, bool a)
    {
        BoolArraySaver.index_Cars[cars].Classifys[2].var_bool[classifyS] = a;
    }
}
