using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour

{
    public void XRotation(bool positiv) { Rotation(new Vector3(1, 0, 0), positiv);  }
    public void YRotation(bool positiv) { Rotation(new Vector3(0, 1, 0), positiv); }
    public void ZRotation(bool positiv) { Rotation(new Vector3(0, 0, 1), positiv); }

    void Rotation(Vector3 rot, bool positiv)
    {

        if (!positiv) rot *= -1;
        transform.Rotate(rot * 45);

        if (transform.rotation.eulerAngles == new Vector3(0, -90, -90))
        {
            Debug.Log("ReadyForExport");
        }
    }

}
