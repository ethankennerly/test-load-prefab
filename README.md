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
        1. "To load an additive scene with a single cube on top of an empty scene took approx 50 ms, while loading an asset bundle with a cube into the same scene took approx 14 ms." The memory optimization struggle in Unity3d by Emiliano Pastorelli on 06/27/17 <https://www.gamasutra.com/blogs/EmilianoPastorelli/20170627/300585/The_memory_optimization_struggle_in_Unity3d.php>
1. To make a balanced decision, how fast is each technique on a complex prefab?
    1. While a complex prefab would be loaded asynchronously, a first pass estimate is made with synchronous, since synchronous calls are simpler to profile.

## Instructions

1. Load scene `TestLoadPrefab.unity`
1. Open profiler.
1. Observe CPU and memory rows.
1. For accurate profiling, build to device with profiling enabled.
1. Play.
1. Record profiler.  Observe frames being measured as baseline.
1. Profile loading.
    1. Click button "Clear cache".
    1. Click button "Additive Scene" or another loading technique.
    1. Stop recording.  Select frame of spike.
    1. Inspect time spent loading.
    1. Inspect garbage allocated.
    1. Record system and results.
    1. Save profile if you want to refer to it later.
    1. Click button "Reload scene" and repeat these sub-steps on the other techniques.

## Results

System specs:
- Intel Core i7-6500U CPU @ 2.5GHz
- RAM 8GB
- Windows 10 Home
- Unity Editor 2017.2

1. Within editor

                    KB Allocated   Milliseconds
    Resource         43             7
    Additive scene  220            38
    Single scene    180            57

## Features

- [x] Empty Unity project in Unity 2017.2.
- [x] Loading time of prefab in additive scene.

## To-do

- [ ] Loading time of prefab in resources.
- [ ] Loading time of prefab in asset bundle.
- [ ] Loading time of prefab in scriptable object.
- [ ] To be more accurate, custom sampler for each.
