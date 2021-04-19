
using UnityEngine;
using UnityEngine.UI;
using MRTKExtensions.QRCodes;

public class Scanonoff : MonoBehaviour
{
    public GameObject QRcodescan;
    //public GameObject qrcode;
    //public GameObject HandMenu;
    public GameObject JetHolder;
    public GameObject triggerObj;
    public Canvas Canvas01;
    //public GameObject QRcodescan1;
    //public GameObject TRYT;
    public bool QRonoff = false;
    public bool scann = true;
    public bool Modeldestroy = false;
    public Text textscan;
    public Text textt;
    // Start is called before the first frame update
    void Start()
    {
        // qrcode = GameObject.Find("QRCODE");
        //HandMenu = GameObject.Find("HandMenu");
        JetHolder = GameObject.Find("JetHolder");
        triggerObj = GameObject.Find("triggerObj");
        QRcodescan = GameObject.Find("Trackers");
        QRcodescan.SetActive(false);
        //HandMenu.SetActive(false);
        JetHolder.SetActive(false);
        //triggerObj.SetActive(false);
        textt.text = "";
        textscan.text = "";
        //qrcode.SetActive(false);
    }
    public void scan()

    {
        textscan.text = "掃描開啟中";

        //QRcodescan1 = GameObject.Find("Tracker2");
        //TRYT = GameObject.Find("JetHolder");
        if (scann == true)
        {
            QRcodescan.SetActive(false);
            //QRcodescan1.GetComponent<QRTrackerController>().enabled = false;
            //TRYT.GetComponent<JetController>().enabled = false;
            //TRYT.GetComponent<JetController2>().enabled = false;
            scann = false;
            textscan.text = "掃描關閉中";
        }
        else
        {
            QRcodescan.SetActive(true);
            // QRcodescan1.GetComponent<QRTrackerController>().enabled = true;
            // TRYT.GetComponent<JetController>().enabled = true;
            //TRYT.GetComponent<JetController2>().enabled = true;
            scann = true;
            textscan.text = "掃描開啟中";
        }
    }
    public void QRONOFF()

    {

        if (QRonoff == true)
        {
            QRcodescan.SetActive(false);
            //HandMenu.SetActive(false);
            JetHolder.SetActive(false);
            //triggerObj.SetActive(false);
            textt.text = "";
            textscan.text = "";
            QRonoff = false;
           // closeviss(QRloading.go1);
        }
        else
        {

            QRcodescan.SetActive(true);
            //HandMenu.SetActive(true);
            JetHolder.SetActive(true);
            //triggerObj.SetActive(true);
            textt.text = "(0,0,0)";
            textscan.text = "掃描開啟中";
            QRonoff = true; ;

        }
    }
    public void closeviss(GameObject model)
    {
        
        foreach (Transform child in model.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            closeviss(child.gameObject);

        }
    }
    public void ModelDestroy()
    {
        Destroy(Bundle_Test.go1);
    }

    // Update is called once per frame
    void Update()
        {

        }
    
}
