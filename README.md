# ControlesCustomsXamarinForms

# Visual rendering

UWP
![UWP](https://user-images.githubusercontent.com/20682036/55613449-03f57780-578b-11e9-9017-d90e5e18ca77.gif)

Android
![Android](https://user-images.githubusercontent.com/20682036/55613444-01931d80-578b-11e9-8223-119e33a6ba6d.gif)

iOS
![ios](https://user-images.githubusercontent.com/20682036/55613454-0657d180-578b-11e9-8c2e-4d86624d7188.gif)


Configuration UWP for add Image with Xamarin Form 3.6

![config3 6](https://user-images.githubusercontent.com/20682036/54189719-ad11c080-44b2-11e9-85fc-5a757d21e8a8.jpg)

There is a bug for adding image in Xamarin Forms to get around it you have to get the nuget win2DUP and add 
`<DisableWin2DPlatformCheck>true</DisableWin2DPlatformCheck>`
 in your csproj UWP

Configuration Android

Add in MainActivity.cs
`ScrollStacklayoutRender.Init();`
            

# Code Xamarin Forms

![XamlSample](https://user-images.githubusercontent.com/20682036/54189813-dc283200-44b2-11e9-933b-66eb191b1fe8.jpg)



