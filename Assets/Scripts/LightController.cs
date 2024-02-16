using UnityEngine;

public class LightController : MonoBehaviour
{
    public Transform playerTransform;
    public float minIntensity = 10000f;
    public float maxIntensity = 100000f;
    public float intensityExponent = 2f;
    private float maxDistance;

    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        maxDistance = Vector3.Distance(playerTransform.position, transform.position);
    }
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        float intensityRatio = Mathf.Clamp01(1f - (distance / maxDistance));

        float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Pow(intensityRatio, intensityExponent));

        pointLight.intensity = intensity;
    }
}
