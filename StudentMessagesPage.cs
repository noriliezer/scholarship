using System;
using System.Windows.Forms;

namespace scholarship
{
    public partial class StudentMessagesPage : Form
    {
        public StudentMessagesPage()
        {
            InitializeComponent();
            LoadMessages();
        }

        private void LoadMessages()
        {
            lstMessages.Items.Clear();
            foreach (var m in Db.GetMessagesByStudent(Session.StudentId))
                lstMessages.Items.Add(new MessageItem(m));
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            Db.MarkAllMessagesRead(Session.StudentId);
            LoadMessages();
        }

        private void lstMessages_DoubleClick(object sender, EventArgs e)
        {
            if (lstMessages.SelectedItem is MessageItem item)
            {
                Db.MarkMessageRead(item.Message.MessageId);
                Ui.ShowInfo($"{item.Message.Title}\n\n{item.Message.Body}");
                LoadMessages();
            }
        }

        private class MessageItem
        {
            public Message Message { get; }
            public MessageItem(Message m) { Message = m; }
            public override string ToString() =>
                $"{(Message.IsRead ? "○" : "●")}  [{Message.CreatedAt:yyyy-MM-dd}]  {Message.Title}";
        }
    }
}