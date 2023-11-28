using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calc

{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string result;
        private string equals;

        public string firstnumb { get => result; set { result = value; Signal(); } }
        public string promejnumb { get => tempText; set { tempText = value; Signal(); } }
        public double Temp { get; set; }
        public string finalnumb { get => equals; set { equals = value; Signal(); } }
        public double Value { get; set; }
        public double Result { get; set; } = 0;
        public string command { get; set; }
        public bool BackClick { get; set; }
        public bool tochkadefault { get; set; } = false;
        

        double a = 0;
        private string tempText;

        public bool FirstOperation { get; set; } = true;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Backspace(object sender, EventArgs e)
        {
            if (finalnumb == null || finalnumb == "")
            {
                if (firstnumb != null && firstnumb.Length >= 1)
                    firstnumb = firstnumb.Substring(0, firstnumb.Length - 1);
            }
            else
            {
                firstnumb = finalnumb.Substring(0, finalnumb.Length - 1);
                if (firstnumb == null || firstnumb == "")
                    Result = 0;


            }
            finalnumb = null;

            if (firstnumb != null && firstnumb != "")
                Result = double.Parse(firstnumb);

            if (firstnumb == "" || firstnumb == null || firstnumb == "-")
                firstnumb = "0";

        }

        private void CE(object sender, EventArgs e)
        {
            firstnumb = "0";
            command = null;
        }

        private void C(object sender, EventArgs e)
        {
            Result = 0;
            finalnumb = null;
            firstnumb = "0";
            promejnumb = null;
            Temp = 0;
            FirstOperation = true;
            tochkadefault = false;
        }

        private void pluss(object sender, EventArgs e)
        {
            if (finalnumb != "" && finalnumb != null)
            {
                Result = double.Parse(finalnumb);
                FirstOperation = false;
                command = "pluss";
            }
            else
            {

                if (firstnumb != null && firstnumb != "")
                {
                    if (FirstOperation)
                    {
                        Result = double.Parse(firstnumb);
                        FirstOperation = false;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "minuss":
                                minus();
                                break;
                            case "pluss":
                                plus();
                                break;
                            case "ymnoj":
                                ymnojit();
                                break;
                            case "delenie":
                                razdelit();
                                break;

                        }
                    }

                }
                command = "pluss";
            }
            finalnumb = null;
            firstnumb = null;
        }

        private void minuss(object sender, EventArgs e)
        {
            if (finalnumb != "" && finalnumb != null)
            {
                Result = double.Parse(finalnumb);
                FirstOperation = false;
                command = "minuss";
            }
            else
            {

                if (firstnumb != null)
                {

                    if (FirstOperation)
                    {
                        Result = double.Parse(firstnumb);
                        FirstOperation = false;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "minuss":
                                minus();
                                break;
                            case "pluss":
                                plus();
                                break;
                            case "ymnoj":
                                ymnojit();
                                break;
                            case "delenie":
                                razdelit();
                                break;

                        }
                    }

                }
                finalnumb = null;
                firstnumb = null;
                command = "minuss";
            }
        }

        private void ymnoj(object sender, EventArgs e)
        {
            if (finalnumb != "" && finalnumb != null)
            {
                FirstOperation = false;
                Result = double.Parse(finalnumb);
                command = "ymnoj";
            }
            else
            {

                if (firstnumb != null)
                {

                    if (FirstOperation)
                    {
                        Result = double.Parse(firstnumb);
                        FirstOperation = false;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "minuss":
                                minus();
                                break;
                            case "pluss":
                                plus();
                                break;
                            case "ymnoj":
                                ymnojit();
                                break;
                            case "delenie":
                                razdelit();
                                break;

                        }
                    }

                }
            }
            finalnumb = null;
            firstnumb = null;
            command = "ymnoj";
        }

        private void delenie(object sender, EventArgs e)
        {
            if (finalnumb != "" && finalnumb != null)
            {
                Result = double.Parse(finalnumb);
                FirstOperation = false;
                command = "delenie";

            }
            else
            {

                if (firstnumb != null)
                {

                    if (FirstOperation)
                    {
                        Result = double.Parse(firstnumb);
                        FirstOperation = false;
                    }
                    else
                    {
                        if (firstnumb != "0")
                        {
                            switch (command)
                            {
                                case "minuss":
                                    minus();
                                    break;
                                case "pluss":
                                    break;
                                case "ymnoj":
                                    ymnojit();
                                    break;
                                case "delenie":
                                    razdelit();
                                    break;

                            }
                        }

                    }

                }
            }
            finalnumb = null;
            firstnumb = null;
            command = "delenie";
        }

        private void procent(object sender, EventArgs e)
        {
            if (firstnumb != null && firstnumb != "")
            {
                firstnumb = (Result / 100 * double.Parse(firstnumb)).ToString();
            }
            else if (finalnumb != "" && equals != "")
                finalnumb = (double.Parse(finalnumb) / 100 * double.Parse(finalnumb)).ToString();
        }

        private void tochka(object sender, EventArgs e)
        {
            if (firstnumb == null || firstnumb == "")
            {
                finalnumb = null;
                firstnumb = "0.";
            }
            else if (!(firstnumb.Contains(".")))
            {
                firstnumb = firstnumb + ".";
            }

        }

        private void ravno(object sender, EventArgs e)
        {
            if (command == "pluss")
            {
                if (firstnumb != null && firstnumb != "")
                    finalnumb = (Result + double.Parse(firstnumb)).ToString();
                else
                    finalnumb = firstnumb;

                firstnumb = null;
                Result = 0;


            }
            if (command == "minuss")
            {
                if (firstnumb != null && firstnumb != "")
                    finalnumb = (Result - double.Parse(firstnumb)).ToString();
                else
                    finalnumb = Result.ToString();

                firstnumb = null;
                Result = 0;
            }
            if (command == "ymnoj")
            {
                if (firstnumb != null && firstnumb != "")
                    finalnumb = (Result * double.Parse(firstnumb)).ToString();
                else
                    finalnumb = Result.ToString();

                firstnumb = null;
                Result = 0;
            }
            if (command == "delenie")
            {

                if (firstnumb != null && firstnumb != "")
                {
                    if (firstnumb != "0")
                    {
                        finalnumb = (Result / double.Parse(firstnumb)).ToString();
                    }
                    else
                    {
                        finalnumb = "Недопустимый ввод";
                    }

                }

                else
                    finalnumb = Result.ToString();

                firstnumb = null;
                Result = 0;
            }
            promejnumb = null;
            tochkadefault = false;
            FirstOperation = true;
            command = null;
        }

        private void pm(object sender, EventArgs e)
        {
            if (finalnumb != null && finalnumb != "" && finalnumb != "0")
            {
                if (finalnumb.Contains("-"))
                    firstnumb = finalnumb.Substring(1);
                else
                    firstnumb = "-" + finalnumb;
            }
            else
            {
                if (firstnumb != null && firstnumb != "" && firstnumb != "0")
                {
                    if (firstnumb.Contains("-"))
                        firstnumb = firstnumb.Substring(1);
                    else
                        firstnumb = "-" + firstnumb;
                }
            }
            finalnumb = null;


        }

        private void koren(object sender, EventArgs e)
        {
            if (firstnumb != null && firstnumb != "" && !firstnumb.Contains("-"))
            {
                finalnumb = Math.Sqrt(double.Parse(firstnumb)).ToString();
                firstnumb = null;
            }
            else if (firstnumb.Contains("-"))
            {
                firstnumb = null;
                finalnumb = "Недопустимый ввод";
            }
            else if (finalnumb != null && finalnumb != "" && !finalnumb.Contains("-"))
            {
                firstnumb = Math.Sqrt(double.Parse(finalnumb)).ToString();
                finalnumb = null;
            }
        }


        private void recip(object sender, EventArgs e)
        {
            if (finalnumb != null && finalnumb != "")
            {
                firstnumb = (1 / double.Parse(finalnumb)).ToString();
                finalnumb = null;
            }
            else if (firstnumb != null && firstnumb != "")
            {
                finalnumb = (1 / double.Parse(firstnumb)).ToString();
                firstnumb = null;
            }
        }

        public void func(double value)
        {

            if (finalnumb != null && finalnumb != null)
            {
                firstnumb += Value.ToString();
                finalnumb = null;
            }

            else
                firstnumb += Value.ToString();
        }

        private void Seven(object sender, EventArgs e)
        {
            Value = 7;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Eight(object sender, EventArgs e)
        {
            Value = 8;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;

        }

        private void Nine(object sender, EventArgs e)
        {
            Value = 9;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Four(object sender, EventArgs e)
        {
            Value = 4;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Five(object sender, EventArgs e)
        {
            Value = 5;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Six(object sender, EventArgs e)
        {
            Value = 6;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void One(object sender, EventArgs e)
        {
            Value = 1;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Two(object sender, EventArgs e)
        {
            Value = 2;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Three(object sender, EventArgs e)
        {
            Value = 3;
            if (firstnumb == "0")
                firstnumb = null;
            func(Value);
            finalnumb = null;
        }

        private void Zero(object sender, EventArgs e)
        {
            if (firstnumb != "0")
            {
                Value = 0;
                func(Value);
                finalnumb = null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void plus()
        {
            Result += double.Parse(firstnumb);
            firstnumb = null;
            promejnumb = Result.ToString();
            tochkadefault = false;
        }

        public void minus()
        {
            Result -= double.Parse(firstnumb);
            firstnumb = null;
            promejnumb = Result.ToString();
            tochkadefault = false;
        }

        public void ymnojit()
        {
            Result *= double.Parse(firstnumb);
            firstnumb = null;
            promejnumb = Result.ToString();
            tochkadefault = false;
        }

        public void razdelit()
        {
            if (firstnumb != "0")
            {
                Result /= double.Parse(firstnumb);
                firstnumb = null;
                promejnumb = Result.ToString();
                tochkadefault = false;
            }
        }


    }
}
