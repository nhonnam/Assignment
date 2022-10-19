using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
  public sealed class KeyboardWindow
  {
		public int Height { get; set; }
		public int Width { get; set; }
		private KeyboardWindow() 
    {
      Console.WriteLine("A keyboard window has been created.");
    }
    private static KeyboardWindow instance = null;
    public static KeyboardWindow Instance
    {
      get
      {
        if (instance == null) instance = new KeyboardWindow();
        return instance;
      }
    }
    public void PrintInfo()
		{
      Console.WriteLine($"Height: {Height}, Width: {Width}");
    }
  }
  internal class Program
	{
		static void Main(string[] args)
		{
      var keyboardWindow1 = KeyboardWindow.Instance;
      keyboardWindow1.Width = 20;
      keyboardWindow1.Height = 10;
      var keyboardWindow2 = KeyboardWindow.Instance;
      keyboardWindow2.Width = 30;
      keyboardWindow2.Height = 15;
      if (keyboardWindow1 == keyboardWindow2)
        Console.WriteLine("Singleton works, both variables contain the same instance.");
      else
        Console.WriteLine("Singleton failed, variables contain different instances.");
      keyboardWindow1.PrintInfo();
      Console.Read();
    }
	}
}
