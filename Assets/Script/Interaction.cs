using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float pi = 3.14f;
        Debug.Log(pi);

        int[] inTable = {34,56,76,34,100};
        Debug.Log(inTable);

        string hello(string name)
        {
            return "Bonjour " + name;
        }

        Debug.Log(hello("MMI"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
