using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsideHostSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            regFeedBack.Text = "";
            if (regName.Text == "" || regPass.Password == "")
            {
                regFeedBack.Text = "A felhasználónév vagy a jelszó mező nem maradhat üres!";
                return;
            }

            if(regCheckBox.IsChecked == false)
            {
                regFeedBack.Text = "A használati feltételeket el kell fogadni!";
                return;
            }
                
            string name = regName.Text;
            string pass = regPass.Password;
            
            if(pass.Length >= 6)
            {
                foreach (var member in Member.AllMembers)
                {
                    if(member.Name == name)
                    {
                        regFeedBack.Text = "Ezzel a névvel már regisztráltak, válassz mást!";
                        regName.Text = "";
                        regPass.Password = "";
                        return;
                    }
                        
                }
                Member.AllMembers.Add(new Member(name, SecurePass(pass))); //Itt kerül bele a Member az AllMembers static Listbe és itt titkosítom a jelszavát
                regFeedBack.Text = "Sikeres Regisztráció! Most már be tudsz jelentkezni!";
                regName.Text = "";
                regPass.Password = "";
                regCheckBox.IsChecked = false;
            }
            else
            {
                regFeedBack.Text = "Túl rövid jelszó! Adj meg legalább 6 karaktert!";
            }
        }
        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            logFeedBack.Text = "";
            if (logName.Text == "" || logPass.Password == "")
            {
                regFeedBack.Text = "A felhasználónév vagy a jelszó mező nem maradhat üres!";
                return;
            }

            string name = logName.Text;
            string pass = logPass.Password;

            foreach (var member in Member.AllMembers)
            {
                if(member.Name == name && member.Pass == SecurePass(pass)) //itt a titkosító metódust lefuttatom a megadott jelszóval
                {
                    new MemberProfile(member).Show();
                    logName.Text = "";
                    logPass.Password = "";
                    return;
                }
            }
            logFeedBack.Text = "Hibás felhasználónév vagy jelszó!";
        }

        //Jelszótitkosítás
        private static string SecurePass(string pass)
        {
            string lowerPass = pass.ToLower();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pass.Length; i++)
            {
                sb.Append(CharacterChanger($"{lowerPass[i]}"));
            }

            long szam = long.Parse(sb.ToString());
            return Convert.ToString(szam, 2);//átírja binális kódba
        }
        public static string CharacterChanger(string character)//minden karaktert átalakít
        {
            string result = "";

            switch (character)
            {
                case "a":
                    result = "06";
                    break;
                case "á":
                    result = "47";
                    break;
                case "b":
                    result = "66";
                    break;
                case "c":
                    result = "26";
                    break;
                case "d":
                    result = "32";
                    break;
                case "e":
                    result = "02";
                    break;
                case "é":
                    result = "84";
                    break;
                case "f":
                    result = "45";
                    break;
                case "g":
                    result = "43";
                    break;
                case "h":
                    result = "21";
                    break;
                case "i":
                    result = "77";
                    break;
                case "í":
                    result = "31";
                    break;
                case "j":
                    result = "09";
                    break;
                case "k":
                    result = "80";
                    break;
                case "l":
                    result = "05";
                    break;
                case "m":
                    result = "12";
                    break;
                case "n":
                    result = "19";
                    break;
                case "o":
                    result = "93";
                    break;
                case "ó":
                    result = "03";
                    break;
                case "ö":
                    result = "07";
                    break;
                case "ő":
                    result = "04";
                    break;
                case "p":
                    result = "35";
                    break;
                case "q":
                    result = "54";
                    break;
                case "r":
                    result = "94";
                    break;
                case "s":
                    result = "81";
                    break;
                case "t":
                    result = "72";
                    break;
                case "u":
                    result = "38";
                    break;
                case "ú":
                    result = "87";
                    break;
                case "ü":
                    result = "29";
                    break;
                case "ű":
                    result = "34";
                    break;
                case "v":
                    result = "01";
                    break;
                case "w":
                    result = "11";
                    break;
                case "x":
                    result = "57";
                    break;
                case "y":
                    result = "16";
                    break;
                case "z":
                    result = "69";
                    break;
                case "0":
                    result = "88";
                    break;
                case "1":
                    result = "98";
                    break;
                case "2":
                    result = "33";
                    break;
                case "3":
                    result = "63";
                    break;
                case "4":
                    result = "14";
                    break;
                case "5":
                    result = "97";
                    break;
                case "6":
                    result = "53";
                    break;
                case "7":
                    result = "86";
                    break;
                case "8":
                    result = "55";
                    break;
                case "9":
                    result = "49";
                    break;
                case ".":
                    result = "22";
                    break;
                case ",":
                    result = "23";
                    break;
                case "!":
                    result = "24";
                    break;
                case "?":
                    result = "25";
                    break;
                case ":":
                    result = "27";
                    break;
                case " ":
                    result = "00";
                    break;

                default:
                    result = "%";
                    break;
            }

            return result;
        }
        public static string CharacterReGenerator(int num)//Ez az üzenetekhez kell ahol van visszaalakítás is
        {
            string result = "";

            switch (num)
            {
                case 6:
                    result = "a";
                    break;
                case 47:
                    result = "á";
                    break;
                case 66:
                    result = "b";
                    break;
                case 26:
                    result = "c";
                    break;
                case 32:
                    result = "d";
                    break;
                case 2:
                    result = "e";
                    break;
                case 84:
                    result = "é";
                    break;
                case 45:
                    result = "f";
                    break;
                case 43:
                    result = "g";
                    break;
                case 21:
                    result = "h";
                    break;
                case 77:
                    result = "i";
                    break;
                case 31:
                    result = "í";
                    break;
                case 09:
                    result = "j";
                    break;
                case 80:
                    result = "k";
                    break;
                case 5:
                    result = "l";
                    break;
                case 12:
                    result = "m";
                    break;
                case 19:
                    result = "n";
                    break;
                case 93:
                    result = "o";
                    break;
                case 3:
                    result = "ó";
                    break;
                case 7:
                    result = "ö";
                    break;
                case 4:
                    result = "ő";
                    break;
                case 35:
                    result = "p";
                    break;
                case 54:
                    result = "q";
                    break;
                case 94:
                    result = "r";
                    break;
                case 81:
                    result = "s";
                    break;
                case 72:
                    result = "t";
                    break;
                case 38:
                    result = "u";
                    break;
                case 87:
                    result = "ú";
                    break;
                case 29:
                    result = "ü";
                    break;
                case 34:
                    result = "ű";
                    break;
                case 1:
                    result = "v";
                    break;
                case 11:
                    result = "w";
                    break;
                case 57:
                    result = "x";
                    break;
                case 16:
                    result = "y";
                    break;
                case 69:
                    result = "z";
                    break;
                case 88:
                    result = "0";
                    break;
                case 98:
                    result = "1";
                    break;
                case 33:
                    result = "2";
                    break;
                case 63:
                    result = "3";
                    break;
                case 14:
                    result = "4";
                    break;
                case 97:
                    result = "5";
                    break;
                case 53:
                    result = "6";
                    break;
                case 86:
                    result = "7";
                    break;
                case 55:
                    result = "8";
                    break;
                case 49:
                    result = "9";
                    break;
                case 22:
                    result = ".";
                    break;
                case 23:
                    result = ",";
                    break;
                case 24:
                    result = "!";
                    break;
                case 25:
                    result = "?";
                    break;
                case 27:
                    result = ":";
                    break;
                case 0:
                    result = " ";
                    break;

                default:
                    result = "%";
                    break;
            }

            return result;
        }
    }
}
