using Unity.Android.Gradle;
using UnityEngine;

public class DissolveDriver : MonoBehaviour
{
    public Renderer targetRenderer;
    public string propertyName = "_Disolve_Amount";

    private int propertyId;

    public float duration = 1.5f;
    public bool pingPong = true;

    private float elpased = 0;

    private MaterialPropertyBlock block;

    private void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
        block = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        elpased += Time.deltaTime;

        float amount = pingPong ? Mathf.PingPong(elpased / duration, 1f) : Mathf.Clamp01(elpased/duration);

        //targetRenderer.material.SetFloat(propertyId, amount);

        targetRenderer.GetPropertyBlock(block);
        block.SetFloat(propertyId, amount);
        targetRenderer.SetPropertyBlock(block);
    }
}


