using System;
using System.Drawing;
using System.Windows.Forms;

namespace scholarship
{
    public partial class StudentMessagesPage : Form
    {
        private ListBox _list;

        public StudentMessagesPage()
        {
            Text = "Messages";
            Width = 800; Height = 560;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            Controls.Add(new Label { Text = "Messages / Notifications", Font = Ui.TitleFont, Location = new Point(20, 18), AutoSize = true });

            var markAll = Ui.GhostButton("Mark all read");
            markAll.Location = new Point(600, 20);
            markAll.Click += (s, e) => { Db.MarkAllMessagesRead(Session.StudentId); LoadMessages(); };
            Controls.Add(markAll);

            _list = new ListBox { Location = new Point(20, 70), Width = 740, Height = 440, BorderStyle = BorderStyle.FixedSingle };
            _list.DoubleClick += List_DoubleClick;
            Controls.Add(_list);

            LoadMessages();
        }

        private void LoadMessages()
        {
            _list.Items.Clear();
            foreach (var m in Db.GetMessagesByStudent(Session.StudentId))
                _list.Items.Add(new MessageItem(m));
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (_list.SelectedItem is MessageItem item)
            {
                Db.MarkMessageRead(item.Message.MessageId);
                Ui.Info($"{item.Message.Title}\n\n{item.Message.Body}");
                LoadMessages();
            }
        }

        private class MessageItem
        {
            public StudentMessage Message { get; }
            public MessageItem(StudentMessage m) { Message = m; }
            public override string ToString() => $"{(Message.IsRead ? "○" : "●")}  [{Message.CreatedAt:yyyy-MM-dd}]  {Message.Title}";
        }
    }
}