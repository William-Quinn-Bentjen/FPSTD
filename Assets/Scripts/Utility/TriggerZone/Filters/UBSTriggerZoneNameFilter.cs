using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UBSTriggerZoneNameFilter : UBSTriggerZoneFilter {
    //names to check 
    public List<string> InteractsWithNames = new List<string>();
    //filter logic
    public override bool Filter(GameObject interactor)
    {
        //check if the interactor's tag is in the list of tags to check
        if (InteractsWithNames.Contains(interactor.tag))
        {
            return true;
        }
        return false;
    }
}
