Notifications of new posts on forums.gta5-mods.com. Written in C# using Mono (.NET Framework version 4.5.2), GTK# 2.12, Json.NET, notify-sharp, and a modified version of the notification code from [here](https://github.com/noxad/windows-toast-notifications).

You can configure which posts you want to see (only from certain categories and only if they contain certain words), blacklist users you don't want notifications about (such as yourself), enable/disable the notification sound, change how often to check for new posts, and set the program to run on startup (Windows only).

Notifications on screen are made on Linux using the notify-sharp library and are made on Windows using modified code from [here](https://github.com/noxad/windows-toast-notifications). On-screen notifications are not supported for Mac.

Requirements:
Linux: mono, gtk-sharp2
Windows: .NET 4.5.2, [GTK#](http://www.mono-project.com/download/#download-win)
Mac: (untested) [Mono](http://www.mono-project.com/download/#download-mac)

[Download.](https://github.com/Jitnaught/GTA5MFNotifier-Mono/releases)

P.S. If you are building from source using MonoDevelop on Linux make sure to remove the Mono.Posix reference, otherwise the program won't run under Windows.

![Linux notification screen](https://i.imgur.com/5NAw3jc.png)

![Linux screen](https://i.imgur.com/gnMr6qK.png)

![Windows notification screen](https://i.imgur.com/XTeqpZA.png)