using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D efector;
    [SerializeField] float startWaitTime;
    [SerializeField] float waitedTime;

    // Start is called before the first frame update
    void Start()
    {
        efector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp ("s")){
            waitedTime = startWaitTime;
        }

        if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey("s")){
            if (waitedTime <= 0){
                efector.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }else{
                waitedTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space")){
            efector.rotationalOffset = 0;
        }
    }
}
