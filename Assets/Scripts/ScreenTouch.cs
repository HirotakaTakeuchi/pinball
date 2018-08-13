using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTouch : MonoBehaviour {

    [SerializeField]
    FripperController leftFripper;
    [SerializeField]
    FripperController rightFripper;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Touch[] myTouches = Input.touches;
        var hw = Screen.width * 0.5f;

        for (int i = 0; i < Input.touchCount; i++)
        {
            //タッチすると行う何かをここに記入
            Touch t = Input.GetTouch(i);
            // タッチしたときかどうか
            if (t.phase == TouchPhase.Began)
            {
                // left
                if (t.position.x >= 0 && t.position.x <= hw)
                {
                    leftFripper.SetAngle(-20f);
                }
                else
                {
                    rightFripper.SetAngle(-20f);
                }
            }

            if(t.phase == TouchPhase.Ended)
            {
                // left
                if (t.position.x >= 0 && t.position.x <= hw)
                {
                    leftFripper.SetAngle(20f);
                }
                else
                {
                    rightFripper.SetAngle(20f);
                }
            }
        }
    }
}
