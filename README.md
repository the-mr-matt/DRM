# DRM
*Do you have to build for multiple store fronts each with their own SDKs?*

This repo provides a set of abstract classes that can be overridden for DRM specific features such as achievements, leaderboards, rich presence, and cloud save. This allows you to use these features easily regardless of the storefront/distribution when you have multiple distributions simultaneously.

## Features
 - Access achievements, leaderboards, rich presence and other features regardless of the distribution
 - Easily extendable
	 - Add new stores e.g. Steam, GOG, Discord
	 - Add new features e.g. cloud save
	 - Accounts for some store fronts not offering certain features e.g. cloud save for GOG




## Usage

#### Examples:
```C#
// Example call to trigger achievements.
DRM.Store.GetComponent<DRMAchievements>()?.Unlock("Completed Level");

// Example call to submit leaderboard score.
DRM.Store.GetComponent<DRMLeaderboard>()?.SubmitScore("Level 6 Leaderboard", 10);

// Example call to set rich presence state.
DRM.Store.GetComponent<DRMRichPresence>()?.SetState("steam_display", "In level 6");
```

#### Adding New Stores:
1. A store must derive from `Winglett.DRM.Store` and override the abstract method `CreateInitializer()` and the property `ID`.
2. Create components deriving from `Winglett.DRM.DRMComponent`.
3. Create a constructor and call `RegisterComponent()` for any DRM feature you wish to use with this store.
4. Add a custom define to `StandaloneStoreFront.cs` to set the selected Store in the build.
5. Add the `DRM` script to a gameObject in your scene. Set `EditorStoreFront` to the `ID` of the store you wish to test for. It's important that this `ID` matches the `ID` set in the store script.

```C#
public static class StandaloneStoreFront
{
    public static string GetStandaloneStoreFrontID()
    {
        #if BUILD_DIST_STEAM
	    return "Steam";
	#elseif BUILD_DIST_GOG
	    return "GOG";
	#endif

        return "";
    }
}
```

```C#
// How to make a new store
public class Store_Steam : Store
{
    #region ----PROPERTIES----
    public override string ID => "Steam";
    #endregion

    public Store_Steam()
    {
        RegisterComponent(new SteamAchievements());
    }

    protected override DRMInitialize CreateInitializer() => new SteamInitializer();
}
```

```C#
public class SteamInitializer : DRMInitialize
{
    public override void Connect() => Debug.Log("Connecting to steam");
    public override void OnConnect() => Debug.Log("Successfully connected to steam");
    
    public override void Disconnect() => Debug.Log("Disconnected from steam");

    public override void Update() => Debug.Log("Update Steam callbacks");
}
```

```C#
public class SteamAchievements : DRMAchievements
{
    public override void Unlock() => Debug.Log("Achievement Unlocked");
    public override void Clear() => Debug.Log("Achievement Cleared");
}
```

#### Adding New Components:
1. New components must derive from `Winglett.DRM.DRMComponent`.
2. Add abstract or virtual methods to be overriden by each store.

```C#
public abstract class DRMAchievements : DRMComponent
{
    public abstract void Unlock(string id);
    public abstract void Clear(string id);
}
```

## Super Unity Build
This repo works well with [Super Unity Build](https://github.com/Chaser324/unity-build). It allows you to setup multiple distributions and check for these in code with custom defines.
