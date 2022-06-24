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

    ComputeBuffer pixelBuffer;

    // Start is called before the first frame update
    void Start()
    {
        CreateRenderTexture(ref drawTexture, textureSizeX, textureSizeY, filterMode);
        ReDrawTexture();
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Set up compute shader
        Graphics.Blit(drawTexture, dest);
    }

    void ReDrawTexture() {
        generatePixels.SetTexture(0, "Result", drawTexture);
        generatePixels.Dispatch(0, textureSizeX / 8, textureSizeY / 8, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            ReDrawTexture();
            int mouseTexturePosX = (int)(((float)Input.mousePosition.x / (float)Screen.width) * textureSizeX);
            int mouseTexturePosY = (int)(((float)Input.mousePosition.y / (float)Screen.height) * textureSizeY);
            generatePixels.SetInt("MouseX", mouseTexturePosX);
            generatePixels.SetInt("MouseY", mouseTexturePosY);
            //Debug.Log("Mouse Clicked at (" + mouseTexturePosX + ", " + mouseTexturePosY + ")");
        }
    }

    void CreateRenderTexture(ref RenderTexture renderTexture, int textureWidth, int textureHeight, FilterMode filterMode) {
        renderTexture = new RenderTexture(textureWidth, textureHeight, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        renderTexture.filterMode = filterMode;
    }
}
