//using UnityEngine;
//using System.Collections;
//
//public class CameraController : MonoBehaviour {
//    public Transform[] cameraPositions;
//    Transform fatherCamerasPositions;
//    public string cameraPositionsTag = "";
//    public string playerTag = "Player";
//    public string mainCameraTag = "MainCamera";
//    public int selectInitPosition = 0;
//    public Camera mainCamera;
//    public Transform target;
//    public bool simpleLookat = true;
//    bool CheckCameraCountToInitErr()
//    {
//        return (selectInitPosition > fatherCamerasPositions.childCount) || (selectInitPosition < 0) ? true : false;
//    }
//    // Use this for initialization
//    void Start () {
//        fatherCamerasPositions = GameObject.FindWithTag(cameraPositionsTag).transform;
//        cameraPositions = fatherCamerasPositions.GetComponentsInChildren<Transform>();
//        mainCamera = GameObject.FindWithTag(mainCameraTag).GetComponent<Camera>();
//        target = GameObject.FindWithTag(playerTag).transform;
//        ChangeCamPos(selectInitPosition);
//    }
//	
//	void LateUpdate ()
//    {
//        if (simpleLookat)
//        {
//            mainCamera.transform.LookAt(target);
//        }
//	}
//    public void ChangeCamPos(int idNewPos)
//    {
//        if (CheckCameraCountToInitErr())
//        {
//            print("selectInitPosition out of range check the qty. of the childrens in the gameObject fatherCamerasPositions");
//            if (!Application.isEditor)
//            {
//                Application.Quit();
//            }
//        }
//        else
//        {
//            // all good select a camera position and move the cam to the position.
//            mainCamera.transform.position = cameraPositions[idNewPos].position;
//        }
//    }
//}
