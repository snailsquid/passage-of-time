using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  [SerializedDictionary("Id", "Camera")]
  public SerializedDictionary<string, Camera> Cameras;
  public void ChangeCamera(string id)
  {
    Camera selectedCamera = null;
    foreach (KeyValuePair<string, Camera> pair in Cameras)
    {
      if (pair.Key == id)
        selectedCamera = pair.Value;
      else
        pair.Value.enabled = false;
    }
    if (selectedCamera != null)
    {
      selectedCamera.enabled = true;
    }
    else
    {
      Debug.LogWarning("Camera has not been registered");
    }
  }

  #region Singleton
  public static CameraManager instance;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(this);
    }
  }
  #endregion
}
