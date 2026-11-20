using System;
using System.Diagnostics;
using System.Threading;
using Ranorex;
namespace RetroTests
{
    public static class UI
    {
        public const string Root="/form[@processname='RetroUID7' and @class='TRetroUIForm']";
        public static Unknown Find(string name)
        {
            return Host.Local.FindSingle<Unknown>(Root+"//*[@controlname='"+name+"']",10000);
        }
        public static void Click(string name)
        {
            Find(name).Click();
            Screenshots.Capture("AfterClick_"+name);
        }
        public static string Attr(string name,string attr)
        {
            return Find(name).Element.GetAttributeValueText(attr);
        }
        public static void Check(bool value,string message)
        {
            if(!value) throw new Exception(message);
            Console.WriteLine("PASS: "+message);
        }
        public static void Enabled(string name,bool expected)
        {
            Check(bool.Parse(Attr(name,"enabled"))==expected,name+" enabled="+expected);
        }
        public static void Text(string name,string value)
        {
            Check(Attr(name,"windowtext").Contains(value),name+" contains "+value);
        }
        public static void Toggle(string name,bool value)
        {
            var c=Host.Local.FindSingle<CheckBox>(Root+"//*[@controlname='"+name+"']",10000);
            if(c.Checked!=value)c.Click();
            Check(c.Checked==value,name+" checked="+value);
            Screenshots.Capture("Option_"+name+"_"+value);
        }
        public static void Wait(Func<bool> condition,int seconds,string message)
        {
            var until=System.DateTime.UtcNow.AddSeconds(seconds);
            while(System.DateTime.UtcNow<until)
            {
                if(condition())return;
                Thread.Sleep(200);
            }
            throw new Exception(message);
        }
        public static void Confirm(bool yes)
        {
            Screenshots.Capture("Confirmation_"+(yes?"Yes":"No"));
            Host.Local.FindSingle<Button>("/form[@processname='RetroUID7' and @class='TMessageForm']//button[@text~'"+(yes?"Yes|はい":"No|いいえ")+"']",10000).Click();
        }
        public static void Start()
        {
            Toggle("chkAuto",false);
            Click("btnExec");
            Enabled("btnExec",false);
            Enabled("btnStop",true);
            Enabled("grpHoushiki",false);
            Enabled("grpPort",false);
        }
        public static void Stop()
        {
            Click("btnStop");
            Confirm(true);
            Enabled("btnExec",true);
            Enabled("btnStop",false);
            Enabled("grpHoushiki",true);
            Enabled("grpPort",true);
        }
        public static void Run(string name,Action test)
        {
            Process p=null;
            Screenshots.BeginCase(name);
            try
            {
                p=Process.Start(new ProcessStartInfo(@"C:\work\RetroUI\RetroUID7.exe")
                {
                    WorkingDirectory=@"C:\work\RetroUI"
                }
                );
                Find("btnExec");
                Screenshots.Capture("Initial");
                test();
                Screenshots.Capture("Completed");
                Console.WriteLine("PASS CASE "+name);
            }
            catch
            {
                try
                {
                    Screenshots.Capture("Failed");
                }
                catch(Exception captureError)
                {
                    Console.Error.WriteLine("Failure screenshot could not be saved: "+captureError);
                }
                throw;
            }
            finally
            {
                if(p!=null&&!p.HasExited)
                {
                    p.Kill();
                    p.WaitForExit(5000);
                }
                if(p!=null)p.Dispose();
            }
        }
    }
}
