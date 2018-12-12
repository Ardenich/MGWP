using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonScript : MonoBehaviour {

    public bool action = false;

    public void ActionTrue()
    {
        action = true;
    }

    public void ActionFalse()
    {
        action = false;
    }
}
