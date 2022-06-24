using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    // public ComputeShader startingShader;
    // public int texturePower = 3;
    // private int textureSize = 0;
    // private int texturePowerLastFrame;
    // public RenderTexture renderTexture;

    // private struct Pixel {
    //     public Vector3 position;
    //     public Vector3 color;
    //     public uint energy;
    // }

    // // Code from: https://stackoverflow.com/questions/11196700/math-pow-taking-an-integer-value
    // public static int TwoPowX(int power) {
    //     return (1<<power);
    // }

    // private void generatePixels(ref Pixel[] pixels) {
    //     Pixel temp;
    //     temp.position = new Vector3(0, 0, 0);
    //     temp.color = new Vector3(0, 0, 0);
    //     temp.energy = 10;
    //     pixels = new Pixel[] { temp };
    // }     

    // // Start is called before the first frame update
    // void Start()
    // {   
    //     int vector3Size = sizeof(float) * 3;
    //     int uintSize = sizeof(uint);
    //     int totalSize = vector3Size * 2 + uintSize;
    //     Pixel[] _pixels;
    //     // Initialize new render texture
    //     textureSize = TwoPowX(texturePower);
    //     renderTexture = new RenderTexture (textureSize, textureSize, 24);
    //     // Allow the texture to be changed by the compute shader
    //     renderTexture.enableRandomWrite = true;
    //     // Create the texture itself
    //     renderTexture.Create ();

    //     //Create Buffer Array to send to compute shader
    //     //generatePixels(ref _pixels);
    //     //ComputeBuffer pixelBuffer = new ComputeBuffer(_pixels.Length, totalSize);
    //     //pixelBuffer.SetData(_pixels);
    //     startingShader.SetBuffer(0, "Pixels", pixelBuffer);

    //     // Tell the shader what thread to work on, what state to output, and what to draw onto
    //     startingShader.SetTexture (0, "Result", renderTexture);
    //     // Tell the shader how many threads to use
    //     startingShader.Dispatch (0, textureSize / 8, textureSize / 8, 1); 
    // }

    // void OnRenderImage(RenderTexture src, RenderTexture dest) 
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    // }
}
