using System.Collections;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
#if UNITY_ANDROID
    void Start()
    {
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
        {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
        }
    }
    
    public void GetLocation()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (AndroidJavaObject locationManager =
                       currentActivity.Call<AndroidJavaObject>("getSystemService", "location"))
                {
                    if (locationManager == null)
                    {
                        Debug.Log("Location Manager NUll");
                        return;
                    }

                    using (AndroidJavaObject locationObj =
                           locationManager.Call<AndroidJavaObject>("getLastKnownLocation", "gps"))
                    {
                        if (locationObj == null)
                        {
                            using (AndroidJavaObject networkLocationObj =
                                   locationManager.Call<AndroidJavaObject>("getLastKnownLocation", "network"))
                            {
                                if (networkLocationObj != null) 
                                { 
                                    double latitude = networkLocationObj.Call<double>("getLatitude"); 
                                    double longitude = networkLocationObj.Call<double>("getLongitude"); 
                                    Debug.Log($"Latitude: {latitude}, Longitude: {longitude}"); 
                                }
                                else
                                {
                                    Debug.Log("No Location Found");
                                }
                            }
                        }
                        else
                        {
                            double latitude = locationObj.Call<double>("getLatitude"); 
                            double longitude = locationObj.Call<double>("getLongitude"); 
                            Debug.Log($"Latitude: {latitude}, Longitude: {longitude}");
                        }
                    }
                }
            }
        }
    }

    public void GetLocationService()
    {
        StartCoroutine(IELocationService());
    }

    IEnumerator IELocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services are not enabled"); 
            yield break;
        } 
        Input.location.Start(); 
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1); 
            maxWait--;
        } if (maxWait < 1) 
        { 
            Debug.Log("Timed out"); 
            yield break; 
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location"); 
            yield break;
        }
        else
        {
            Debug.Log($"Location: {Input.location.lastData.latitude}, {Input.location.lastData.longitude}");
        }
    }
#endif
}