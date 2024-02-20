using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public Transform playerTransform;
    public Color minEmissionColor = Color.black;
    public Color maxEmissionColor = Color.white;
    public float minEmissionIntensity = 0f;
    public float maxEmissionIntensity = 1f;
    public float intensityExponent = 2f; // Exponent for intensity calculation
    private float maxDistance;

    private Renderer rendererComponent;
    private Material material;

    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        material = rendererComponent.material;
        maxDistance = Vector3.Distance(playerTransform.position, transform.position);
    }

    void Update()
    {
        if(playerTransform){
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            float intensityRatio = Mathf.Clamp01(1f - (distance / maxDistance));
            float intensity = Mathf.Lerp(minEmissionIntensity, maxEmissionIntensity, Mathf.Pow(intensityRatio, intensityExponent));
            Color emissionColor = Color.Lerp(minEmissionColor, maxEmissionColor, intensityRatio);

            material.SetColor("_EmissionColor", emissionColor * intensity);

            rendererComponent.material = material;
        }
    }
}
