using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugTilt : MonoBehaviour {

    public Text textX;
    public Text textY;
    public Text textZ;

    void Start () {
    }

    void Update () {
        textX.text = Input.acceleration.x + "";
        textY.text = Input.acceleration.y + "";
        textZ.text = Input.acceleration.z + "";
    }
}
