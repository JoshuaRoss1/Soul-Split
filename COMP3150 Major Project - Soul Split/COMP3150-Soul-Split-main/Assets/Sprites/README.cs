// EXPLANATIONS FOR ANIMATIONS (For Mark's looping)


// So what the HELL does each animation do???

// AirBuffer is for the buffer near apex of jump to downturn.
// Airtime is to loop while protag is in the air.
// Death is death. Duh.
// Fall is the transition animation from AirBuffer into falling, or if you fall off a platform.
// Falling is the actual looping falling while sprite is in air.
// Idle is idle animation. Duh.
// Jump is the transition animation from Idle to AirTime.
// Run is the running loop.
// RunningJump is the transition from Run to AirTime.
// RunTran is the transition from Idle to Run.
// (PS: PC is Player Character and Soul is Soul)
// (PPS: Inert Soul is the one with no animations bc it doesn't follow player)

// Ok so wtf are transitions?

// Transitions are there to ease the animation from one state into another.
// This is obvious.
// BUT they are also there to ease the animation OUT of one state into another.
// For example, the typical flow of animating Idle into Run would look like this:
// Idle -> RunTran -> Run
// BUT RunTran must be used again after this animation to ease the player back into idle.
// You need to find a way to reverse this animation for this easing.
// Maybe set animation speed to -1?
// So the full loop would look like this:
// Idle -> RunTran -> Run -> RunTran(Reversed) -> Idle
// LMK if you can't do this and I'll directly recompile a reversed spritesheet for you.

// Transition Loop List

// Full Run Loop:
// Idle -> RunTran -> Run -> RunTran(Reverse) -> Idle

// Full Jump Loop (From Idle):
// Idle -> Jump -> Airtime -> AirBuffer -> Fall -> Falling -> Fall(Reversed) -> Idle

// Full Jump Loop (From Run):
// Run -> RunningJump -> Airtime -> AirBuffer -> Fall -> Fall -> Falling -> Fall(Reversed) -> Idle

// Full Fall Loop (From Idle OR Run bc its not as distinct as a jump)
// Idle / Run -> Fall -> Falling -> Fall (Reversed) -> Idle

// You also gotta figure out how to reverse the spritesheet for leftward animations
// though I don't need to tell you that.
// Again, if you can't do that LMK bc it's very simple for me to reverse the spritesheet
// but I'd like to avoid asset bloat.

// Also you can change the sprite resolution settings by clicking on the sprite.
// Important settings are Max Size, Resize Algorithm and Compression bc those will probably
// be the biggest performance hits. (Max Size ESPECIALLY)

// OK good luck!
