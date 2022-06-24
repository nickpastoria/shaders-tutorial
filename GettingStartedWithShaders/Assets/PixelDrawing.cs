// Inspired by code from this project https://github.com/SebLague/Slime-Simulation/blob/main/Assets/Scripts/Slime/Simulation.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDrawing : MonoBehaviour
{
    // Set up compute shader scripts and texture
    [Header("Compute Shaders")]
    public ComputeShader generatePixels;
    public RenderTexture drawTexture;

    // Set up texture size
    [Header("Project Settings")]
    public int textureSizeX = 1280;
    public int textureSizeY = 720;
    public FilterMode filterMode = FilterMode.Point;

    //Define struct for pixel data
    private struct Pixel {
        public Vector2 position;
        public Vector3 color;
    }

    ComputeBuffer pixelBuffer;

    // Start is called before the first frame update
    void Start()
    {
        CreateRenderTexture(ref drawTexture, textureSizeX, textureSizeY, filterMode);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Set up compute shader
        generatePixels.SetTexture(0, "Result", drawTexture);
        generatePixels.Dispatch(0, textureSizeX / 8, textureSizeY / 8, 1);
        Graphics.Blit(drawTexture, dest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRenderTexture(ref RenderTexture renderTexture, int textureWidth, int textureHeight, FilterMode filterMode) {
        renderTexture = new RenderTexture(textureWidth, textureHeight, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        renderTexture.filterMode = filterMode;
    }
}
