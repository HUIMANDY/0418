using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class Bundle_Test : MonoBehaviour
{
    private float x = -3.44f;
    private float y = -1.1f;
    private float z = 1.02f;
    public static GameObject go1;
    public BoundingBox bbox;
    public GameObject mdl;
    public bool firstfloor = false;
    public static Vector3 QRpose;
    //public Text Status;

    /*private void Awake()
    {
        instance = this;
    }*/
    public IEnumerator getmodelfromazure()
    {
        //Status.text = "已點擊";
        yield return new WaitForSeconds(2f);
        var uwr = UnityWebRequestAssetBundle.GetAssetBundle("https://firebasestorage.googleapis.com/v0/b/hui0414-b2e18.appspot.com/o/1fv1?alt=media&token=8fa83e64-03d6-4e60-8264-3ceb4cf9adc7");
        yield return uwr.SendWebRequest();

        // Get an asset from the bundle and instantiate it.
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

        //var loadAsset = bundle.LoadAssetAsync<GameObject>("Assets/Players/MainPlayer.prefab");
        var loadAsset = bundle.LoadAsset("1fv1");
        yield return loadAsset;

        //Instantiate(loadAsset.asset);
        //Instantiate(loadAsset);
        //if (Instantiate(loadAsset)) = true;
        //yield return new WaitForSeconds(2f);
        go1 = Instantiate(loadAsset) as GameObject;
        go1.transform.parent = GameObject.Find("ModelManager").transform;
        //  Status.text = "已顯示Cube";
        //Getrender(go1);
        GetChildmesh(go1);
        SplitList(go1);
        setposition(go1);
        Getread(go1);
        Getamountinfo(go1);
        addworkitem(go1);
        Getclickapp(go1);
        //GetChildRecursive(go1);
        rotationaxis(go1);
        Manipulator(go1);
        Cursorcontextinfo(go1);
        Cursorcontext(go1);
        Debug.Log("123");
        MinMaxScale(go1);
        getbound(go1);
        grabbable(go1);
        renewcolor.Loadmtl = 1;
        if(GameObject.Find("1fpipe(Clone)")!=null)
        {
            GameObject.Find("1fpipe(Clone)").transform.SetParent(go1.transform);
        }
        if (GameObject.Find("drainpipe(Clone)") != null)
        {
            GameObject.Find("drainpipe(Clone)").transform.SetParent(go1.transform);
        }

        GameObject.Find("922434").GetComponent<readdata>().work01 = "N02輕隔間-雙面單層輕隔間，4米以下";
        GameObject.Find("922434").GetComponent<readdata>().Object = "基本牆";
        GameObject.Find("922434").GetComponent<readdata>().level = "1F";
        GameObject.Find("1046217").GetComponent<readdata>().work01 = "S01水泥砂漿粉刷工程";
        GameObject.Find("1046217").GetComponent<readdata>().work02 = "S02油漆工程";
        GameObject.Find("1046217").GetComponent<readdata>().Object = "基本牆";
        GameObject.Find("1046217").GetComponent<readdata>().level = "1F";
        //GameObject.Find("764816").GetComponent<readdata>().work01 = "S01水泥砂漿粉刷工程";
        /* GameObject.Find("764816").GetComponent<readdata>().work02 = "S02油漆工程";
         GameObject.Find("764816").GetComponent<readdata>().Object = "樓板";
         GameObject.Find("764816").GetComponent<readdata>().level = "1F";*/
        GameObject.Find("768845").GetComponent<readdata>().work01 = "S01水泥砂漿粉刷工程";
        GameObject.Find("768845").GetComponent<readdata>().work02 = "S02油漆工程";
        GameObject.Find("768845").GetComponent<readdata>().Object = "M_混凝土-矩形-柱";
        GameObject.Find("768845").GetComponent<readdata>().level = "1F";
        // SendMessage("okokokgo");
        //順序很重要
    }
    public void getbuttomdown()
    {
        if (firstfloor.Equals(false))
        {

            StartCoroutine(getmodelfromazure());
            firstfloor = true;
        }
        else if (firstfloor.Equals(true))
        {
            firstfloor = false;
            //Destroy(go1);
        }
    }

    /*public  void closeObj()
    {
        if (go1.activeSelf)//控制打勾狀況
        {
            go1.SetActive(false);
        }
        else
        {
            go1.SetActive(true);

        }
    }*/
    public void setposition(GameObject BIM123)
    {
        BIM123.transform.position = new Vector3(x, y, z);
        BIM123.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        BIM123.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
        //Status.text = "已移動";
        Debug.Log("OK");
    }
    public void closeshadow(GameObject wwwwww)
    {
        wwwwww.gameObject.AddComponent<NearInteractionGrabbable>();
    }
    public void grabbable(GameObject wwwwww)
    {
        wwwwww.gameObject.AddComponent<NearInteractionGrabbable>();
    }
    public void MinMaxScale(GameObject wwwwwww)
    {
        wwwwwww.gameObject.AddComponent<MinMaxScaleConstraint>();
        MinMaxScaleConstraint scaleConstraint = wwwwwww.gameObject.GetComponent<MinMaxScaleConstraint>();
        scaleConstraint.ScaleMinimum = 0.0000000005f;
        scaleConstraint.ScaleMaximum = 2f;
    }
    public void getbound(GameObject target)
    {
        //    BoxCollider boxCollider= target.gameObject.AddComponent<BoxCollider>();
         
              target.gameObject.AddComponent<BoundingBox>();
    
        if (target.gameObject.GetComponent<BoxCollider>() == false)
        {
            target.AddComponent<BoxCollider>();
        
        }
   
        target.gameObject.GetComponent<BoxCollider>().center = new Vector3(-15.66828f, 5.330802f, 6.126272f);
        target.gameObject.GetComponent<BoxCollider>().size = new Vector3(75.73905f, 11.6616f, 52.29235f);
        // Make the scale handles large
        target.gameObject.GetComponent<BoundingBox>().BoundsOverride = target.gameObject.GetComponent<BoxCollider>();
        target.gameObject.GetComponent<BoundingBox>().ScaleHandleSize = 0.1f;
        //targetbdb.BoundingBoxActivation = "Activate By Proximity And Pointer"
        // Hide rotation handles
        target.gameObject.GetComponent<BoundingBox>().WireframeEdgeRadius = 0.005f;
        target.gameObject.GetComponent<BoundingBox>().ShowRotationHandleForX = false;
        target.gameObject.GetComponent<BoundingBox>().ShowRotationHandleForY = true;
        target.gameObject.GetComponent<BoundingBox>().ShowRotationHandleForZ = false;
        target.gameObject.GetComponent<BoundingBox>().BoxMaterial = Resources.Load<Material>("BoundingBox");
        target.gameObject.GetComponent<BoundingBox>().BoxGrabbedMaterial = Resources.Load<Material>("BoundingBoxGrabbed");
        target.gameObject.GetComponent<BoundingBox>().HandleMaterial = Resources.Load<Material>("BoundingBoxHandleWhite");
        target.gameObject.GetComponent<BoundingBox>().HandleGrabbedMaterial = Resources.Load<Material>("BoundingBoxHandleBlueGrabbed");
        target.gameObject.GetComponent<BoundingBox>().ScaleHandlePrefab = Resources.Load<GameObject>("MRTK_BoundingBox_ScaleHandle");
        target.gameObject.GetComponent<BoundingBox>().ScaleHandleSlatePrefab = Resources.Load<GameObject>("MRTK_BoundingBox_ScaleHandle_Slate");
        target.gameObject.GetComponent<BoundingBox>().ScaleHandleSize = 0.016f;
        target.gameObject.GetComponent<BoundingBox>().ScaleHandleColliderPadding = new Vector3(0.16f, 0.16f, 0.16f);
        target.gameObject.GetComponent<BoundingBox>().RotationHandlePrefab = Resources.Load<GameObject>("MRTK_BoundingBox_RotateHandle");
        target.gameObject.GetComponent<BoundingBox>().RotationHandleSize = 0.016f;
        target.gameObject.GetComponent<BoundingBox>().RotateHandleColliderPadding = new Vector3(0.16f, 0.16f, 0.16f);
        target.gameObject.GetComponent<BoundingBox>().ProximityEffectActive = true;





    }
    /*public  void closebdb()
    {
        BoundingBox bbbox = go1.gameObject.GetComponent<BoundingBox>();

        if (bbbox.enabled == true)//控制打勾狀況
        {
            bbbox.enabled = false;
        }
        else
        {
            bbbox.enabled = true;
        }

    }*/

    /*public  void backtoriginal()
    {
        mdl = GameObject.Find("1fv1(Clone)");
            mdl.transform.position = new Vector3(1.9131881f, -1.260146f, 4.170755f);
            mdl.transform.localScale = new Vector3(1f, 1f, 1f);
            mdl.transform.localRotation = Quaternion.Euler(1f, 1f, 1f);
        Debug.Log("回到原位");

    }*/
    public void Cursorcontextinfo(GameObject w)
    {
        w.gameObject.AddComponent<CursorContextInfo>();

    }
    public void Cursorcontext(GameObject ww)
    {
        ww.gameObject.AddComponent<CursorContextObjectManipulator>();

    }
    public void Manipulator(GameObject www)
    {
        www.gameObject.AddComponent<ObjectManipulator>();

    }
    public void rotationaxis(GameObject wwww)
    {

        wwww.gameObject.AddComponent<RotationAxisConstraint>();
    }

    public void SplitList(GameObject mdll)//拆分場景名字

    {
        string[] elementid;
        string[] stringSeparators = new string[] { "[", "]" };

        //mdl = GameObject.Find("1fv1(Clone)");
        Transform trans = mdll.transform;
        //string childTrans = trans.name ;
        // HierarchyText = mdl.transform.GetChild(name);
        //  children = ObjectA.GetComponentsInChildren.＜transform＞();
        foreach (Transform objectt in trans)
        {
            if (objectt == null)
            {
                continue;
            }
            elementid = objectt.name.Split(stringSeparators, StringSplitOptions.None);
            objectt.name = elementid[1];

            foreach (Transform objecttin in objectt.transform)
            {
                elementid = objecttin.name.Split(stringSeparators, StringSplitOptions.None);
                objecttin.name = elementid[1];
                //int Num = (elementid.Length);
                /*for (int i = 1; i < (Num); i++) 
                {
                    string ID = elementid[i];
                    objectt.name = ID;
                    Debug.Log("123");
                }*/
            }
        }

    }
    public void Getrender(GameObject gameObject1234)
    {
        if (null == gameObject1234)
            return;

        foreach (Transform child in gameObject1234.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>()==true)
            {
                child.gameObject.transform.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
                child.gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
            }
            else
            {
                child.gameObject.AddComponent<MeshRenderer>();
                child.gameObject.transform.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
                child.gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
            }
                Getrender(child.gameObject);
            }


        }
                    
        public void GetChildmesh(GameObject gameObject123)
        {
            if (null == gameObject123)
                return;

            foreach (Transform child in gameObject123.transform)
            {
                if (null == child)
                    continue;
                if (child.gameObject.GetComponent<MeshCollider>())
                {
                }
                else
                {
                    child.gameObject.AddComponent<MeshCollider>();

                }
                GetChildmesh(child.gameObject);

            }


        }
        public void Getclickapp(GameObject gameObject456)
        {
            if (null == gameObject456)
                return;

            foreach (Transform child in gameObject456.transform)
            {
                if (null == child)
                    continue;
                if (child.gameObject.GetComponent<pointerevent>())
                {
                }
                else
                {
                    child.gameObject.AddComponent<pointerevent>();

                }
                Getclickapp(child.gameObject);

            }


        }
        public void Getread(GameObject gameObject789)
        {
            if (null == gameObject789)
                return;

            foreach (Transform child in gameObject789.transform)
            {
                if (null == child)
                    continue;
            if (child != GameObject.Find("getCKEditorImage"))
            {
                if (child.gameObject.GetComponent<readdata>())
                {
                }
                else
                {
                    child.gameObject.AddComponent<readdata>();

                }

            }
            Getread(child.gameObject);
        }

        }
        public void Getamountinfo(GameObject gameObject789)
        {
            if (null == gameObject789)
                return;

            foreach (Transform child in gameObject789.transform)
            {
                if (null == child)
                    continue;
                if (child.gameObject.GetComponent<workitemamount>())
                {
                }
                else
                {
                    child.gameObject.AddComponent<workitemamount>();
                }
                Getamountinfo(child.gameObject);

            }

        }
        public void closechildmesh()
        {
            go1 = GameObject.Find("1fv1(Clone)");
            if (null == go1)
                return;

            foreach (Transform child in go1.transform)
            {
                if (null == child)
                    continue;
                if (child.gameObject.GetComponent<MeshCollider>())
                {
                    child.gameObject.GetComponent<MeshCollider>().enabled = false;
                }
                else
                {
                    child.gameObject.GetComponent<MeshCollider>().enabled = true;
                    go1.gameObject.AddComponent<NearInteractionGrabbable>();

                }
                //closechildmesh(child.gameObject);


            }
        }
        public void addworkitem(GameObject gameObjectabc)
        {
            go1 = GameObject.Find("1fv1(Clone)");
            if (null == gameObjectabc)
                return;

            foreach (Transform child in gameObjectabc.transform)
            {
                if (null == child)
                    continue;
                if (child.gameObject.GetComponent<readdata>())
                {
                    child.gameObject.SendMessage("okokokgo");
                }
                else
                {

                }
                addworkitem(child.gameObject);


            }

        }
    }











