# Layover

**A calm 2D travel platformer built for LAYOVER 2026 (TinkerSpace Calicut, Hackathon).**

Layover is a peaceful platformer where a traveler explores a pixel-art world, learns to move and jump, and passes through a portal to the next level. The game has no timers, no enemies, and no fail states.

---

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Controls](#controls)
4. [Tech Stack](#tech-stack)
5. [Project Structure](#project-structure)
6. [Setup and Running](#setup-and-running)
7. [How the Game Works](#how-the-game-works)
8. [Testing](#testing)
9. [Team and Contributions](#team-and-contributions)
10. [Development Process](#development-process)
11. [Known Limitations](#known-limitations)
12. [Future Work](#future-work)
13. [Credits and Assets](#credits-and-assets)

---

## Overview

**Problem and motivation:** Many beginner games are either too complex to finish in a short event or too abstract to explain. Layover aims for a small, polished experience that a beginner team can finish in one night and that matches the event theme, "Build around travel."

**Target players:** Casual players who want a relaxing experience with simple controls.

**Theme:** Travel, exploration, and calm discovery across Kerala and Dubai.

---

## Features

| Feature | Status |
|---|---|
| Character movement (left/right) | Done |
| Jumping with ground detection | Done |
| Sprite-based character with idle, run, and jump frames | Done |
| Camera that follows the player | Done |
| Tutorial text on the first level | Done |
| Portal to the next level | Done |
| Cloud transition between levels | In progress |
| Passport stamps and achievements | Planned |
| Background music and sound effects | Planned |
| Final level and ending | Planned |

---

## Controls

| Action | Keyboard |
|---|---|
| Move left | `A` or `←` |
| Move right | `D` or `→` |
| Jump | `Space` or `↑` |

---

## Tech Stack

- **Engine:** Unity 6.6 (2D template, Universal Render Pipeline)
- **Language:** C#
- **UI text:** TextMesh Pro
- **Art:** Pixel art created with AI image generation (Gemini), cleaned and sliced in Piskel and Unity
- **Version control:** Git and GitHub, via GitHub Desktop

---

## Project Structure
Assets/
├── Scenes/ Level scenes (tuto, 001)
├── Scripts/ PlayerMovement, CameraFollow, Portal, transition scripts
├── sprites/ Character spritesheet and sliced frames
├── backgrounds/ Background and tile images
└── Settings/ Unity project settings


---

## Setup and Running

**Requirements**
- Unity 6.6 (installed through Unity Hub)
- Git or GitHub Desktop (optional, for cloning)

**Steps**
1. Clone the repository with GitHub Desktop, or download it as a ZIP.
2. Open the project folder in Unity Hub.
3. In the **Scenes** folder, open `tuto`.
4. Press **Play**.

**Build order:** `tuto` (index 0) and `001` (index 1) must both be enabled in **File > Build Profiles > Scene List**.

---

## How the Game Works

- **Player (`PlayerMovement.cs`):** Moves with a Rigidbody 2D. Ground is detected with a small check point under the feet on the **Ground** layer. Sprite frames swap to match idle, run, and jump states.
- **Camera (`CameraFollow.cs`):** Follows the player with smoothing, with an optional horizontal offset.
- **Portal (`Portal.cs`):** When the player enters the portal's trigger area, the next scene loads by name.
- **Transition (`transition.cs`):** Handles the scene-change transition (in progress).

---

## Testing

Testing was done manually in the Unity Play mode:

- Movement and jumping on flat ground and platforms
- Ground detection, including checking that jumps are not possible mid-air
- Scene changes through the portal in both directions
- Camera follow and offset behaviour

No automated tests were written.

---

## Team and Contributions

| Member | Role | Main contributions |
|---|---|---|
| [Name 1] | Programming and level design | Movement, jump, camera, portal, scene setup |
| [Name 2] | Art, testing, and design | Sprite cleanup, backgrounds, tutorial text, playtesting |

---

## Development Process

- **Approach:** Built in small steps, testing after each change. Each working version was saved before the next change.
- **Use of AI tools:** AI chat assistants were used to draft C# scripts, debug errors, and generate pixel art. All code was reviewed, tested, and adjusted by the team.
- **Version control:** Commits were made after each working milestone, with short messages describing the change.

---

## Known Limitations

- The cloud transition is incomplete, so scene changes currently cut directly.
- Level 2 (`001`) has no portal or tutorial text yet.
- Some AI-generated sprites needed manual cleanup, and frame alignment may still vary slightly.
- No audio yet.
- The game has been tested only in the Unity Editor, not as a standalone build.

---

## Future Work

- Finish the cloud transition between levels
- Add passport stamps and achievement popups
- Add background music and soft sound effects
- Build a third level and a final ending screen
- Add parallax background layers for depth
- Export a WebGL or standalone build for judging

---

## Credits and Assets

- **Character and background art:** AI-generated with Gemini, then edited by the team
- **Tile graphics:** [Add source if a free asset pack was used]
- **Fonts:** TextMesh Pro (included with Unity)
- **Engine:** Unity

---

*Made with Unity 6.6 for LAYOVER 2026 at TinkerSpace Calicut.*
