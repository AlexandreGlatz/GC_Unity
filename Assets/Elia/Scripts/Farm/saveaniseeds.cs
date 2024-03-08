using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class saveaniseeds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        saveaniseeds ani = GetComponent<saveaniseeds>();
        Destroy(ani);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
