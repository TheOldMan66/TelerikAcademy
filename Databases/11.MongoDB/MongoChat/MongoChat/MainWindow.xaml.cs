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
using MongoChat.Data;
using MongoChat.Model;

namespace MongoChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser;
        private MongoDBContext db;
        public MainWindow(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            this.textblockUserName.Text = "Logged as " + user.UserName;
            db = new MongoDBContext();
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnAllPosts_Click(object sender, RoutedEventArgs e)
        {
            var db = new MongoDBContext();
            IEnumerable<Message> messages =  db.GetPosts();
            PopulatePosts(messages);
        }

        private void buttonSendMessage_Click(object sender, RoutedEventArgs e)
        {
            Message message = new Message();
            message.Sender = new User { UserName = this.currentUser.UserName };
            message.TimeStamp = DateTime.UtcNow;
            message.Text = this.textboxMessage.Text;
            db.AddPost(message);
            listboxMainChat.Items.Add(new ListBoxItem { Content = message });
            this.textboxMessage.Text = "";
        }

        private void PopulatePosts(IEnumerable<Message> messages)
        {
            listboxMainChat.Items.Clear();
            foreach (var post in messages)
            {
                listboxMainChat.Items.Add(new ListBoxItem { Content = post });
                
            }
        }

        private void btnPostsFromThisSession_Click(object sender, RoutedEventArgs e)
        {
            var db = new MongoDBContext();
            IEnumerable<Message> messages = db.GetPosts(currentUser.LastLogin);
            PopulatePosts(messages);
        }
    }
}
