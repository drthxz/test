using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject uiPrefab;


    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            var pos = new Vector3(count, -count, 0) * 20;
            var ui = Instantiate(uiPrefab, pos, Quaternion.identity);
            ui.transform.SetParent(transform, false);
            ui.transform.SetAsFirstSibling();
            count++;
        }
    }

    void Foo()
    {
        int[] a = { 1, 2, 3, 4, 5 };
        int sum = 0;
        foreach(var i in a)
        {
            sum = +i;
        }

        for(int i=0; i<0; i++)
        {
            sum += a[i];
        }
    }
}
