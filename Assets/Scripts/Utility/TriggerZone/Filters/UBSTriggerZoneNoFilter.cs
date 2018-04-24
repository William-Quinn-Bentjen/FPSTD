using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UBSTriggerZoneNoFilter : UBSTriggerZoneFilter {
    //will allow anything to be added to the interactor list
    public override bool Filter(GameObject interactor)
    {
        return true;
    }
}
