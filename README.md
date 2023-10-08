# BypassUAC
https://attack.mitre.org/techniques/T1548/002/
Privilege Escalation Technique
Abuse Elevation Control Mechanism: Bypass User Account Control

## fodhelper.exe
fodhelper.exe was introduced in Windows 10 to manage optional features like region-specific keyboard settings. It’s location is: C:\Windows\System32\fodhelper.exe and it is signed by Microsoft.
when the fodhelper.exe process is started, process monitor begins capturing the process and discloses all registry and filesystem read/write operations. The read registry accesses are one of the most intriguing activities, despite the fact that some specific keys or values are not discovered. The HKEY_CURRENT_USER registry keys are particularly useful for testing how a program’s behavior may change after the creation of a new registry key. fodhelper.exe searches for HKCU:\Software\Classes\ms-settings\shell\open\command, which does not exist by default in Windows 10, and that when malware launches fodhelper as a Medium integrity process, Windows automatically elevates fodhelper from a Medium to a High integrity process. The High integrity fodhelper then tries to open a ms-settings file using the file’s default handler.
* fodhelper.exe, searches for HKCU:\Software\Classes\ms-settings\shell\open\command. This key does not exist by default in Windows 10

### First of all create registry key and set values - our registry modification step:
* create HKCU:\Software\Classes\ms-settings\shell\open\command
* set Reg Name : "" and Reg Value : "cmd /c start C:\\Windows\\System32\\cmd.exe"
* set Reg Name : "DelegateExecute" and Reg Value : ""

![Untitled](https://github.com/pkwitha/BypassUAC/assets/91279108/58c0449f-0da5-4ae8-a573-474b9c3aa98f)


### Finally, you can see the output when fodhelper.exe runs.
![fodhelper](https://github.com/pkwitha/BypassUAC/assets/91279108/003a304b-5da9-452b-b8f4-b293fc17eb05)
