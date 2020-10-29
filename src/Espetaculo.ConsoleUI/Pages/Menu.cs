using System.Collections.Generic;
using Espetaculos.ConsoleUI.Helpers;

namespace Espetaculos.ConsoleUI.Pages
{
    public abstract class Menu
    {
        public Menu()
        {
            Options = new List<Option>();
        }
        protected List<Option> Options { get; set; }        
        public void AddOptions(Option option)
        {
            Options.Add(option);
        }
        public Option GetOption()
        {            
            Option option;
            do {
                DisplayOptions();
                var chooseOption = Input.ReadInt("Informe a opção escolhida: ");
                option = Options[chooseOption - 1];
                if(option == null)                
                    Output.WriteAndWait("Informe uma opção válida", 0.6);   
                else 
                    return option;
            } while(true);
        }
        private void DisplayOptions()
        {
            short count = 1;
            foreach (var option in Options)
            {
                Output.Write($"{count} - {option.Descriptions}");
                count++;
            }
            Output.SkipLines(2);
        }

    }
}