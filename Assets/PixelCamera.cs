using UnityEngine;
using UnityEngine.UI;

public class PixelCamera : MonoBehaviour
{
    public enum DepthBits
    {
        Zero = 0,
        Sixteen = 16,
        Twentyfour = 24,
        ThirtyTwo = 32,
    }

    [Header("Components")]
    [SerializeField] private new Camera camera = null;
    [SerializeField] private RawImage rawImage = null;

    [Header("Settings")]
    [SerializeField] private int cameraWidth = 256;
    [SerializeField] private FilterMode filterMode = FilterMode.Point;
    [SerializeField] private DepthBits depthBits = DepthBits.Sixteen;

    private RenderTexture renderTexture = null;

    [Header("Editor")]
    public bool updateTexture = false;


    private void Start()
    {
        updateTexture = true;
    }

    private void Update()
    {
        if (updateTexture)
        {
            updateTexture = false;
            CreateRenderTexture();
        }
    }

    private void CreateRenderTexture()
    {
        if (renderTexture != null)
            renderTexture.Release();

        float aspectRatio = ((float)Screen.height / Screen.width);
        int cameraHeight = Mathf.RoundToInt(cameraWidth * aspectRatio);

        renderTexture = new RenderTexture(cameraWidth, cameraHeight, (int)depthBits, RenderTextureFormat.ARGB32);
        renderTexture.filterMode = filterMode;

        renderTexture.Create();
        camera.targetTexture = renderTexture;
        rawImage.texture = renderTexture;
    }
}
