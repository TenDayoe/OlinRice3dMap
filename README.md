# MacNav 

`MacNav` is a mobile navigation app. The app will navigate a user from one room to another in the Olin Rice academic building of Macalester College.

![MAC (3)](https://user-images.githubusercontent.com/98071520/235376764-728d9362-c223-4a68-bcd9-ab7ddcab30af.svg)

Contents
========

* [Product Vision](#product-vision)
* [Installation](#installation)
* [How To Use](#how-to-use)
* [Breakdown Of The Tools Used](#breakdown-of-the-tools-used)
* [Conclusion](#conclusion)

### Product Vision

Our product aims to create a 3D map program that will provide a helpful navigation tool for individuals visiting or studying at Macalester College's Olin Rice building. The program will serve as a valuable resource for new visitors, first-year students, and people studying social science and arts disciplines who are unfamiliar with the building's layout. 

Our goal is to create a user-friendly interface that will enable users to quickly and easily navigate the building, saving them time and minimizing confusion.

### Installation
---

> **Warning**
> Developer mode must be installed on your iPhone to build the app.

> **Warning**
> User must have Unity Editor (Best Support: Version 21.x.x)

> **Warning**
> User must have Xcode and it must be up-to-date

1. Navigate to the bright green `Code` button on this repository in github. Then, hit the `Open with Github Desktop` button.

<img width="394" alt="Screenshot 2023-05-03 at 7 52 29 PM" src="https://user-images.githubusercontent.com/98304697/236085073-a828eef5-fb20-4262-87b2-0b72b6e85d91.png">

2. The user should make sure they can open the repository through Github Desktop. The screen should look similar to the image below.

<img width="953" alt="Screenshot 2023-05-03 at 8 01 57 PM" src="https://user-images.githubusercontent.com/98304697/236085401-d19a1935-e60a-43d0-bf90-48d90e47b96b.png">

3. Now that the repository has been made, the user should now navigate to their Unity Editor. Here they should press the `Open` button in the top left corner. From here, the user will navigate their files to find the repository that we just cloned and open it. The Unity Editor should now have the repository displayed as a project. The screen should look similar to the image below.

<img width="1011" alt="Screenshot 2023-05-03 at 8 19 13 PM" src="https://user-images.githubusercontent.com/98304697/236088844-61a8d8fb-477f-4c57-9fd8-dec37d137a07.png">

4. The user should now open that project and navigate to the top left of the screen and select `File`. While in the `File` dropdown, select the `Build Settings` button.

<img width="246" alt="Screenshot 2023-05-03 at 8 34 15 PM" src="https://user-images.githubusercontent.com/98304697/236090723-a9a6f8fd-0e99-4e1e-bb90-7616321f4215.png">

5. Now that the build menu is up, please match the settings on the menu to the image below. When ready, hit build and store the files in a location on your computer that you will remember (We suggest that you create a new folder on your desktop to place the files into).

<img width="632" alt="Screenshot 2023-05-03 at 8 38 22 PM" src="https://user-images.githubusercontent.com/98304697/236090866-25b572b7-5bc8-4050-bb8f-d591aedd0403.png">

6. The user should now open Xcode and click the `Open` button near the bottom. Here you will open the folder storing the files that we built in the previous step.

<img width="794" alt="Screenshot 2023-05-03 at 9 27 21 PM" src="https://user-images.githubusercontent.com/98304697/236098608-a15d9dac-f915-450a-9187-003a652a0ac4.png">

7. The user should now connect their iPhone to their computer and make sure they see something similar to the picture below.

<img width="227" alt="Screenshot 2023-05-03 at 9 47 48 PM" src="https://user-images.githubusercontent.com/98304697/236100435-aa105249-7dc8-4d74-b825-7e8907909f5a.png">

8. Xcode should now load up and the user should look towards the left side of the editor and click the top of the hierarchy as shown below.

<img width="267" alt="Screenshot 2023-05-03 at 9 28 31 PM" src="https://user-images.githubusercontent.com/98304697/236098735-3ea8891b-d329-4880-8dfa-193d2dd45579.png">

9. Towards the middle of the screen there should be a `Signing & Capabilities` button that the user should click. 

<img width="267" alt="Screenshot 2023-05-03 at 9 28 31 PM" src="https://user-images.githubusercontent.com/98304697/236098816-a9bff871-5722-458e-b2ae-c0f2f7b695ff.png">

10. The user should then click the `Automatically manage signing` button so they can fill out the next two steps. Fill the `Team` drop down with the developer ID that should be on the users iPhone with developer mode enabled. Then, simply change the `Bundle Identifier` section to com.DefaultCompany."uniqueStringHere". It should look similar to the image below.

<img width="668" alt="Screenshot 2023-05-03 at 9 29 33 PM" src="https://user-images.githubusercontent.com/98304697/236099917-5f8b6913-09cb-4e76-9e5a-84e463a43142.png">

11. Now the user can hit the play button near the top right of Xcode.

12. Once the app has built, notifications should appear saying that there is an untrusted developer. They will look like the images below.

![IMG_8272](https://user-images.githubusercontent.com/98304697/236101292-ef29aa50-4ccb-4cd2-aa0f-1d1efdb38dd1.jpg)

<img width="250" alt="Screenshot 2023-05-03 at 9 45 52 PM" src="https://user-images.githubusercontent.com/98304697/236101315-c19b0f35-cb19-4b0a-a3d7-f2be183402aa.png">

13. Simply navigate to `VPN & Device Management` in the settings of your iPhone and look for the `DEVELOPER APP` section at the bottom. Click this and hit trust.

![IMG_8273](https://user-images.githubusercontent.com/98304697/236101894-a5ed05be-e288-4e28-b89d-6c6ab92e8565.jpg)

14. Finally, the user can now look for the app with this image and tap on it to run the app.

![image](https://user-images.githubusercontent.com/98304697/236102068-d9691b32-d7e5-409d-8ec2-262a6be0b51b.png)


### How To Use
---

Once the app has been built onto the iPhone, the user just needs to open it and follow along with the tutorial.

### Breakdown Of The Tools Used
---
Tools :

1.Unity Pro Builder
All the low poly walls were created using Unity's probuilder tool. First a basic prototype was created using Unity's 3d tile mapper and then probuilder was used to create a final low triangle mesh. 

2.Navmesh AI
For an optimized path finding, we used the node based navmesh AI tool to navigate between different rooms. The door of each room was used to represent the room entity and each door has a pointer object in front of the it which is used as the reference point. 

3.URP 
For more realistic graphics, we used Unity's Universal rendering pipeline along with the unity's post processing tools such as Bloom and Depth of Field. 

4.Lighting and Texturing
To reduce runtime system load, we baked all of the lightings such area light, emissive materials to the static materials i.e walls, floors, furniture etc. This reduced the GPU comsumption of the 3d application heavily. Moreover, to reduce production time, we used a simple ceiling material with an emissive property that could replicate the entire ceiling just by repeating the UV itself. 

5.Ambient Occlusion : 

The project also has the option to use Ambient occlusion if the mobile device cannot handle the GPU requirements. But through our tests, the application was consuming only about 30% of the GPU on the latest iphones. Therefore, by default we have turned off this feature. 

6. PlayerPrefs : 

Most of the data that is shared between different scenes is stored and shared using Unity's Player Prefs. 
Code Structure : 

There are a few central classes/scripts that control the core functionality of the application : 

1. PlayerController: 
- This script controls and sets up the navmesh for navigation between user's current location and user's destination location. This script also controls the users animations, in-navigation audio effects. Chaning the state of the script that manages the elevator. 

2. SoundManager:
- This script controls the audio effects and the music in the application. A singleton pattern was used here to make sure that the music continues to play during scene transitions. 

3.Elevator:
-This script controls the state of the elevator and also changes the elevation of the elavator by communicating the PlayerController class. 





### Conclusion
---
Overall, our project is aimed at creating a helpful navigation tool for individuals studying or visiting the Olin Rice building of Macalester College. We are dedicated to continuing development to address any missing features and to ensure that our product remains accessible to new users and developers alike.
