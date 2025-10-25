# 🕹️ PlatformerV1

A 2D pixel-style platformer built in **Unity 2021.3.45f1**, featuring smooth movement, ladders, water physics, and collectible power-ups that change how the player moves and interacts with the world.

🎮 **[Play the WebGL build on Itch.io →] https://stevepbunston.itch.io/dylan-vs-the-bruin**  
_(or play locally by opening the project in Unity)_

---

## ✨ Features

- **Responsive Player Controls** – Jump, climb ladders, and swim smoothly between air and underwater environments.  
- **Underwater Physics** – Adjusted gravity, slower movement, and a breath meter that depletes when submerged.  
- **Power-Ups System**  
  - 🥽 *Snorkel* – Grants infinite breath underwater.  
  - 👟 *Shoes* – Boosts jump height.  
  - 🔮 *Potion* – Unlocks laser eyes for ranged attacks.  
- **Dynamic Audio & Effects**  
  - Jump, shoot, and power-up SFX.  
  - Water splash particle effects when entering the surface.  
- **Death & Respawn** – Colliding with hazards or running out of oxygen triggers a death animation and restarts the scene.  
- **WebGL Build** – Playable directly in browser with responsive scaling.

---

## 🧩 Technical Overview

| System | Description |
|---------|-------------|
| **Engine** | Unity 2021.3.45f1 (LTS) |
| **Language** | C# |
| **Target Platform** | WebGL |
| **Input** | Unity Input System |
| **Animation** | Animator Controllers (Base, Snorkel, Shoes, Fully Powered) |
| **Audio** | Centralized AudioSource + OneShot SFX system |
| **Physics** | Rigidbody2D, BoxCollider2D, custom gravity control underwater |

---

## 🧠 Code Highlights

- **Modular Power-Up Handling**
  ```csharp
  public void SetInfiniteBreath(bool value)
  {
      hasSnorkel = value;
      hasInfiniteBreath = value;
      UpdateAnimations();
      audioSource.PlayOneShot(powerupSFX);
  }



