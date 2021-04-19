using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using TMPro;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class QRCODEHM : MonoBehaviour
{
    public static bool Location;
    public static int Points = 1;
    public static GameObject PointA;
    public static GameObject PointB;
    public static GameObject PointC;
    public static GameObject PointD;
    public static GameObject thismdll;
    private static Vector3 Vba;
    private static Vector3 Vac;
    private static Vector3 Vbd;
    private static Vector3 record;
    private static float Lac;
    private static float Lbd;
    private static float angle;
    private RaycastHit hitInf;
    private float distance;
    //public static int ii = 0;
    public static GameObject QRimage;
    public static Text TEXTTTTT;
    // Use this for initialization
    void Awake()
    {
    }  
    public void Ianhsu()
    {
        GameObject a = GameObject.Find("1fv1(Clone)");

        Debug.Log("00000");
        //Box = Resources.Load("po1") as GameObject;
        //Box1 = Resources.Load("po2") as GameObject;

        foreach (Transform child in a.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.name == "getCKEditorImage")  //找到QRCODE
            {

                
                GameObject.Find("Textguide").GetComponent<Text>().enabled = true;
                /*a.GetComponent<NearInteractionGrabbable>().enabled = false;
                PointA = Instantiate(GameObject.Find("po3").gameObject);
                PointB = Instantiate(GameObject.Find("po3").gameObject);
                PointC = Instantiate(GameObject.Find("po3").gameObject);
                PointD = Instantiate(GameObject.Find("po3").gameObject);
                PointA.transform.position = Bundle_Test.QRpose + new Vector3(0.05f, 0.05f, 0f);
                PointB.transform.position = QRimage.transform.position + new Vector3(0.05f, 0.05f, 0f);
                PointC.transform.position = Bundle_Test.QRpose + new Vector3(-0.05f, -0.05f, 0f);
                PointD.transform.position = QRimage.transform.position + new Vector3(-0.05f, -0.05f, 0f);
                CaculateAndRotate();

                openmesh(GameObject.Find("1fv1(Clone)"));
                openrenderer(GameObject.Find("1fv1(Clone)"));
                ModelMaganer.Loadobj = 2;*/

                Instantiate(GameObject.Find("po1").gameObject, Bundle_Test.QRpose + new Vector3(0.05f, 0.05f, 0f), new Quaternion(0, 0, 0, 0));
                //Box = Instantiate(GameObject.Find("LocationManager").transform.GetChild(1).gameObject, Ian.transform.position + new Vector3(0.05f, 0.05f, 0f), new Quaternion(0, 0, 0, 0));

            }
        }
    }
    public static void ModelLocation()
    {
        GameObject QRimage = GameObject.Find("getCKEditorImage").gameObject;
        Debug.Log(QRimage.name);
        RaycastHit hitInfo;
        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hitInfo,
                20.0f,
                Physics.DefaultRaycastLayers))
        {
            if (Points == 1)
            {
                Debug.Log("1");
                PointA = Instantiate(GameObject.Find("LocationManager").transform.GetChild(0).gameObject);
                PointA.SetActive(true);
                PointA.transform.position = hitInfo.point;
                PointA.transform.parent = GameObject.Find("LocationManager").transform;
                /* foreach (Transform child in thismdll.transform)
                 {

                     foreach (Transform childin in child.transform)
                     {

                         if (childin.gameObject.GetComponent<MeshCollider>() == true)
                         {
                             childin.gameObject.GetComponent<MeshCollider>().enabled = true;
                         }
                     }
                 }*/
                openmesh(GameObject.Find("1fv1(Clone)"));
                openrenderer(GameObject.Find("1fv1(Clone)"));
                Debug.Log("QQ");
                Instantiate(GameObject.Find("po2").gameObject, QRimage.transform.position + new Vector3(0.05f, 0.05f, 0f), new Quaternion(0, 0, 0, 0));
                Points++;
                return;



            }
            if (Points == 2)
            {
                Debug.Log("2");
                PointB = Instantiate(GameObject.Find("LocationManager").transform.GetChild(0).gameObject);
                PointB.SetActive(true);
                PointB.transform.position = hitInfo.point;
                PointB.transform.parent = GameObject.Find("LocationManager").transform;
                /*  foreach (Transform child in thismdll.transform)
                  {

                      foreach (Transform childin in child.transform)
                      {
                          if (childin.gameObject.GetComponent<MeshCollider>() == true)
                          {
                              childin.gameObject.GetComponent<MeshCollider>().enabled = false;
                          }

                      }
                  }*/
                closemesh(GameObject.Find("1fv1(Clone)"));
                closerenderer(GameObject.Find("1fv1(Clone)"));
                Instantiate(GameObject.Find("po1").gameObject, Bundle_Test.QRpose + new Vector3(-0.05f, -0.05f, 0f), new Quaternion(0, 0, 0, 0));
                Points++;
                return;


            }
            if (Points == 3)
            {
                Debug.Log("3");
                PointC = Instantiate(GameObject.Find("LocationManager").transform.GetChild(0).gameObject);
                PointC.SetActive(true);
                PointC.transform.position = hitInfo.point;
                PointC.transform.parent = GameObject.Find("LocationManager").transform;

                Instantiate(GameObject.Find("po2").gameObject, QRimage.transform.position + new Vector3(-0.05f, -0.05f, 0f), new Quaternion(0, 0, 0, 0));
                openmesh(GameObject.Find("1fv1(Clone)"));
                openrenderer(GameObject.Find("1fv1(Clone)"));
                Points++;

                return;
            }
            if (Points == 4)
            {
                Debug.Log("4");
                PointD = Instantiate(GameObject.Find("LocationManager").transform.GetChild(0).gameObject);
                PointD.SetActive(true);
                PointD.transform.position = hitInfo.point;
                PointD.transform.parent = GameObject.Find("LocationManager").transform;
                //RecordAllPoints(thismdll);
                //GameObject.Find("Button_Location").transform.GetChild(5).gameObject.SetActive(false);
                CaculateAndRotate();
                GameObject.Find("Textguide").GetComponent<Text>().enabled= false;
                
                //RecordAllPoints(thismdll);
                Debug.Log(ModelMaganer.mdlobjList);
                ModelMaganer.Loadobj = 2;
                return;
            }
        }
    }

    public static void CaculateAndRotate()
    {
        Vba = PointA.transform.position - PointB.transform.position;
        //Vab[1] = 0;
        PointB.transform.position = PointB.transform.position + Vba;
        PointD.transform.position = PointD.transform.position + Vba;
        Vac = PointC.transform.position - PointA.transform.position;
        Vbd = PointD.transform.position - PointB.transform.position;
        Vac.y = 0;
        Vbd.y = 0;
        Debug.Log(Vac + " , " + Vbd);
        angle = Vector3.Angle(Vbd, Vac);
        GameObject ModelBox = new GameObject();
        ModelBox.transform.position = PointA.transform.position;
        GameObject BIM = GameObject.Find("1fv1(Clone)");
        BIM.transform.parent = ModelBox.transform;
        BIM.transform.position = BIM.transform.position + Vba;
        Vector3 bdcrossac = Vector3.Cross(Vbd, Vac);
        float Crossresult = Vector3.Dot(bdcrossac, Vector3.up);
        Debug.Log(Crossresult);
        if (Crossresult >= 0)
        {
            ModelBox.transform.eulerAngles = new Vector3(ModelBox.transform.eulerAngles.x, ModelBox.transform.eulerAngles.y + angle, ModelBox.transform.eulerAngles.z);
        }
        else
        {
            ModelBox.transform.eulerAngles = new Vector3(ModelBox.transform.eulerAngles.x, ModelBox.transform.eulerAngles.y - angle, ModelBox.transform.eulerAngles.z);
        }
        BIM.transform.parent = null;
        CleanAllPoints();
        GameObject.Find("QRCODE").SendMessage("Locater");
        GameObject.Destroy(ModelBox);
    }

    public static void CleanAllPoints()
    {
        foreach (GameObject CountBall in GameObject.FindGameObjectsWithTag("LocatePoint"))
        {
            Destroy(CountBall);
            
        }
        Points = 1;
        foreach (GameObject CountB in GameObject.FindGameObjectsWithTag("po"))
        {
            Destroy(CountB);

        }

        //Destroy(GameObject.Find("po2(Clone)"));

    }

    public static void openmesh(GameObject abc)
    {
        if (null == abc)
            return;
        foreach (Transform child in abc.transform)
        {
            if (null == abc)
                continue;
            if (child.gameObject.GetComponent<MeshCollider>() == true)
            {
                child.gameObject.GetComponent<MeshCollider>().enabled = true;
            }
            openmesh(child.gameObject);
        }
    }
    public static void openrenderer(GameObject abc)
    {
        if (null == abc)
            return;
        foreach (Transform child in abc.transform)
        {
            if (null == abc)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>() == true)
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            if (child.gameObject.GetComponent<SpriteRenderer>() == true)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            openrenderer(child.gameObject);
        }
    }
    public static void closemesh(GameObject abc)
    {
        if (null == abc)
            return;
        foreach (Transform child in abc.transform)
        {
            if (null == abc)
                continue;
            if (child.gameObject.GetComponent<MeshCollider>() == true)
            {
                child.gameObject.GetComponent<MeshCollider>().enabled = false;
            }

            closemesh(child.gameObject);
        }

    }
    public static void closerenderer(GameObject abc)
    {
        if (null == abc)
            return;
        foreach (Transform child in abc.transform)
        {
            if (null == abc)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>() == true)
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if (child.gameObject.GetComponent<SpriteRenderer>() == true)
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            closerenderer(child.gameObject);
        }


    }
    public void Locater()
    {
        if (Location.Equals(false))
        {
            //transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
            //LuisManager.instance.LUISFeedback.text = "LUIS:OK,I already turn on Location Function";
            Location = true;
            GameObject.Find("MainCamera").transform.GetChild(0).gameObject.SetActive(true);

            closerenderer(GameObject.Find("1fv1(Clone)"));
            foreach (Transform child in GameObject.Find("1fv1(Clone)").transform)
            {

                foreach (Transform childin in child.transform)
                {
                    if (childin.gameObject.GetComponent<MeshCollider>() == true)
                    {
                        childin.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
                }
            }
            return;
        }
        if (Location.Equals(true))
        {
            //transform.GetChild(0).GetComponent<MeshRenderer>().material = GameObject.Find("Material").transform.GetChild(0).GetComponent<MeshRenderer>().material;
            Set_Model.CleanAllPoints();
            GameObject.Find("MainCamera").transform.GetChild(0).gameObject.SetActive(false);
            //LuisManager.instance.LUISFeedback.text = "The Location Function is off";
            Location = false;
            return;
        }
    }
    public void Update()
    {
        if (Location.Equals(true))
        {
            if (Physics.Raycast(
               Camera.main.transform.position,
               Camera.main.transform.forward,
               out hitInf,
               20.0f,
               Physics.DefaultRaycastLayers))
            {
                GameObject.Find("MainCamera").transform.GetChild(0).gameObject.transform.position = hitInf.point;
                distance = (Camera.main.transform.position - hitInf.point).magnitude;
                if (distance < 0.8f)
                {
                    GameObject.Find("MainCamera").transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                }
                else if (distance > 0.8f)
                {
                    GameObject.Find("MainCamera").transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
