using MRTKExtensions.QRCodes;
using UnityEngine;
using UnityEngine.UI;

public class JetController : MonoBehaviour
{

    public GameObject triggerObj;

    [SerializeField]
    private QRTrackerController trackerController;
    private QRTrackerController trackerController1;
    public GameObject[] tracker;
    public Text text;
    public int n = 0;
    public int i = 1;
    public GameObject tryyyy;
    //public GameObject Instantiate_Position; //物件的生成點。





    private void Start()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        tracker = GameObject.FindGameObjectsWithTag("tracker");
        for (n = 0; n < tracker.Length; n++)
        {
            tracker[n].GetComponent<QRTrackerController>().PositionSet += PoseFound;
            if (tracker[n].name == "Tracker1")
            {
                trackerController = tracker[n].GetComponent<QRTrackerController>();
            }
            if (tracker[n].name == "Tracker2")
            {
                trackerController1 = tracker[n].GetComponent<QRTrackerController>();
            }
        }
        /*trackerController = GameObject.Find("Tracker1").GetComponent<QRTrackerController>();
        trackerController1 = GameObject.Find("Tracker2").GetComponent<QRTrackerController>();*/
    }

    public void PoseFound(object sender, Pose pose)
    {

        if (trackerController.IsTrackingActive == false)
        {
            text.text = "(-3.09, -1.33, -1.32)";
            trackerController.IsTrackingActive = true;
            //tryyyy.GetComponent<MeshRenderer>().material.color=Color.red;
        }
        if (trackerController1.IsTrackingActive == false)
        {
            text.text = "(1, 1, 1)";
            trackerController1.IsTrackingActive = true;
            //tryyyy.GetComponent<MeshRenderer>().material.color = Color.blue;
        }



        if (i == 1)
        {
            triggerObj = GameObject.Find("triggerObj");
            triggerObj.SendMessage("getbuttomdown");
            Bundle_Test.QRpose = pose.position;
                //找到"triggerObj"後觸發/執行裡面的"getbuttomdown"函數
            /*  QRloading.go1.gameObject.transform.SetParent(GameObject.Find("JetHolder").transform);
              var childObj = transform.GetChild(0);
              childObj.SetPositionAndRotation(pose.position, pose.rotation);
              childObj.transform.Translate(-3.09f, -1.33f, -1.32f, Space.Self);
              childObj.transform.Rotate(90, 0, 0, Space.Self);

              //pose.position + new Vector3(-3.09f, -1.45f, -0.1f);
              //childObj.transform.Rotate(90, 0, 0);
            */
            
            i++;
        }

        else if (i == 2)
        {
            closevis(Bundle_Test.go1);
            i++;

        }

        else
        {
            openvis(Bundle_Test.go1);
            i = 2;

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

    
}