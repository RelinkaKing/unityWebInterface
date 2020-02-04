# RELEASE NOTES - CHANGE LOG
> All notable changes to this project will be documented in this file.


## Version 1.3.2 : Dec 22, 2017

### Bug fixes

- Follow up Unity 2017.3.0

- Fixed flickering when the 3D demo started.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.3.1 : Dec 19, 2017

### New features 

- A new demo has been added to describe how to embed the webview in a 3D object.

- Win32/WSA: Added SetHeaderField


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.3.0 : Dec 4, 2017

### New features 

- The new component "WWebView"
> Supports Unity-friendly component class for the webview.

- WSA: Downgrades plugin's SDK target version to 14393 from 15063.
> Minimum version is still 10240.

- WSA: Supports for Unity 2017.2.0
> UnityEngine.VR.VRSettings deprecated to UnityEngine.XR.XRSettings.
> UnityEngine.WSA.Application.InvokeOnAppThread behaviour has been changed.
> And, I don't know exactly but Unity's UWP modules seems to have changed a lot on 2017.2.0. 
> Because many codes that worked well in the past did not work on 2017.2.0.
> so, I had to test a lot and fix the code. I think there may be some remaining parts to fix.
> If you find some problems, Please let me know.

- Win32: Added "SetSilent" interface
> If you want to process the 401 login via windows security, just call "SetSilent(false)"

- WSA: Added the HoloLensVR demo.
> This is just an experimental stuff. It has been tested on HoloLens Emulator 10.0.14393.1358
> so, It may not work correctly on "real" Hololens device or work well. I'm not sure. 
> I'm looking for someone who test with me this stuff.
> Please mail me.

### Bug fixes

- Win32: Fixed an issue where the "EnableContextMenu" function called before "Load" did not work properly.

- WSA: Fixed a bug "SetUserAgent" does not work on "master" build.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.2.2 : Nov 3, 2017

### New features

- Supports UniWebView3 integration.
> http://www.icodes.studio/2017/10/how-to-integrate-with-uniwebview3.html

- Absolute position and size are supported.
> - SetFrame
> - SetPosition
> - SetSize

- WSA: CleanCache
> public static void CleanCookie(string name, string key);

- WSA: Added ability to delete all cookies
> eg. WWebViewPlugin.CleanCookie("", "");

- WSA: SetCookie
> public static void SetCookie(string url, string cookie)


### Bug fixes

- Win32: Fixed a bug that fixed size does not work.

- Editor: Fixed a problem where WebView was displayed in the wrong place.

- Editor: Fixed invalid focus when the webview hidden.

- WSA: fixed an app block on demo scene while navigating.

- Win32: fixed GetAlpha() function returns an incorrect value.

- Win32: Fixed a problem where TAB & DELETE key did not work.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.2.1 : Oct 25, 2017

### New features

- Win32: You can set IE version to be used as webview. (11, 10, 9, 8 and 7 are supported)
> WWebView is set to IE11 mode as default. You can also change this value by WWebViewWin32.Initialize function.

- Win32+WSA: CanGoBack function has been added.
> Gets a value indicating whether a previous page in navigation history is available, which allows the GoBack method to succeed.

- Win32+WSA: CanGoForward function has been added.
> Gets a value that indicates whether there is at least one entry in forward navigation history.


### Bug fixes

- Editor: Fixed following error.
> GUI Window tried to begin rendering while something else had not finished rendering! Either you have a recursive OnGUI rendering, or the previous OnGUI did not clean up properly. Assertion failed on expression: 'device.IsInsideFrame()'

- Editor: Fixed an issue
> where Webview closed when Unity tool window was closed.

- Win32: GetCookie
> Fixed an issue that couldn't get http session cookie.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.2.0 : Oct 14, 2017

### New features

- Editor(Windows x86, x64) supported
> WebView is embedded and displayed on the Unity Player. However, embedded native windows are very inconvenient when we develop the unity games. so, In the editor mode, it will be displayed as a popup window.

- Win32+WSA: GetActualWidth(Height)
> Get the webview's width and height, as a value in device-independent units (1/96th inch per unit).

- Win32+WSA: Overloaded the Init() and ChangeInsets() function to support fixed width and height.

- Win32+WSA: Managing scrollbar
> ShowScroll : Sets a value that indicates whether the scroll bars are turned on or off.
> ShowScrollX : Affects only the horizontal scroll bar.
> ShowScrollY : Affects only the vertical scroll bar.


### Minor

- Added an example
> handling custom url scheme. See the ReceiveMessage function.

- Added an example
> loading a local HTML file. See the NavigateLocalFile function.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.1.2 : Oct 3, 2017

### New features

- Win32: Capture & Render a content as a texture.
> Direct3D9, Direct3D11, Direct3D12 and OpenGLCore are supported.

- Win32: Transparency with alpha.

- WSA: Capture & Render a content as a texture.
> Direct3D11, Direct3D12 are supported.

- WSA: Transparency with alpha.


### Bug fixes

- Win32: Fixed window resizing bug.

- Win32: Fixed memory leak on CustomOleControlSite.cpp


### Minor

- Win32: Change plugin folder location to x86 and x64

- Win32: Event callbacks are created and stored as class members. because it is likely to be released by GC.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.1.1 : Sept 9, 2017

### New features

- Win32: Managing Cookies.


### Bug fixes

- Win32: Statically binds C Runtime Library. (/MT)
> VC++ Runtime Redistribution is no longer required. In fact, this is not a bug. In addition, Microsoft also recommends using dynamic dll binding. (/MD) However, it's not reasonable to assume that users of this plug-in are familiar with Windows distribution system. That's why I decided to use static C Runtime Library and, if you are a VC expert and want /MD, you can simply rebuild the plugin project and use it.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.1.0 : Aug 31, 2017

### New features

- Win32: Added Zoom in & out function.

- Win32: Added UserAgent changing function.

- Win32/WSA: Clearing cookies.


### Bug fixes

- WSA: Fixed navigation failure from local file.

- WSA/Win32: Fixed a bug where the success & failure parameter was incorrect
> When calling OnLoadComplete in UniWebView support mode.


--------------------------------------------------------------------------------------------------------------------------------------


## Version 1.0.0 : July 12, 2017

### First release

- Requires Unity 5.6.0 or higher. The native plugin was built with Visual Studio 2017. It has been tested in Unity 5.6.0f3 and 2017.1.0f3. Windows standalone(x86, x64) are supported. Windows 10 universal app(x86, x64, ARM) are supported. 
