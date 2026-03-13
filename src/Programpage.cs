using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Flit;

namespace Demo {
   [TestFixture (4, "Programpage")]
   #region Programpage--------------------------------------------------------------------------
   internal class Programpage {
      #region method-------------------------------------------------
      [FixtureInitialize]
      public void C001 () {
         Array.ForEach (Process.GetProcessesByName ("Vulcan"), x => x?.Kill ());
         var procInfo = new ProcessStartInfo {
            FileName = @"C:\Program Files\Metamation\Vulcan\Vulcan.exe",
            WorkingDirectory = $@"C:\Program Files\Metamation\Vulcan\Vulcan.exe".Replace ("Vulcan.exe", "")
         };
         Process.Start (procInfo);
         Thread.Sleep (TimeSpan.FromSeconds (8));
         var uia3 = new UIA3Automation ();
         win = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow ()!; // Home window
         var programpage =win.FindFirstDescendant (x => x.ByName ("Programs"));
         programpage.Click ();
      }

      /// <summary> part edit</summary>
      [Test(003,"Programspage")]
      public void Programspage () {
         win.FindFirstDescendant (x => x.ByName ("edit"))!.Click ();
         Thread.Sleep (400);
         
         Mouse.Click (new Point (398, 411));
         Point start = new Point (429, 462);
         Point drag = new Point (722, 717);
         Mouse.Drag (start,drag);
         Thread.Sleep (300);
         win.FindFirstDescendant (x => x.ByName ("add"))!.Click ();
         win.FindFirstDescendant (x => x.ByName ("CUILib.FileOpenDlg+FileData"))!.Click (); 
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Point partclk1 = new Point (398, 411);
         win.FindFirstDescendant (x => x.ByName ("move"))!.Click ();
         var movewindow = win.Parent.FindFirstDescendant (x => x.ByAutomationId ("TitleBar")).Parent;
         Thread.Sleep (300);
         String[] moves = ["move left", "move right", "move up", "move down"];
         foreach(var move in moves) {
            movewindow.FindFirstDescendant (x => x.ByName (move))!.Click ();
            Thread.Sleep (500);
         }
      }
      #endregion
      public static Window win;
   #endregion
   }
}
