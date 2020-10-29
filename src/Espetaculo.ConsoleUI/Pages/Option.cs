using System;

namespace Espetaculos.ConsoleUI.Pages {
    public class Option {
        public Option(string descriptions, Action action)
        {
            Descriptions = descriptions;
            Action = action;
        }

        public string Descriptions { get; set; }
        public Action Action {get;set;}
    }
}