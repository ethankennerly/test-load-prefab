# Test load prefab

TODO: Compare Unity loading time of prefab in:

- resources
- asset bundle
- scriptable object
- additive scene

## Use case

1. Unity loads a prefab into memory if it is referenced, before instantiated.
1. Oftentimes a game wants a prefab that would take too much memory to keep around.
1. It is unpredictable until runtime which prefabs are needed.
1. There is exactly one instance of the prefab needed.
    1. If multiple instances are needed, then Ian Dundore mentioned the scene technique will be slower.
    - "Unite '17 Seoul - ScriptableObjects What they are and why to use them" <https://www.youtube.com/watch?v=VtuSKmfrFDU>
1. There are a variety of techniques that have tradeoffs for how easy the assets are to edit.
    1. For example, Unity does not support nested prefabs, so editing a prefab in a additive scene imitates one layer of a nested prefab.
    1. However loading a scene invokes more operations than loading a prefab, so an additive scene is going to be slower.
1. To make a balanced decision, how fast is each technique on a complex prefab?

## Features

- [x] Empty Unity project in Unity 2017.2.

## To-do

- [ ] Loading time of prefab in additive scene.
- [ ] Loading time of prefab in resources.
- [ ] Loading time of prefab in asset bundle.
- [ ] Loading time of prefab in scriptable object.
