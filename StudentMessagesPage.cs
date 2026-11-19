using System;
using System.Windows.Forms;
using scholarship;

namespace ScholarshipApp
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
            try
            {
                foreach (var m in Db.GetMessagesByStudent(Session.StudentId))
                    lstMessages.Items.Add(new MessageItem(m));
            }
            catch (Exception ex)
            {
                Ui.Error("Could not load messages: " + ex.Message);
            }
        }

        private void btnMarkAll_Click(object sender, EventArgs e)
        {
            try { Db.MarkAllMessagesRead(Session.StudentId); LoadMessages(); }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private void lstMessages_DoubleClick(object sender, EventArgs e)
        {
            if (lstMessages.SelectedItem is not MessageItem item) return;
            try
            {
                Db.MarkMessageRead(item.Message.MessageId);
                Ui.Info($"{item.Message.Title}\n\n{item.Message.Body}");
                LoadMessages();
            }
            catch (Exception ex) { Ui.Error(ex.Message); }
        }

        private class MessageItem
        {
            public StudentMessage Message { get; }
            public MessageItem(StudentMessage m) { Message = m; }
            public override string ToString() =>
                $"{(Message.IsRead ? "○" : "●")}  [{Message.CreatedAt:yyyy-MM-dd}]  {Message.Title}";
        }
    }
}