# running-adventure

## Introduction

This app should become a companion for boring running exercises.
It generates a storyline around your training, providing randomly
generated routes and fictional quests and events on this routes.
Including a complete audio navigation so you can enjoy the run
without having to look at your phone.

## Definitions

- The programming language used is C# (with the Xamarin Framework)
- names and descriptions are written in English
- code style should follow clean code in general

## Project Goals

- General (0)
-- (0.1) running on Android devices
-- (0.2) providing audio navigation for the player, so no look at the phone is necessary during the run
-- (0.3) user-preferences to adjust total distance, difficulty, which events should be used, etc.
-- (0.4) (statistically information about the past runs)
- Random coordinates generation (1)
-- (1.1) creating random geographic coordinates specific distances to a "home"-coordinate
-- (1.2) matching this coordinates to the street grid of the real world (creating optimized coordinates)
- Route Generation (2)
-- (2.1) using a routing machine service to generate a route using the coordinates as waypoints
-- (2.2) (optimizing that route for running/cycling using further information)
-- (2.3) providing an image showing the route for debugging (for example from a website)
- Navigation (3)
-- (3.1) getting detailed GPS position information about the player
-- (3.2) processing this information in relation to time for several movement information (speed, direction, etc.)
-- (3.3) providing navigation for the Route
--- (3.3.1) calculating the players position in relation to the route
--- (3.3.2) navigating to the next way-point
--- (3.3.3) providing navigation instructions at a reasonable time for the player to react to
--- (3.3.4) (reacting to the player variating the route)
---- (3.3.3.1) (the player is getting lost -> leading the player back to the route)
---- (3.3.3.2) (the player is taking a detour -> integrating this into the story)
- Story (4)
-- (4.1) including sound files / sound synthesizer for audio information/instructions
--- (4.1.1) (using a real persons voice for the audio)
-- (4.2) creating a "digital world" using the real street grid
--- (4.2.1) using the random coordinates as POI places with a story in the digital world [ExampleStory1]
--- (4.2.2) creating fictional reasons/quests to visit that places
--- (4.2.3) (providing the possibility to mark a "nice place" to include it in future random routes more often)
-- (4.3) creating items that can be "found" at places
-- (4.4) generating quests for an entire route (and generating choices for (partial) routes)
-- (4.5) (building a base at your home-point?)
- Events (5)
-- (5.0) safety: the player must not react to an event if it may be unsafe due to traffic situations
--- (5.0.1) identifying pausing/stopping at trafic lights and include them into the story
-- (5.1) general
--- (5.1.1) creating events during the run to make the route more interesting and unpredictable
--- (5.1.2) (difficulty of the events can be set in the preferences)
--- (5.1.3) planning the events beforehand and show them in a debug view
--- (5.1.4) the player must have the possibility to skip/ignore events
-- (5.2) possible events
--- (5.2.1) raider/monster attack -> running faster for a short period of time
--- (5.2.2) blocked street -> route is changed to avoid a specific area
--- (5.2.3) detours -> player can run additional detours if he/she feels fit
--- (5.2.4) run home faster -> at the last part of the route, the player has to speed up
--- (5.2.5) special exercise -> running backwards or with smaller/wider steps
- Rewards (6)
-- (6.1) statistical evaluation
-- (6.2) collecting items from POIs, events, etc. (and using them for base-building?)
-- (6.3) (creating a unique story/world related to the street grid and the different runs, favorite POIs, etc.)
- (Sharing (7)) 
-- (7.1) (comparing run results and statistics with other players)
-- (7.2) (define POIs in the players region in a creative-mode and share them, so other players in the same region can use them to have nicer routes)


[ExampleStory1]
(some random coordinate is defined as "the hospital")
N.A.V.I.: "I have found a hospital not far from here. There is quite a lot of medicine left.
We should go there and pick it up. But first, we have to get the key for the doors. 
I have heard that one of the nurses left her key at her home during the big evacuation, so we have to go there first."

[ExampleStory2]
(runner is running down a longer straight street)
(optional before the event, N.A.V.I. tells the player to slow down a bit)
N.A.V.I.: "Hey, I have seen a group of raiders nearby. They spotted me and will be here in a matter of seconds.
We have to get to the big intersection as fast as possible. Run!"

## Story elements
(only ideas, not elaborated)
- (1) the world
-- some post-apocalyptic world
-- maybe because of a deadly disease or a nuclear disaster
-- very few people left, living in small groups or alone, trying to survive
-- the player also tries to survive
-- it is very dangerous outside, so people usually try to hide / construct safe places
- (2) "N.A.V.I." ( = navigation and valuation item ?)
-- a small drone which is the most important NPC. 
-- It acts as intermediate between the player and the digital world. It provides the information that leads to quests and events [ExampleStory2] 
--- picks up the items when the player is at a POI
--- explores the surrounding area (background story) and then provides information for the player
--- warns the player about upcoming events
- (2) raiders
-- ruthless people who group together to survive partially by robbing other people
- (3) people who need assistance
--- people contacting you via radio and asking for specific help (for example courier services)


## Change log

- facade classes for RouteInformation (2.1)
- OnCircleRandomPointGenerator is working (1.1)
- restructured classes
- using the "nearest" service to not have random locations off road (1.2)
- added some first tests to get a random route
- added a few basic classes
- Included the forked Osrm.Client into this project (2.1)


## Contributing

Please contact me if you are interested in contributing to this project.



#### Using a modified(forked) Osrm.Client, originally from narfunikita from https://github.com/narfunikita/Osrm.Client 
#### @narfunikita: thank you!
