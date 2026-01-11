# MG1
## Devlog
Yuxin Ding, she/her

In my W1 MG1 breakdown, we identified four game objects: Seeds, Player, UI/Text, and Main Camera. This analysis directly shaped my Unity implementation.

**Seed Object:** The Seed's Position attribute becomes the plantPosition variable in PlantSeed(). I added plantPosition.z = _playerTransform.position.z - 0.1f so plants appear in front of the player. The Be planted action uses Instantiate(_plantPrefab, plantPosition, Quaternion.identity).

**Player Object:** My Player.cs script implements the Player's Position attribute as _playerTransform.position and Speed as _speed. The Movement [WASD] action uses Input.GetAxisRaw("Horizontal") and Input.GetAxisRaw("Vertical") in Update(), calling MovePlayer() for position updates. Plant seeds [Space] is handled by PlantSeed().

**UI/Text Object:** My PlantCountUI.cs script on the UIManager GameObject manages two TextMeshPro texts: _remainingText (seeds left) and _plantedText (seeds planted). The UpdateSeeds() method updates these displays.

**Object Interactions:**

*"Player -> seed" from my analysis becomes:* pressing Space calls PlantSeed(), which checks if (_numSeedsLeft > 0), creates a plant, and updates counts with _numSeedsLeft-- and _numSeedsPlanted++.

*"seed -> UI" becomes:* after planting, _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted) updates the UI text.

Overall, I was able to turn my W1 in-class activity into a working game by translating each planned object and interaction into actual Unity code and scene setup.


