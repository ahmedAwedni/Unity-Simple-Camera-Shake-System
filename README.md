# Unity Simple Camera Shake System

A lightweight, globally accessible camera shake system for Unity. Designed to add instant "game feel" to impacts, explosions, and damage events without interfering with your existing camera movement logic.

---

## ✨ Features

* **Global Access:** Uses the Singleton pattern. Trigger a shake from literally any script in your game with a single line of code.
* **Non-Destructive Movement:** Modifies the camera's "localPosition" instead of its global coordinates. This means your camera can still follow the player perfectly while shaking.
* **Zero Dependencies:** Pure C# and Unity Math. Doesn't rely on external assets, animations, or Cinemachine.
* **Plug and Play:** Drop it onto your camera and it's ready to go.

---

## 🧠 Design Notes

The system employs the **Singleton Pattern** ("CameraShaker.Instance"). Because a game typically only has one main camera rendering the action, making the shaker a Singleton prevents developers from having to drag and drop camera references into dozens of different scripts (like bullets, enemies, and environmental hazards).

Furthermore, the script calculates displacement using "Random.insideUnitSphere" and applies it to "localPosition". To ensure this works properly, the camera should ideally be a child of a "Camera Holder" or "Player" GameObject that handles all the actual movement and rotation.

---

## 🧩 How To Use

1. **Hierarchy Setup:** * Ensure your Main Camera is a child of an empty GameObject (e.g., "CameraRig" or "Player"). 
   * Apply your movement/look scripts to the parent, **not** the Main Camera.
2. **Attach Script:** Drag and drop the "CameraShaker.cs" script onto your **Main Camera**.
3. **Trigger the Shake:** Open any other script in your game (for example, a bomb exploding) and call this single line of code:

   // Shakes the camera for 0.5 seconds with a strength of 0.2:

   
   CameraShaker.Instance.Shake(0.5f, 0.2f);

---
   
## 🚀 Possible Extensions

* Perlin Noise: Replace Random.insideUnitSphere with Mathf.PerlinNoise for a smoother, more cinematic shake (often used for earthquakes or heavy machinery).
* Trauma System: Instead of fixed durations, implement a "Trauma" float that adds up when taking multiple hits, scaling the magnitude quadratically.
* Rotational Shake: Add localized rotation modifiers alongside the position modifiers to simulate the camera twisting.

---

## 🛠 Unity Version

* Minimum Version: Unity 2020.3
* Recommended: Unity6 LTS or newer.
* Render Pipelines: Compatible with Built-In, URP, and HDRP.

📜 License
MIT
