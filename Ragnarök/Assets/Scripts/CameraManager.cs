using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera _currentCam;

    public CinemachineVirtualCamera CurrentCam { get { return _currentCam; } set { _currentCam = value; } }
}
