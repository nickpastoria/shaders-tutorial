using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    public ComputeShader computeShader;

    public int textureSize = 256;
    public RenderTexture renderTexture;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
