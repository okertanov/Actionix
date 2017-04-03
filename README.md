Actionix
========

OS Specific
-----------

    /System/Library/CoreServices/Menu Extras


Plug-in ideas
-------------
 - Applications list
 - Chrome tabs list
 - CPU/Mem indication
 - Battery health
 - Processes list
 - Gmail API tags
 - Gmail API notes
 - Gmail API tasks
 - Clipboard monitor
 - Code snippets
 - Remote Mac Lock/Unlock from iPhone
 - Remote app control
 - Apps scripting
 - Site monitoring for down, new content

TODO
----
 - To create installation package
 - To investigate Menu Extra bundle
 - To investigate Standalone Update process
 - Modeless popup, like tool window
 - Enabled, visible Menu item conditions
 - Preferences on Alt-Click
 - Preferences tabs with Active menu builders, not installed apps, etc
 - Application is not installed, prompt to install in the Preferences panel

 - kbd shortcuts handler with IOC registermany
 - detect chrome installed

 - Applications Menu: http://stackoverflow.com/questions/24280878/how-can-i-get-list-of-installed-applications-on-mac-os-x-programmetically

Requirements
------------
[Objective Sharpie](http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/objective_sharpie/)  
[MonoMac](http://www.mono-project.com/MonoMac)  
[Monobjc](http://www.monobjc.net/)  

Build & Install
---------------

    cd projects/_github_/Actionix.git
    git pull && git push && git status
    git submodule init
    git submodule update
    cd src/Sdefs
    make clean all
    cd ../
    xbuild /p:Configuration=Release Actionix.sln
    cp -a bin/Release/Actionix.app ~/Applications

Apple Script snippets
---------------------

    tell application "Google Chrome" to tell front window to get URL of tab (active tab index)


See also
--------
[Super OS X menubar items](http://menu.jeweledplatypus.org/)  
[Menulets - NEW extensive list of menu extras](http://www.menulet.me/)  
[Lighthead Software Remember](http://lightheadsw.com/remember)  
[Lighthead Software Caffeine](http://lightheadsw.com/caffeine/)  
[Retina Mac Apps](http://retinamacapps.com/)  

New Resources
-------------
[SBApplication](https://developer.apple.com/library/mac/documentation/Cocoa/Reference/SBApplication_Class/)  
[SBApplicationDelegate](https://developer.apple.com/library/mac/documentation/Cocoa/Reference/SBApplicationDelegate_Protocol/index.html)  
[Open Scripting Architecture](https://developer.apple.com/library/mac/documentation/AppleScript/Conceptual/AppleScriptX/Concepts/osa.html)  
[AppleScript Language Guide: Commands Reference](https://developer.apple.com/library/mac/documentation/AppleScript/Conceptual/AppleScriptLangGuide/reference/ASLR_cmds.html)  

Resources
---------
[App Icon](https://www.iconfinder.com/icons/183175/genius_icon#size=512)  
[NSEvent](https://developer.apple.com/library/mac/documentation/Cocoa/Reference/ApplicationKit/Classes/NSEvent_Class/Reference/Reference.html)  
[App Extensions Increase Your Impact](https://developer.apple.com/library/prerelease/mac/documentation/General/Conceptual/ExtensibilityPG/index.html)  

[Menu extra](http://en.wikipedia.org/wiki/Menu_extra)  
[Building NSMenuExtra - A Small Tutorial](http://cocoadevcentral.com/articles/000078.php)  

[Using Scripting Bridge](https://developer.apple.com/library/mac/documentation/Cocoa/Conceptual/ScriptingBridgeConcepts/UsingScriptingBridge/UsingScriptingBridge.html)  
[MonoMac: Binding Objective-C Types](http://www.mono-project.com/MonoMac/Documentation/Binding_New_Objective-C_Types)  
[Xamarin: Binding Objective-C](http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/)  
[Binding a Cocoa framework for Xamarin.Mac](http://brendanzagaeski.appspot.com/xamarin/0002.html)  

[Chrome Cli](https://github.com/prasmussen/chrome-cli/blob/master/chrome-cli/App.m)  

### OSX Battery Status API
http://stackoverflow.com/questions/1432792/how-to-get-the-battery-life-of-mac-os-x-macbooks-programatically  
http://stackoverflow.com/questions/20585735/how-do-i-get-battery-charge-cycles-from-a-connected-ios-device  
https://developer.apple.com/library/ios/technotes/tn2169/_index.html  
https://github.com/codler/Battery-Time-Remaining/tree/master/Battery%20Time%20Remaining  
https://media.blackhat.com/bh-us-11/Miller/BH_US_11_Miller_Battery_Firmware_Public_WP.pdf  
http://imars.info/getting-battery-related-information-in-cocoa-osx-development/  
http://benohead.com/mac-os-x-getting-power-source-information/  
http://forums.macrumors.com/showthread.php?t=1304554  
https://developer.apple.com/library/mac/samplecode/BatteryInfo/Introduction/Intro.html#//apple_ref/doc/uid/DTS40009313  
