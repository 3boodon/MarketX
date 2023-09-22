using System;
using System.Collections.Generic;

namespace MarketX.Framework {
    internal class OptionsList {
        List<Option> Options { set; get; }

        Action Callback { get; set; } // this is the callback that will be called when the user enters an invalid option

        public OptionsList(List<Option> options, Action callback) {
            Option.Count = 0; // to prevent the count from incrementing every time we create a new instance of OptionsList
            this.Callback = callback;
            this.Options = options;
            this.Show();
            this.SelectOption();
        }
        public void Show() {
            this.Options.ForEach(option => Helper.Print($"{option.Id}. {option.Name}"));
        }
        // validate the user input and call the callback if the input is invalid
        public void SelectOption() {
            try {
                int optionId = Helper.GetUserInputAsInt("Enter Option Id: ");
                Option selectedOption = this.Options.Find(option => option.Id == optionId) ?? throw new Exception();
                selectedOption.CallBack();
            }
            catch {
                this.Callback();
            }
        }
    }

    class Option {
        public static int Count;
        public int Id { get; set; }
        public string Name { get; set; }
        public Action CallBack { get; set; }

        public Option(string name, Action callback) {
            Count++;
            this.Id = Count;
            this.Name = name;
            this.CallBack = callback;
        }
    }
}
