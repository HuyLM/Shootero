using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotater : MonoBehaviour {
    public Vector3 rotateSpeed;

    // Update is called once per frame
    void Update() {
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + rotateSpeed * Time.deltaTime);
    }
}
