# 🌌 Procedural Space Survival

![Version](https://img.shields.io/badge/version-1.0.0--alpha-blue)
![Unity](https://img.shields.io/badge/Unity-2022.3+-black?logo=unity)
![License](https://img.shields.io/badge/license-MIT-green)

**Procedural Space Survival** is a production-grade 3D open-world survival game built in Unity. Explore infinite procedural planets, mine rare resources, fight intelligent AI enemies, and build your base across the galaxy.

---

## 🚀 Key Features

- **Infinite Procedural Planets**: Cube-sphere based generation with multi-layered fractal noise and dynamic LOD.
- **Atmospheric Flight**: Seamless transition from planetary ground to outer space with 6-DOF flight controls.
- **Advanced Survival Mechanics**: Manage Health, Oxygen, Energy, and Radiation in hostile biomes.
- **Modular Crafting & Building**: Grid-based base building and deep item crafting system.
- **Intelligent AI**: Behavior-tree driven enemies including drones and alien predators.
- **Holographic UI**: AAA-style futuristic HUD and inventory interface.

## 🎮 Controls

| Action | Key |
| --- | --- |
| **Move / Fly** | `W` `A` `S` `D` |
| **Jump / Ascend** | `Space` |
| **Crouch / Descend** | `Left Ctrl` |
| **Interact** | `E` |
| **Inventory** | `Tab` |
| **Mining Laser** | `Left Mouse` |
| **Sprint / Boost** | `Left Shift` |

## 🛠️ Tech Stack

- **Engine**: Unity 2022.3+ (URP)
- **Language**: C#
- **Rendering**: Universal Render Pipeline (URP)
- **Generation**: Layered Perlin/Fractal Noise
- **Optimization**: Object Pooling, Job System (Mesh Generation)

## 📦 Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/procedural-space-survival.git
   ```
2. **Open in Unity**:
   - Launch Unity Hub.
   - Click **Add** and select the project folder.
   - Ensure you are using **Unity 2022.3 LTS** or newer.
3. **Setup URP**:
   - Ensure the URP Asset is assigned in `Project Settings > Graphics`.

## 📂 Project Structure

```text
Assets/
├── Scripts/
│   ├── Core/          # Game management and events
│   ├── Procedural/    # Planet generation logic
│   ├── Player/        # Character controls & survival
│   ├── Ship/          # Flight mechanics
│   ├── Inventory/     # Item & crafting systems
│   ├── AI/            # Enemy behaviors
│   └── UI/            # HUD and menus
├── Prefabs/           # Modular game objects
├── Materials/         # Shaders and textures
└── Worlds/            # Procedural data storage
```

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🤝 Credits

Developed by **Antigravity AI** as a AAA-standard modular project.
