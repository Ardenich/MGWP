using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject[] healthIndex = new GameObject[4];

    void Update()
    {
        if (Character.health < healthIndex.Length)
        {
            healthIndex[Character.health].gameObject.SetActive(false);
        }
    }
}
