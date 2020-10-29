using System.Collections.Generic;
using Espetaculos.ConsoleUI.Helpers;

namespace Espetaculos.ConsoleUI.Pages {
    public class MainMenu : Menu {
        public MainMenu()
        {
            base.AddOptions(new Option("Login", Login));
            base.AddOptions(new Option("Register", Register));
        }

        public void Login() {
            Output.Write("Login sucess");
        }
        public void Register() {
            Output.Write("Register sucess");
        }
    }

}