
# 🎵 Unity + FMOD Lessons

## General Concept
Learn Game-Audio in FMOD - without having to bother about integrating/ coding those connections in Unity.
With that, aspiring Game-Audio-Designers can work directly in FMOD and learn/ teach the Middleware FMOD working in a readily build game!
See setup in this Video:
*Coming Soon*



## ⚙️ General Handling
- Open Game Build 
-  Open FMOD Session and Start Live Updates
➡️That's it!

*Some additional notes:*
- **Loop handling:** Events with the addition "Loop" in it are actively stopped by Unity - make sure they loop inside of FMOD
- **Reload scenes**: Reload the scene via the Pause Menu (by pressing escape) when you insert a new Sound on an Event which is a loop OR when you add/ remove a spatializer on an event, so FMOD calculates those correctly.
- **Notes on events**: all events, parameters, snapshots and folders in the FMOD Project have short notes on them to explain when they are triggered  
- **Organize as you like**: Events and Snapshots can be renamed, re-colored and moved in the hierachy to match your personal preference – parameters **cannot!!!!**  

---
![John Lemon](https://assetstorev1-prd-cdn.unity3d.com/key-image/9f865e30-5e38-4bee-921f-d29b028cf1b5.jpg)
---

## 📂 Structure
- Find the **Build** for your OS in the corresponding folder *(/Builds/MAC or /WIN)*
- Find the **FMOD-Session** in the corresponding folder *(/FMOD/Platformer_Unity_EN/Platformer_Unity_EN.fspro)*
- FMOD session available in **English and German**  


---
## 🎮Re-Exporting the game with your own sounds
To export/ build the game with your own sounds (without having to connect via Live-Update), you have to take two seperate steps:
- 1) In your FMOD Project with all the sounds you have setup, choose File -> Build (F7). Keep in mind, that Unity will now always refer this state of your project for playing back sound until you connect via Live-Update.
- 2) Open the Unity Project in the correct Editor Version **6000.0.23f1** (if you're doing that for the first time, that might take a while). Keep in mind, that you need to [install the Build Support Modules in the Unity Hub](https://docs.unity3d.com/hub/manual/AddModules.html) for the operating systems for which you want to export to (e.g. Windows Build support if you are on Mac). In the Unity Project, press File -> Build Settings... Then select the Target Platform for your game and press Build!


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
