using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    public ComputeShader computeShader;
    public int texturePower = 3;
    private int textureSize = 0;
    private int texturePowerLastFrame;
    public RenderTexture renderTexture;

    // Code from: https://stackoverflow.com/questions/11196700/math-pow-taking-an-integer-value
    public static int TwoPowX(int power) {
        return (1<<power);
    }
    // Start is called before the first frame update
    void Start()
    {   
        // Initialize new render texture
        renderTexture = new RenderTexture (textureSize, textureSize, 24);
        // Allow the texture to be changed by the compute shader
        renderTexture.enableRandomWrite = true;
        // Create the texture itself
        renderTexture.Create ();

        // Tell the shader what thread to work on, what state to output, and what to draw onto
        computeShader.SetTexture (0, "Result", renderTexture);
        // Tell the shader how many threads to use
        computeShader.Dispatch (0, textureSize / 8, textureSize / 8, 1); 

        textureSize = TwoPowX(texturePower);
        texturePowerLastFrame = texturePower;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) 
    {
        if (renderTexture != null)
        {
            renderTexture = new RenderTexture(textureSize, textureSize, 24);
            renderTexture.enableRandomWrite = true;
            renderTexture.filterMode = FilterMode.Point;
            renderTexture.Create();
        }

        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.SetFloat("Resolution", textureSize);
        computeShader.Dispatch(0, textureSize / 8, textureSize / 8, 1);
        Graphics.Blit(renderTexture, dest);
    }

    // Update is called once per frame
    void Update()
    {
        if(texturePowerLastFrame != texturePower) {
            textureSize = TwoPowX(texturePower);
        }
        texturePowerLastFrame = texturePower;
    }
}
