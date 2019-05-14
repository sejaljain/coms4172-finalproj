TEAM CARBON
James (JRK2181)
Will (WD2304)
Maddy (MEP2209)
Sejal

SUBMITTED 13 MAY 2019

DEVELOPMENT PLATFORM
Developed on Unity using the Google Cardboard SDK, ARKit.

DEPLOYMENT PLATFORM
Built on iOS 12.2 from Unity-Generated .xcworkspace project

PROJECT TITLE
Greenhouse Carbon Capture

PROJECT DIRECTORY OVERVIEW
Base Scene -> Assets/GoogleVR/Demos/Scenes/HelloVR.unity 
Greenhouse Model -> Assets/0423\ model.fbx
Crate Model -> Assets/Crates00/
Plant Models -> Assets/Cartoon_Farm_Crops/

ASSET SOURCES
Farm crops: FALSE WISP STUDIOS
Crates: ANIMATION ARTS CREATIVE GMBH
Greenhouse: Russel and Sam from Architecture Department
Image targets: Unity ARKit SDK

INSTRUCTIONS
This VR app places the user inside a greenhouse. They may interact with the scene using a printed image target which attaches to a virtual hand. The user may navigate the scene by touching several static hotspots with the image target. The goal of this game is to capture as much carbon as possible by harvesting corn from the tall, vertical planters throughout the room. The virtual hand must make contact with the vegetable, then press the Google Cardboard button to grab it. There are three crates on the floor, navigate to one and release the button to place the corn in the crate. 

UNITY BUGS
Couldn't combine ARKit's positional tracking and Vuforia Image Targets. We found that many of these SDKs implement similar features which do not play nicely together. This was the source of most development difficulty throughout the project

