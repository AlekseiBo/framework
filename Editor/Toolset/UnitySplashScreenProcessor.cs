#if UNITY_EDITOR && OPTIMIZE_SERVER_ASSETS
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Toolset
{
    public class UnitySplashScreenProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            PlayerSettings.SplashScreen.showUnityLogo = false;
        }
    }
}
#endif