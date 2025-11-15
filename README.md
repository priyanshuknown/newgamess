# Unity Tekken-Style Fighting Game

This project is a simple, Tekken-style 3D fighting game. It includes scripts for player control, enemy AI, combat, health bars, and a round-based game manager.

## Project Structure

```
Assets/
├── Animations/
├── Prefabs/
├── Scenes/
├── Scripts/
│   ├── CameraController.cs
│   ├── Character.cs
│   ├── EnemyAI.cs
│   ├── GameManager.cs
│   ├── HealthBar.cs
│   ├── Hitbox.cs
│   └── PlayerController.cs
└── UI/
```

## Setup Guide

### 1. Scene Setup

1.  **Create a new 3D Scene** and save it in the `Scenes` folder.
2.  **Create a 3D Arena:**
    *   Create a `Cylinder` (GameObject > 3D Object > Cylinder).
    *   Scale it to form a large, flat platform (e.g., X: 20, Y: 0.1, Z: 20).
    *   Create a material and apply it to the cylinder to give it some color.
3.  **Add a NavMesh:**
    *   Open the `Navigation` window (Window > AI > Navigation).
    *   Select the arena platform, go to the `Object` tab in the Navigation window, and check `Navigation Static`.
    *   Go to the `Bake` tab and click `Bake` to generate the NavMesh. This is necessary for the Enemy AI to move.

### 2. Character Prefabs

1.  **Import a 3D Character Model:** Find a humanoid model from the Unity Asset Store or any other source.
2.  **Create the Player Prefab:**
    *   Drag the model into the scene.
    *   Attach a `CharacterController` component. This will be used for physics-based movement.
    *   Attach the `PlayerController.cs` script.
    *   **Create and Assign Hitboxes:**
        *   Create two empty GameObjects with `BoxCollider` components (set to `Is Trigger`). Name them `PunchHitbox` and `KickHitbox`.
        *   Parent them to the character's hand and foot bones.
        *   Attach the `Hitbox.cs` script to both and set their damage values. The script will automatically detect its owner.
        *   **Important:** Disable the `PunchHitbox` and `KickHitbox` GameObjects by default.
        *   Drag the `PunchHitbox` and `KickHitbox` from the hierarchy into the corresponding fields on the `PlayerController` component.
    *   Save the configured character as a prefab in the `Prefabs` folder.
3.  **Create the Enemy Prefab:**
    *   Duplicate the Player prefab.
    *   Remove the `PlayerController.cs` script.
    *   Attach the `EnemyAI.cs` script and a `NavMeshAgent` component.
    *   **Assign Hitboxes:** Drag the `PunchHitbox` and `KickHitbox` GameObjects into the corresponding fields on the `EnemyAI` component.
    *   Save this as a new prefab in the `Prefabs` folder.

### 3. Animator Setup

1.  **Create an Animator Controller** in the `Animations` folder.
2.  **Create Animation States:**
    *   Open the Animator window (Window > Animation > Animator).
    *   Drag your character's animations (idle, walk, punch, etc.) into the Animator window to create states.
3.  **Create Parameters:**
    *   `Speed` (Float)
    *   `Punch` (Trigger)
    *   `Kick` (Trigger)
    *   `Block` (Bool)
    *   `TakeHit` (Trigger)
    *   `IsDead` (Bool)
4.  **Create Transitions:**
    *   Set up transitions between states based on the parameters (e.g., from Idle to Punch when the `Punch` trigger is set).

### 4. UI Setup

1.  **Create a Canvas:** (GameObject > UI > Canvas).
2.  **Create Health Bars:**
    *   Add two `Slider` UI elements to the Canvas for the health bars (GameObject > UI > Slider).
    *   Attach the `HealthBar.cs` script to each slider.
    *   Assign the `Player` and `Enemy` characters (once they are in the scene) to the `targetCharacter` field in the Inspector for each health bar.
3.  **Create a Message Text:**
    *   Add a `Text` UI element to the Canvas for messages ("Fight!", "You Win!", etc.).
4.  **Create a Restart Button:**
    *   Add a `Button` UI element to the Canvas (GameObject > UI > Button).
    *   In the Inspector for the Button, find the `On Click ()` event panel.
    *   Click the `+` icon to add a new event.
    *   Drag the `GameManager` object from the scene Hierarchy into the object field.
    *   From the function dropdown, select `GameManager` > `RestartGame()`.

### 5. Game Management

1.  **Create a GameManager Object:** Create an empty GameObject in the scene called "GameManager".
2.  **Attach GameManager Script:** Attach the `GameManager.cs` script to it.
3.  **Assign References:**
    *   Drag the `Player` and `Enemy` objects from your scene into the respective fields.
    *   Drag the `messageText` and `restartButton` UI elements into their respective fields.

### 6. Camera Setup

1.  **Position the Main Camera:** Position the camera to have a side-on view of the arena.
2.  **Attach CameraController Script:** Attach the `CameraController.cs` script to the Main Camera.
3.  **Assign Targets:** Assign the `Player` and `Enemy` transforms to the `player1` and `player2` fields in the Inspector.

Now, you should be able to press Play and have a basic but functional fighting game!
