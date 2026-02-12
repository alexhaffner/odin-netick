# Odin NetworkBehaviour Editor

## What this is doing

`OdinNetworkBehaviourEditor` combines two inspectors for any `Netick.Unity.NetworkBehaviour`:

- Netick's built-in network inspector UI (`NetickEditor.NetworkBehaviourEditor`)
- Odin's inspector rendering (`Sirenix.OdinInspector.Editor.OdinEditor`)

It draws Netick's additional network inspector section first, then draws Odin's inspector (instead of Unity's default inspector path).

## Usage

There are two common use cases:

1. You just create NetworkBehaviour(s):
   - You create a subclass from `NetworkBehaviour`.
   - This editor is automatically registered for any `NetworkBehaviour` (`[CustomEditor(typeof(NetworkBehaviour), true)]`), so you get the combined Netick + Odin inspector automatically.

2. You want to create a custom inspector for a `NetworkBehaviour` subclass:
   - Your custom editor should inherit `OdinNetworkBehaviourEditor`.
   - Call `DrawDefaultInspector()` inside `OnInspectorGUI()` to keep the combined Netick + Odin drawing, then add your custom controls.

## Install / setup

1. Make sure you have installed:
   - Netick
   - Odin Inspector
2. Place `OdinNetworkBehaviourEditor.cs` inside an `Editor` folder, for example:
   - `Assets/Editor/NetickOdinEditor/OdinNetworkBehaviourEditor.cs`
3. Let Unity recompile (might need restart in some case)

### Example to create a custom inspector for a `NetworkBehaviour` subclass 

```csharp
using NetickOdinEditor;
using UnityEditor;

[CustomEditor(typeof(MyNetworkBehaviour))]
public class MyNetworkBehaviourEditor : OdinNetworkBehaviourEditor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        // add extra custom controls here
    }
}
```

## Known issues

- Does not work with Odin Visual Designer yet.
