using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PosterizationFeature : ScriptableRendererFeature
{
    class CustomRenderPass : ScriptableRenderPass
    {
        public Material material;

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("Posterization");

            var cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;

            cmd.Blit(cameraColorTargetHandle.rt, cameraColorTargetHandle.rt, material);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    public Material material;
    CustomRenderPass pass;

    public override void Create()
    {
        pass = new CustomRenderPass();
        pass.material = material;
        pass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(pass);
    }
}
