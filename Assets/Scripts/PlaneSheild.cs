using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSheild : MonoBehaviour
{

    [SerializeField] GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(shield, 30f);
    }
}
