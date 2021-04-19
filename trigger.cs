using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public int i = 1;
    public GameObject triggerObj;
    // Start is called before the first frame update
    public void Start()
    {
        triggerObj = GameObject.Find("triggerObj");
    }
    public void triggering()
    {
        if (i == 1)
        {
            triggerObj.SendMessage("getbuttomdown");
            i++;
            print(2);
        }
        else if (i == 2)
        {
            closevis(Bundle_Test.go1);
            i++;
            print(3);
        }
        else if (i == 3)
        {
            openvis(Bundle_Test.go1);
            i = 2;
            print(2);
        }

    }

    public void closevis(GameObject model)
    {
        foreach (Transform child in model.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            closevis(child.gameObject);

        }
    }
    public void openvis(GameObject model)
    {
        foreach (Transform child in model.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            openvis(child.gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
