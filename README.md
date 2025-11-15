# Unity GTA-Lite Demo

This project is a simple, GTA-like demo created in Unity. It includes scripts for a third-person player controller, a car controller, and a camera follow system.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

*   [Unity Hub](https://unity3d.com/get-unity/download)
*   A version of the Unity Editor (2019.4 or higher recommended)

### Setup

1.  **Create a new Unity Project:**
    *   Open Unity Hub and create a new 3D project.

2.  **Import Free Assets:**
    *   Open the Unity Asset Store (Window > Asset Store).
    *   Search for and import the following free assets:
        *   "Free City Pack"
        *   "Third Person Controller" (we will only use the model from this)

3.  **Set up the Player:**
    *   Drag the player model from the "Third Person Controller" asset into your scene.
    *   Attach the `PlayerController.cs` script to the player model.
    *   Create an empty GameObject called "GroundCheck" and position it at the player's feet. Assign it to the `groundCheck` field in the `PlayerController` component.
    *   Set the `groundMask` to the "Ground" layer (you may need to create this layer and assign it to your ground objects).

4.  **Set up a Car:**
    *   Find a car model in the "Free City Pack" and add it to your scene.
    *   Attach the `CarController.cs` script to the car model.
    *   Add `WheelCollider` components to each of the four wheels of the car model.
    *   Assign the `WheelCollider` components to the corresponding fields in the `CarController` component.

5.  **Set up the Camera:**
    *   Attach the `CameraController.cs` script to the main camera in your scene.
    *   Drag the player model into the `target` field of the `CameraController` component in the Inspector.

Now you should be able to play the scene and control the player and the car.
