INTERACTABLES - MECHANICS

Buttons - activate Obstacle(s)
>Can toggle upon first contact
>Can toggle upon multiple contact
>Can toggle upon continuous contact
>Can affect multiple obstacles independently

Obstacles - recieves update from button(s)
>Can prevent player, soul, or both from entry
>Can require different buttons with different states (e.g. AND/XOR gate etc)
>Can be time-gated
>Can apppear or disappear, or move locations

SOLUTION - OBSERVER DESIGN PATTERN
Button = subject object
>has list of affected obstacles
>when triggered, updates the obstacles


Obstacles = observer objects
>Gets updated, calls its own unique update function
>Said function controls the obstacle's actions
