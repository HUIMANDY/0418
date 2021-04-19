using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Physics;
using System;
using UnityEngine.EventSystems;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Utilities;

public class TapManager2 : MonoBehaviour, IMixedRealityPointerHandler
{

    /// <summary>
    /// When a pointer down event is raised, this method is used to pass along the event data to the input handler.
    /// </summary>
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {

    }

    /// <summary>
    /// Called every frame a pointer is down. Can be used to implement drag-like behaviors.
    /// </summary>
    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {

    }

    /// <summary>
    /// When a pointer up event is raised, this method is used to pass along the event data to the input handler.
    /// </summary>
    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {

    }

    /// <summary>
    /// When a pointer clicked event is raised, this method is used to pass along the event data to the input handler.
    /// </summary>
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
     //   Debug.Log("OnPointerClicked");
        Ontoo();
    }
    // Checking the amount of time passed between OnPointerClicked calls is handling the case when OnPointerClicked is called
    // twice after one click.  If OnPointerClicked is called twice after one click, the object will be selected and then immediately
    // unselected. If OnPointerClicked calls are within 0.5 secs of each other, then return to prevent an immediate object state switch.
    public void Ontoo()
    {
        //Debug.Log("執行Ontoo()");
        if (Measure.RulerOn.Equals(true))
        {
            Measure.OnSelect12();
        }
        if (Set_Model.Location.Equals(true))
        {
            Set_Model.ModelLocation();


        }
        if (QRCODEHM.Location.Equals(true))
        {
            QRCODEHM.ModelLocation();
       
        }
    }


}

