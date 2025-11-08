

# 🎵 Unity + FMOD Lessons

## Understanding Listener Placement

The listener in Game-Audio terms is the camera for sound, the ears into our game world. For camera placement, we already are used to to referring to terms like "First Person" or "Third Person", yet audio is only perceived as matching or off - without thinking about why.

This Mini-Project uses Unity's "Stealth Game"/ John Lemon Microgame in combination with Unity's Starter Assets for First and Third Person Controller to fluently switch between different Camera Perspectives and combine them with different listener placements.

To give a clearer impression of the listener placement and rotation, you will find a pair of headphones to visualize the current position and rotation of the listener.

Get an impression in this Video: ***Coming soon!***


The actual gameplay (e.g. being spotted by ghosts) still only works with the intended top down perspective.

## ⚙️ General Handling
- Pull/ Download Repository
- Open in Unity Editor OR open the exported Build for your OS
- *Alternatively, get an impression on this [itch build](https://joshntq.itch.io/john-lemon-listeners) **[!!! Glitching in some Browsers, e.g. Edge - more fluent experience in downloaded build !!!]***

*(As in the [John Lemon FMOD Learn Project](https://github.com/Joshnt/JohnLemon_FMOD-Learn) you can still use the included FMOD Session to use your own sounds. As the constant listener change is not fluently working with Live-Update, it is deactivated in both the Application and the Editor.)*


---
![John Lemon](https://assetstorev1-prd-cdn.unity3d.com/key-image/9f865e30-5e38-4bee-921f-d29b028cf1b5.jpg)

## 🎮Controls

-   _Camera Perspective_ - use **Shift + 1/2/3** to switch between **1st Person, Top-Down** and **3rd Person view**
-   _Listener Position -_ use **CTRL (or SPACE) + 1/2** to switch between the listener being placed on the Camera or on the player.
-   _Listener Rotation_ - use **ALT + 1/2** to switch between the listener rotating with the camera or with the player.
-   _Show/ Hide Headphones (Listener Visualisation)_ - **4**
-   _Reload Scene_ - **R**

---

### Soundsources:

This build only includes the following (spatialized) soundsources besides the general ambience. This was done to perceive the single sounds more clearly and not clutter the sound impression - especially when using uncommon/ weird listener placements:
-   Ghosts *(Synth-Vibrato)*
-   Gargoyles *(Stone movement)*
-   Shower *(running water)*
-   Candles *(fire crackling)*
-   Electric Light *(buzzing)*

### Learning/ Take-away:

You will notice, that we normally expect the sound to mimic the perception of the camera angle, meaning normally sticking to the Camera rotation works best. The Placement of the listener on the other hand differs and has less of a universal solution. Especially for Top-Down/ Isometric or 2D Games as well, you will notice, that having the listener on the camera may result in a too quite output, because the listener is too far away from the soundsource.
Still looking for a general rule of thumb?
- *1st Person* - Listener on Camera 
- *3rd Person* - Listener on Camera, Position offset to match Player-Character (or using FMOD's in-built "Attenuation Object" property)
- *Top-Down/ Isometric/ 2D* - Listener on Camera, Position offset to match Player-Character (or using FMOD's in-built "Attenuation Object" property) OR experiment with Positions between Camera and Ground


---
## 📦Other FMOD Learning Projects
- [Platformer (Easy)](https://github.com/Joshnt/Platformer_FMOD-Learn)
- [John Lemon (Easy)](https://github.com/Joshnt/JohnLemon_FMOD-Learn) *(Currently WIN only & Unity Version 6)*
- [Doctor FPS (Intermediate)](https://github.com/Joshnt/DoctorFPS_FMOD-Learn)
- 	The Explorer (Advanced)
	- [Unity and FMOD Project](https://github.com/Joshnt/3DGameKit-Sample_FMOD_Learn)
	- [Builds](https://github.com/Joshnt/3DGameKit_Build_FMOD_Learn)
	- [Screencaptures](https://github.com/Joshnt/3DGameKit_Screencaptures)

*All the Demo-Games use FMOD 2.03.09 and Unity 2022.3.51f1*

*(All those games are originally designed and distributed by Unity Technologies as Learning Ressources and can be found on their website under the [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms).)*
