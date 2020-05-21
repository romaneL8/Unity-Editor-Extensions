using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ScreenshotHandeler))]
public class Screenshot : Editor
{
    string fileName = "FileName";
    int selectedAction = 0;
    //int capturedFrame = 0;
    private Camera myCamera;

    //[MenuItem("Screenshot/Screenshot")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(Screenshot));
    }

    public override void OnInspectorGUI()
    {
        fileName = EditorGUILayout.TextField("File Name:", fileName);
        GUILayout.Label("Screenshot Settings", EditorStyles.boldLabel);
        myCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        float width = 200;
        float height = 30;
        string[] actionLabels = new string[] { "Take", "Delete", "Edit" };
        selectedAction = GUILayout.SelectionGrid(selectedAction, actionLabels, 3, GUILayout.Width(width), GUILayout.Height(height));
        float heightCam = 16;
        float weightCam = 16;
        myCamera.pixelRect = new Rect(10, 0, weightCam, heightCam);
        Handles.SetCamera(myCamera);
        Handles.DrawCamera(myCamera.pixelRect, myCamera, DrawCameraMode.Normal);
        //Handles.DrawCamera(new Rect(0, 0, position.width, position.height), myCamera);
        Handles.BeginGUI();
        //myCamera.hideFlags = HideFlags.HideAndDontSave;
        //var previewScene = EditorSceneManager.NewPreviewScene();
        //myCamera.scene = previewScene;
        //myCamera.enabled = false;
        if (selectedAction == 0)
        {
            ScreenshotHandeler.TakeScreenshot_Static(500, 500);
            //ScreenCapture.CaptureScreenshot(fileName + " " + capturedFrame + ".png");
        }
    }

    //void OnScene(SceneView sceneview)
    //{
    //    Event e = Event.current;
    //    if (e.type == EventType.MouseUp)
    //    {
    //        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y));
    //        if (selectedAction == 1)
    //        {
    //            //TakeScreenshot_Static(500, 500);
    //            // TODO: Create OpenSpot
    //            Debug.Log("Create OpenSpot");
    //        }
    //        else if (selectedAction == 2)
    //        {
    //            // TODO: Delete OpenSpot
    //            Debug.Log("Delete OpenSpot");
    //        }
    //    }
    //}

    //void OnEnable()
    //{
    //    SceneView.duringSceneGui -= OnScene;
    //    SceneView.duringSceneGui += OnScene;
    //}

    //private void Update()
    //{
    //    if (EditorApplication.isPlaying && !EditorApplication.isPaused)
    //    {
    //        if (selectedAction == 2)
    //        {
    //            ScreenCapture.CaptureScreenshot(fileName + " " + capturedFrame + ".png");
    //            Repaint();
    //        }
    //    }
    //}
}
