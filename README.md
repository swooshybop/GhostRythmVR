# VR Ghost Banish: A Rhythm-Driven Sword & Torch VR Game

This is a rhythm-inspired VR mini-game built in Unity using the XR Interaction Toolkit. 
Instead of slicing color-coded blocks like traditional rhythm games, you fend off waves of invading **ghosts** using a **sword** or **torch-blaster** based on their type.

---
## Demo (had some issues with recording, so starts midway)
https://drive.google.com/file/d/15HvxflVZX3wnWemzcmeenQQ72yVETW_k/view?usp=sharing


## Gameplay Overview

You are stationed in a haunted realm. Ghosts approach you in time with a background soundtrack, spawning in randomized waves of 1–2 per row. You must:

- **Slice hat-wearing ghosts** using your **sword** (left hand).
- **Blast plain ghosts** using your **torch** (right hand), which fires light projectiles.

Banishing ghosts correctly earns points. Using the wrong weapon drains your sanity. If you miss too many, the game resets.

---

## Features Implemented

### Core Mechanics
- Sword-based slicing interaction (tagged collider trigger)
- Torch-based light projectile shooting (via `XRController` trigger + Rigidbody projectile)
- Random ghost wave spawning (1–2 per row, 4 ghost variants)
- Auto-despawning logic to prevent stuck waves
- Miss detection + sanity drain system
- Audio-based track movement tied to music BPM

### Feedback & Effects
- Ghosts vanish in a burst of **smoke particles** upon banish
- Randomized **death audio clips** on ghost destruction
- **Trail-rendered glowing projectiles** for torch attack
- Health (sanity) bar and score UI in world-space canvas


---

## Planned Features

Here’s what’s next:

### Gameplay Features
- 🔁 **Combo Multiplier System**: reward streaks with increased score multipliers.
- 🛡️ **Shield Ghosts**: require two hits to destroy, one to break the shell.
- 🐢 **Time-Slow Powerup**: projectile-based pickup to temporarily reduce game speed.
- 🧟 **Boss Row / Final Wave**: large ghost with multi-stage banish mechanic.

### UI / UX Enhancements
- 🧵 **Start & End Menus**: Start button, pause screen, and retry flow.
- 📈 **High Score Tracking**: persistent score saving using PlayerPrefs.
- 🗺️ **Level Progression**: multiple song stages with increasing difficulty.
- ⚔️ **Sword Skin Selector**: visual customization options for weapons.

---

## Built With

- Unity 2021.x (URP)
- XR Interaction Toolkit (tested on Quest 3)
- Audio and VFX sourced from [Freesound.org](https://freesound.org)
