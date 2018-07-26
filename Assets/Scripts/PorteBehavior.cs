using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteBehavior : MonoBehaviour {

    public Vector2 destination_1;
    public Vector2 destination_2;
    public Vector2 destination_3;
    public Vector2 destination_4;
    private double iOnOff;
    public float SensRotation;
    private float startAngle;
    private double modOnOff;
    private double mod2OnOff;
    public Button_Behavior ButtonBehavior;


    // Use this for initialization
    void Start () {        
        startAngle = transform.localRotation.eulerAngles.z * Mathf.PI / 180;
        modOnOff = 0;

    }


    void Update()
    { // GetComponent Marche pas ???

        if (ButtonBehavior != null)
        {
            iOnOff = ButtonBehavior.OnOff();
            modOnOff = iOnOff % 4;
            if (destination_1 == destination_3 && destination_2 == destination_4)
            {
                mod2OnOff = iOnOff % 2;
                transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, startAngle - Mathf.PI / 2 * (SensRotation * (float)mod2OnOff)));
            }
            else
            {
                transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, startAngle - Mathf.PI / 2 * (SensRotation * (float)modOnOff)));

            }
        }
    }
    

    public Vector3 GetNewDestination()
    {
            if (modOnOff == 0) { return destination_1; }
            else if (modOnOff == 1) { return destination_2; }
            else if (modOnOff == 2) { return destination_3; }
            else if (modOnOff == 3) { return destination_4; }
            else { return destination_1; }
        
    }
    

}
