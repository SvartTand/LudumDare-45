using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfTypes : MonoBehaviour {

    public List<Type> types = new List<Type>();

    public Type GetType(string name)
    {
        for(int i = 0; i < types.Count; i++)
        {
            if(types[i].typeName == name)
            {
                return types[i];
            }
        }
        return null;
    }

}
