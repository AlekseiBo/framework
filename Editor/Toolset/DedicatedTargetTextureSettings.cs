#if UNITY_EDITOR && OPTIMIZE_SERVER_ASSETS
using UnityEditor;

namespace Toolset
{
    public class DedicatedTargetTextureSettings : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            var settings = textureImporter.GetPlatformTextureSettings("Server");
            settings.overridden = true;
            settings.maxTextureSize = 32;
            textureImporter.SetPlatformTextureSettings(settings);
        }
    }
}
#endif