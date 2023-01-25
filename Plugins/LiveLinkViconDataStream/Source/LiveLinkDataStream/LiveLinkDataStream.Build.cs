using UnrealBuildTool;
using System;
using System.IO;
using System.Text;
public class LiveLinkDataStream : ModuleRules
{

  private string ThirdPartyPath
  {
    get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../Thirdparty")); }
  }

  public LiveLinkDataStream(ReadOnlyTargetRules Target) : base(Target)
  {
    PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
    PrecompileForTargets = PrecompileTargetsType.Any;
    PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine" });
    PrivateDependencyModuleNames.AddRange(
    new string[]
    {
      "Core",
      "CinematicCamera",
      "CameraCalibrationCore",
      "SlateCore",
      "Slate",
      "InputCore",
      "Projects",
      "LiveLink",
      "LiveLinkInterface",
      "LiveLinkComponents",
      "LiveLinkCamera",
      "LiveLinkLens",
      "TimeManagement",
      "Networking",
      "Sockets"
    }
  );

    PublicIncludePaths.AddRange(new string[] { ThirdPartyPath + "/Vicon/DataStreamSDK" });
    PublicAdditionalLibraries.Add(ThirdPartyPath + "/Vicon/DataStreamSDK/ViconDataStreamSDK_CPP.lib");

    if (Target.Platform == UnrealTargetPlatform.Win64)
    {
      foreach (string FilePath in Directory.EnumerateFiles(Path.Combine(ModuleDirectory, "../../Binaries/Win64/"), "*.dll", SearchOption.AllDirectories))
      {
        RuntimeDependencies.Add("$(TargetOutputDir)/" + Path.GetFileName(FilePath), FilePath);
      }
    }
  }
}
