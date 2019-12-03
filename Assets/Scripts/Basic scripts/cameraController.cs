using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 minCamBounds;
    public Vector3 maxCamBounds;
    private void Awake()
    {
        minCamBounds = new Vector3(100f, 2f, 100f);
        maxCamBounds = new Vector3(-100f, 2f, -100f);       
    }

    public void cameraFollow(Vector3 cameraTarget)
    {
        //float targetPosX = Mathf.Clamp(cameraTarget.x, minCamBounds.x, maxCamBounds.x);
        //float targetPosZ = Mathf.Clamp(cameraTarget.z, minCamBounds.z, maxCamBounds.z);
        float targetPosX = cameraTarget.x;
        float targetPosZ = cameraTarget.z;
        float cameraOffset = 200.0f;

        this.transform.position = new Vector3(targetPosX, cameraOffset, targetPosZ);
    }

}
