
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.XR.iOS;

 public class PositionTracker : MonoBehaviour
{

    public Transform vrCamera;
    private UnityARSessionNativeInterface m_session;

    void Start()
    {
        Application.targetFrameRate = 60;
        m_session = UnityARSessionNativeInterface.GetARSessionNativeInterface();
        ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
        config.planeDetection = UnityARPlaneDetection.Horizontal;
        config.alignment = UnityARAlignment.UnityARAlignmentGravity;
        config.getPointCloudData = true;
        config.enableLightEstimation = true;
        m_session.RunWithConfig(config);
    }

    void Update()
    {

        if (vrCamera != null ) {
            Matrix4x4 matrix = m_session.GetCameraPose();
            vrCamera.transform.localPosition = UnityARMatrixOps.GetPosition(matrix);
        }
    }
}