using Flit;
using System.Reflection;

#region class Demno -------------------------------------------------------------------------------
class MyClass {
   static void Main (string[] args) {
   
      // Gathering test(s) or fixture id(s) from command line arguments, if there is any, and run the tests, if there is no argument, all test cases in the assembly will be executed
      List<int> testID = [];
      foreach (var item in args) testID.Add (int.Parse (item));
      FlitTestRunner ([.. testID]);
   }

   // Give test case id(s) to run or fixture id (-1) if you want to run all test cases in the assembly, pass empty array or null
   static void FlitTestRunner (int[] testCaseIds) {
      TestRunner testRunner = new ();
      TestRunner.OnlyThese = testCaseIds;
      testRunner.GatherTests (Assembly.GetExecutingAssembly ());
      testRunner.Monitor += OnMonitor;
      testRunner.RunTests ();
   }

   // This method will be called for each test case after it is executed, you can use this to print test results in your own format, or log them in a file
   static bool OnMonitor (TestRunner runner, TestRunner.Phase phase, string name, int id) {
      switch (phase) {
         case TestRunner.Phase.TestPassed:
            Console.Write ($"{id} : {name}");
            Print (TestRunner.Phase.TestPassed);
            break;
         case TestRunner.Phase.TestFailed:
            Console.Write ($"{id} : {name}");
            Print (TestRunner.Phase.TestFailed);
            break;
         case TestRunner.Phase.TestCrash:
            Console.Write ($"{id} : {name}");
            Print (TestRunner.Phase.TestCrash);
            break;
      }
      return true;
   }

   static void Print (TestRunner.Phase phase) {
      Console.Write (new string ('.', Console.WindowWidth - Console.CursorLeft - 5));
      if (phase == TestRunner.Phase.TestPassed) {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.Write ("pass");
         Console.ResetColor ();
      } else if (phase == TestRunner.Phase.TestFailed) {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.Write ("fail");
         Console.ResetColor ();
      } else if (phase == TestRunner.Phase.TestCrash) {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.Write ("crash");
         Console.ResetColor ();
      } 
      Console.WriteLine ();
   }
}
#endregion


