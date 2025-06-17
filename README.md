# States-and-Save
A State and Save Manager logic 
# Game State Backend System (Unity + C#)

## 🧩 Overview

This Unity-based project implements a modular and extensible game state management system. It includes player interaction, item management, environment object state, state persistence (save/load), reset functionality, and a debug UI panel using TextMeshPro.

---

## 📦 Project Structure

- `GameStateManager.cs` – Central manager that controls and holds the game state.
- `GameState.cs` – Serializable container holding the entire game state.
- `PlayerState` – Player-specific data (position, health, inventory).
- `ItemState` – Tracks item data such as position, ID, and pickup status.
- `EnvironmentObjectState` – Represents stateful environment objects like doors or switches.
- `Item.cs`, `EnvironmentObject.cs`, `Player.cs` – MonoBehaviours that sync real-world GameObjects with state.
- `DebugPanelUI.cs` – UI for inspecting player state using TextMeshPro.

---

## 🧠 a. Game State Representation

The game state is represented by the `GameState` class, which contains:

- `PlayerState`: Position (`Vector2`), health (`int`), and inventory (`List<string>`).
- `List<ItemState>`: Each item has an ID, position, and `pickedUp` boolean.
- `List<EnvironmentObjectState>`: Each object has an ID, position, and active/inactive state.

The structure is highly modular and serializable for saving/loading using JSON.

---

## 🔁 b. State Transition Functions

The following core transitions are implemented in `GameStateManager.cs`:

- `MovePlayer(Vector2 newPos)`: Moves player to a new position (with world bounds check).
- `PickupItem(string itemId)`: Adds an item to the player’s inventory and disables it in the world.
- `UseItem(string itemId)`: Uses the item, applies its effect (e.g., healing), and removes it from inventory.
- `InteractWithEnvironment(string objectId)`: Toggles environment objects like doors based on proximity.
- `ResetGameState()`: Resets the game to its initial configuration and re-enables all interactable items.

---

## ⚠️ c. Edge Case Handling

- **Invalid Moves**: Movement is restricted to within bounds (e.g., no negative Y-axis positions).
- **Invalid Items**: `UseItem` checks if the player owns the item before using it.
- **Nonexistent Environment Objects**: `InteractWithEnvironment` checks object existence.
- **Health Overflow**: Player health is clamped to a max of 100.
- **Missing Save Files**: Basic try/catch structure avoids crashing during load.
- **Item Reset**: All item GameObjects are referenced manually to ensure visibility is restored.

---

## 🧱 d. Extensibility Design Choices

- State classes are cleanly separated, allowing new components (e.g., NPCs, quests) to be added easily.
- State transitions are abstracted into centralized methods (e.g., `MovePlayer`, `UseItem`) promoting easy unit testing and logic control.
- The use of JSON and serializable classes makes save/load extensible with minimal changes.

---

## 📌 e. Assumptions Made

- The player only moves by clicking buttons (no physics or navmesh).
- The world is a 2D space and interactions are based on `Vector2.Distance`.
- All interactable objects and items are uniquely identified via a string `Item_id`.
- GameObjects like items(apple in this case) and doors are manually referenced via the Unity Inspector for visibility controls.

---

## 🎮 f. Use in a Complex Game

This system lays the groundwork for larger games with:

- AI systems modifying the same state (via shared `GameStateManager` interface).
- Multiplayer or local coop via shared synchronized state.
- Dynamic quest, dialogue, or skill trees tied into the environment and inventory systems.

Adding new systems would involve:
- Defining a new state class (e.g., `QuestState`).
- Extending the `GameState` and `GameStateManager`.
- Creating MonoBehaviours to visually sync that new data.

---

## 🧪 g. Setup and Testing Instructions

### ✅ Requirements
- Unity 2021.3 or later
- TextMeshPro package (included by default in new projects)

### 🛠 Setup

1. Clone or download this project into Unity.
2. Open the `Main` scene.
3. Add:
   - A **Player** GameObject with tag `Player`, a sprite, and the `Player.cs` script.
   - One or more **Item** GameObjects (e.g., apple) with `Item.cs`, `itemId`, and initial positions.
   - One or more **Environment** GameObjects (e.g., a door) with `Door.cs`, `objectId`, and initial positions.
4. Assign all items and environment objects in the `GameStateManager` inspector references.
5. Create UI buttons and link them to `GameStateManager` public methods like `MovePlayer()`, `PickupItem()`, `UseItem()`, and `InteractWithEnvironment()`.
6. Add the `DebugPanelUI` prefab to show player health, inventory, and position.

### ▶️ Testing

1. Hit **Play** in the Unity editor.
2. Use buttons to move the player near items or doors.
3. Click pickup/use/interact buttons to trigger state transitions.
4. Click Save and Load buttons to persist game state between sessions.
5. Click Reset to return everything to the initial state.

---

## 💬 Contact

Created by **Rishi Saxena**  
For questions or feedback, please reach out via GitHub or email.

---

