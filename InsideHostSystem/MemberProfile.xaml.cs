using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace InsideHostSystem
{
    public partial class MemberProfile : Window
    {
        public Member Member { get; set; }
        public static List<MemberProfile> AllProfiles { get; set; }

        //ct-k
        static MemberProfile()
        {
            AllProfiles = new List<MemberProfile>();
        }
        public MemberProfile(Member member)
        {
            AllProfiles.Add(this);
            Member = member;
            InitializeComponent();
            Member.LogedIn = true;
            MemberName.Text = Member.Name;
            ShowContacts();
            ShowNotContactedYet();
            FuggoFelkeresek(Member);
            NewMessage(Member);
        }

        //INDULÓ ÁLLAPOT KIALAKÍTÁSA

        //Az ismerősök legördülőt tölti fel
        private void ShowContacts()
        {
            Contacts.Items.Clear();
            foreach (var item in Member.Contacts)
            {
                Contacts.Items.Add(item.Name);
            }
        }
        //A kiket ismerhetek legördülőt tölti fel
        private void ShowNotContactedYet()
        {
            NotContacted.Items.Clear();
            foreach (var item in Member.AllMembers)
            {
                if (!Member.Contacts.Contains(item) && item.Name != Member.Name)
                    NotContacted.Items.Add(item.Name);
            }
        }

        //ÜZENETEK

        //Lehetséges címzettek feltöltése
        private void MailToList()
        {
            MailTo.Items.Clear();
            foreach (var member in Member.Contacts)
            {
                MailTo.Items.Add(member.Name);
            }
        }
        //Üzenetküldés
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MessageContent.Text == "")
            {
                MessageBox.Show("Üres üzenetet nem lehet küldeni!");
                return;
            }
            if (MailTo.Text == "")
            {
                MessageBox.Show("A címzett megadása kötelező!");
                return;
            }

            foreach (var tomember in Member.Contacts)
            {
                if (tomember.Name == MailTo.Text)
                {
                    tomember.Messages.Push(new Message(Member, DateTime.Now, MessageCoder(MessageContent.Text)));
                    if (tomember.LogedIn == true)
                    {
                        MemberProfile to = AllProfiles.Where(p => p.Member == tomember).First();
                        to.MessageContent.Text = "Olvasatlan üzenetei vannak!";
                    }
                    MessageContent.Text = "";
                    MailTo.Text = "";
                    return;
                }
            }
        }
        //Kidobálja MessageBoxban az új üziket majd azok státuszát olvasottra váltja
        private void Unseen_Click(object sender, RoutedEventArgs e)
        {
            List<Message> query = Member.Messages.Where(m => m.Seen == false).ToList();
            if (query != null)
            {
                foreach (var item in query)
                {
                    MessageBox.Show($"{item.From.Name}\n{item.Date}\n\n{MessageDecoder(item.Content)}");
                    item.Seen = true;
                }
                MessageContent.Text = "";
            }
        }
        //Az összes kapott üzenetet kiírja, a legújabb az első
        private void AllMessages_Click(object sender, RoutedEventArgs e)
        {
            if (Member.Messages.Count == 0)
            {
                MessageBox.Show("Önnek nincsenek üzenetei");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var message in Member.Messages)
            {
                sb.Append($"Feladó: {message.From.Name}\n");
                sb.Append($"Dátum: {message.Date}\n");
                sb.Append($"{MessageDecoder(message.Content)}\n\n");
            }
            MessageBox.Show(sb.ToString());
            Kiiro();
        }
        //Kiírja ha vannak új üzenetek, FELADAT BELÜL
        public void NewMessage(Member actual)
        {
            foreach (var message in actual.Messages)//ezt meg lehetne irni lambdásan csak ne dobjon Exceptiont ha nincs találat!!!
            {
                if (message.Seen == false)
                {
                    MessageContent.Text = "Olvasatlan üzenetei vannak!";
                }
            }
        }
        //Üzenet kódolása, dekódolása
        private static string MessageCoder(string message)
        {
            string lowerMessage = message.ToLower();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lowerMessage.Length; i++)
            {
                sb.Append(MainWindow.CharacterChanger($"{lowerMessage[i]}"));
            }
            return sb.ToString();
        }
        private static string MessageDecoder(string codedMessage)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < codedMessage.Length; i += 2)
            {
                sb.Append(codedMessage[i]);
                sb.Append(codedMessage[i + 1]);
                result.Append(MainWindow.CharacterReGenerator(int.Parse(sb.ToString())));
                sb.Clear();
            }
            return result.ToString();
        }

        //FELKÉRÉSEK

        //Kiírja ha vannak függőben lévő felkérések
        public void FuggoFelkeresek(Member actual)
        {
            if (actual.Requests.Count != 0)
                NewContact.Text = "Függőben levő felkérései vannak!";
        }
        //Új member felvétele
        private void AddToContacts_Click(object sender, RoutedEventArgs e)
        {
            foreach (var member in Member.AllMembers)
            {
                if (member.Name == NotContacted.Text)
                {
                    if (Member.Requests.Contains(member))
                    {
                        MessageBox.Show("Ő már ismerősnek jelölt téged, csak el kell fogadnod a felkérését!");
                        return;
                    }

                    member.Requests.Add(Member);//ha nincs bejelentkezve, amikor bejelentkezik lefut a FuggoFelkeresek(önmaga)
                    NotContacted.Text = "";
                    if (member.LogedIn == true)//ha be van jelentkezve
                    {
                        MemberProfile to = AllProfiles.Where(p => p.Member == member).First();
                        to.FuggoFelkeresek(member);
                    }
                    break;
                }
            }
            NewContact.Text = "";
        }
        //Ez fut le a Felkérések gomb megnyomásakor
        private void Requests_Click(object sender, RoutedEventArgs e)
        {
            if (Member.Requests.Count != 0)
            {
                foreach (var member in Member.Requests)
                {
                    MessageBoxResult result = MessageBox.Show($"{member.Name} ismerősnek jelölt!", "Új Felkérés", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        Member.Contacts.Add(member);
                        member.Contacts.Add(Member);
                        //Innentől a profilokat aktualizálja vagyis kiveszi az ismerhetem boxból és átteszi az ismerősök közé minkét 
                        //oldalon a másikat
                        MemberProfile to = AllProfiles.Where(p => p.Member == member).First();
                        to.ShowContacts();
                        ShowContacts();
                        to.ShowNotContactedYet();
                        ShowNotContactedYet();
                        to.MailToList();
                        MailToList();
                    }
                }
                Member.Requests.Clear();
                NewContact.Text = "";
            }
        }

        //ABLAK BEZÁRÁSA

        //Ha zárjuk az ablakot FELADAT: legyne kilépés gomb ami ugyanezt hívja
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Member.LogedIn = false;
        }

        //Probálkozások
        private void Kiiro()
        {
            if (Member.Messages.Count != 0)
            {
                foreach (var item in Member.Messages)
                {
                    EventsFromOP.Text += item.Content;
                }
            }
        }

        private void archButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer =
            new StreamWriter($"{Member.Name}_archive.txt"))
            {
                writer.WriteLine($"Adatok: {Member.Name}");
                writer.WriteLine("-------------------------");
                writer.WriteLine("Kontaktok: ");
                foreach (var item in Member.Contacts)
                {
                    writer.WriteLine($"{item.Name}");
                }
                writer.WriteLine("-------------------------");
                writer.WriteLine("Üzenetek:");
                foreach (var item in Member.Messages)
                {
                    writer.WriteLine($"Feladó: {item.From.Name}");
                    writer.WriteLine($"{MessageDecoder(item.Content)}");
                    writer.WriteLine(item.Date);
                }
            }
        }
    }
}
