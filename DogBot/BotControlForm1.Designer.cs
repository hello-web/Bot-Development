namespace MyBot
{
    partial class BotControlForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.saychatbutton = new System.Windows.Forms.Button();
            this.FNtextBox = new System.Windows.Forms.TextBox();
            this.PWtextBox = new System.Windows.Forms.TextBox();
            this.LNtextBox = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Xbox = new System.Windows.Forms.TextBox();
            this.Ybox = new System.Windows.Forms.TextBox();
            this.MoveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chatboxlabel = new System.Windows.Forms.Label();
            this.objectsBox = new System.Windows.Forms.TextBox();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.URIbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.turnleftbutton = new System.Windows.Forms.Button();
            this.turnleftbox = new System.Windows.Forms.TextBox();
            this.turnrightbutton = new System.Windows.Forms.Button();
            this.turnrightbox = new System.Windows.Forms.TextBox();
            this.mycoordinatesbutton = new System.Windows.Forms.Button();
            this.readchatbutton = new System.Windows.Forms.Button();
            this.goforwardbutton = new System.Windows.Forms.Button();
            this.goforwardbox = new System.Windows.Forms.TextBox();
            this.gobackwardbox = new System.Windows.Forms.TextBox();
            this.gobackwardbutton = new System.Windows.Forms.Button();
            this.turntowardbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LookButton = new System.Windows.Forms.Button();
            this.myrotationbutton = new System.Windows.Forms.Button();
            this.rotationBox = new System.Windows.Forms.TextBox();
            this.readmessagebutton = new System.Windows.Forms.Button();
            this.saymessagebutton = new System.Windows.Forms.Button();
            this.objectidbox = new System.Windows.Forms.TextBox();
            this.dropobjectbutton = new System.Windows.Forms.Button();
            this.takeobjectbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.AutoButton = new System.Windows.Forms.Button();
            this.ServerBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatBox.Location = new System.Drawing.Point(15, 21);
            this.ChatBox.MinimumSize = new System.Drawing.Size(260, 138);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(470, 138);
            this.ChatBox.TabIndex = 0;
            // 
            // InputBox
            // 
            this.InputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBox.Location = new System.Drawing.Point(15, 168);
            this.InputBox.MinimumSize = new System.Drawing.Size(227, 20);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(295, 20);
            this.InputBox.TabIndex = 1;
            // 
            // saychatbutton
            // 
            this.saychatbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saychatbutton.Location = new System.Drawing.Point(235, 216);
            this.saychatbutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.saychatbutton.Name = "saychatbutton";
            this.saychatbutton.Size = new System.Drawing.Size(75, 23);
            this.saychatbutton.TabIndex = 2;
            this.saychatbutton.Text = "SayChat";
            this.saychatbutton.UseVisualStyleBackColor = true;
            // 
            // FNtextBox
            // 
            this.FNtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FNtextBox.Location = new System.Drawing.Point(376, 173);
            this.FNtextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.FNtextBox.Name = "FNtextBox";
            this.FNtextBox.Size = new System.Drawing.Size(100, 20);
            this.FNtextBox.TabIndex = 3;
            this.FNtextBox.Text = "Dog";
            // 
            // PWtextBox
            // 
            this.PWtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PWtextBox.Location = new System.Drawing.Point(60, 52);
            this.PWtextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.PWtextBox.Name = "PWtextBox";
            this.PWtextBox.PasswordChar = '*';
            this.PWtextBox.Size = new System.Drawing.Size(100, 20);
            this.PWtextBox.TabIndex = 5;
            this.PWtextBox.Text = "alive";
            this.PWtextBox.UseSystemPasswordChar = true;
            // 
            // LNtextBox
            // 
            this.LNtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LNtextBox.Location = new System.Drawing.Point(60, 33);
            this.LNtextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.LNtextBox.Name = "LNtextBox";
            this.LNtextBox.Size = new System.Drawing.Size(100, 20);
            this.LNtextBox.TabIndex = 4;
            this.LNtextBox.Text = "Six";
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.Location = new System.Drawing.Point(404, 275);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 6;
            this.QuitButton.Text = "Login";
            this.QuitButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(318, 176);
            this.label1.MinimumSize = new System.Drawing.Size(52, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "first name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.MinimumSize = new System.Drawing.Size(52, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "last name";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(2, 55);
            this.label3.MinimumSize = new System.Drawing.Size(52, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "password";
            // 
            // Xbox
            // 
            this.Xbox.Location = new System.Drawing.Point(45, 12);
            this.Xbox.MinimumSize = new System.Drawing.Size(37, 20);
            this.Xbox.Name = "Xbox";
            this.Xbox.Size = new System.Drawing.Size(37, 20);
            this.Xbox.TabIndex = 8;
            this.Xbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ybox
            // 
            this.Ybox.Location = new System.Drawing.Point(235, 311);
            this.Ybox.MinimumSize = new System.Drawing.Size(37, 20);
            this.Ybox.Name = "Ybox";
            this.Ybox.Size = new System.Drawing.Size(37, 20);
            this.Ybox.TabIndex = 9;
            this.Ybox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(134, 337);
            this.MoveButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(75, 23);
            this.MoveButton.TabIndex = 10;
            this.MoveButton.Text = "GoTo";
            this.MoveButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(152, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(215, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y";
            // 
            // chatboxlabel
            // 
            this.chatboxlabel.AutoSize = true;
            this.chatboxlabel.CausesValidation = false;
            this.chatboxlabel.Location = new System.Drawing.Point(12, 5);
            this.chatboxlabel.Name = "chatboxlabel";
            this.chatboxlabel.Size = new System.Drawing.Size(28, 13);
            this.chatboxlabel.TabIndex = 13;
            this.chatboxlabel.Text = "chat";
            // 
            // objectsBox
            // 
            this.objectsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsBox.Location = new System.Drawing.Point(12, 394);
            this.objectsBox.MinimumSize = new System.Drawing.Size(473, 256);
            this.objectsBox.Multiline = true;
            this.objectsBox.Name = "objectsBox";
            this.objectsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.objectsBox.Size = new System.Drawing.Size(473, 256);
            this.objectsBox.TabIndex = 14;
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(12, 205);
            this.locationBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(100, 20);
            this.locationBox.TabIndex = 23;
            this.locationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.CausesValidation = false;
            this.label11.Location = new System.Drawing.Point(318, 234);
            this.label11.MinimumSize = new System.Drawing.Size(30, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "URI";
            // 
            // URIbox
            // 
            this.URIbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.URIbox.Location = new System.Drawing.Point(345, 231);
            this.URIbox.MinimumSize = new System.Drawing.Size(100, 20);
            this.URIbox.Name = "URIbox";
            this.URIbox.Size = new System.Drawing.Size(131, 20);
            this.URIbox.TabIndex = 24;
            this.URIbox.Text = "uri:Master&128&128&25";
            this.URIbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ServerBox);
            this.groupBox1.Controls.Add(this.LNtextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PWtextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(316, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 139);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // turnleftbutton
            // 
            this.turnleftbutton.Location = new System.Drawing.Point(55, 305);
            this.turnleftbutton.MinimumSize = new System.Drawing.Size(0, 23);
            this.turnleftbutton.Name = "turnleftbutton";
            this.turnleftbutton.Size = new System.Drawing.Size(66, 23);
            this.turnleftbutton.TabIndex = 30;
            this.turnleftbutton.Text = "Turn Left";
            this.turnleftbutton.UseVisualStyleBackColor = true;
            // 
            // turnleftbox
            // 
            this.turnleftbox.Location = new System.Drawing.Point(12, 307);
            this.turnleftbox.MinimumSize = new System.Drawing.Size(37, 20);
            this.turnleftbox.Name = "turnleftbox";
            this.turnleftbox.Size = new System.Drawing.Size(37, 20);
            this.turnleftbox.TabIndex = 29;
            this.turnleftbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // turnrightbutton
            // 
            this.turnrightbutton.Location = new System.Drawing.Point(55, 334);
            this.turnrightbutton.MinimumSize = new System.Drawing.Size(0, 23);
            this.turnrightbutton.Name = "turnrightbutton";
            this.turnrightbutton.Size = new System.Drawing.Size(66, 23);
            this.turnrightbutton.TabIndex = 32;
            this.turnrightbutton.Text = "Turn Right";
            this.turnrightbutton.UseVisualStyleBackColor = true;
            // 
            // turnrightbox
            // 
            this.turnrightbox.Location = new System.Drawing.Point(12, 335);
            this.turnrightbox.MinimumSize = new System.Drawing.Size(37, 20);
            this.turnrightbox.Name = "turnrightbox";
            this.turnrightbox.Size = new System.Drawing.Size(37, 20);
            this.turnrightbox.TabIndex = 31;
            this.turnrightbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mycoordinatesbutton
            // 
            this.mycoordinatesbutton.Location = new System.Drawing.Point(12, 225);
            this.mycoordinatesbutton.Name = "mycoordinatesbutton";
            this.mycoordinatesbutton.Size = new System.Drawing.Size(99, 23);
            this.mycoordinatesbutton.TabIndex = 33;
            this.mycoordinatesbutton.Text = "MyCoordinates";
            this.mycoordinatesbutton.UseVisualStyleBackColor = true;
            // 
            // readchatbutton
            // 
            this.readchatbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readchatbutton.Location = new System.Drawing.Point(235, 190);
            this.readchatbutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.readchatbutton.Name = "readchatbutton";
            this.readchatbutton.Size = new System.Drawing.Size(75, 23);
            this.readchatbutton.TabIndex = 34;
            this.readchatbutton.Text = "ReadChat";
            this.readchatbutton.UseVisualStyleBackColor = true;
            // 
            // goforwardbutton
            // 
            this.goforwardbutton.Location = new System.Drawing.Point(136, 269);
            this.goforwardbutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.goforwardbutton.Name = "goforwardbutton";
            this.goforwardbutton.Size = new System.Drawing.Size(75, 23);
            this.goforwardbutton.TabIndex = 35;
            this.goforwardbutton.Text = "Go Forward";
            this.goforwardbutton.UseVisualStyleBackColor = true;
            // 
            // goforwardbox
            // 
            this.goforwardbox.Location = new System.Drawing.Point(159, 249);
            this.goforwardbox.MinimumSize = new System.Drawing.Size(37, 20);
            this.goforwardbox.Name = "goforwardbox";
            this.goforwardbox.Size = new System.Drawing.Size(37, 20);
            this.goforwardbox.TabIndex = 36;
            this.goforwardbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gobackwardbox
            // 
            this.gobackwardbox.Location = new System.Drawing.Point(248, 249);
            this.gobackwardbox.MinimumSize = new System.Drawing.Size(37, 20);
            this.gobackwardbox.Name = "gobackwardbox";
            this.gobackwardbox.Size = new System.Drawing.Size(37, 20);
            this.gobackwardbox.TabIndex = 38;
            this.gobackwardbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gobackwardbutton
            // 
            this.gobackwardbutton.Location = new System.Drawing.Point(217, 269);
            this.gobackwardbutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.gobackwardbutton.Name = "gobackwardbutton";
            this.gobackwardbutton.Size = new System.Drawing.Size(90, 23);
            this.gobackwardbutton.TabIndex = 37;
            this.gobackwardbutton.Text = "Go Backward";
            this.gobackwardbutton.UseVisualStyleBackColor = true;
            // 
            // turntowardbutton
            // 
            this.turntowardbutton.Location = new System.Drawing.Point(83, 38);
            this.turntowardbutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.turntowardbutton.Name = "turntowardbutton";
            this.turntowardbutton.Size = new System.Drawing.Size(75, 23);
            this.turntowardbutton.TabIndex = 39;
            this.turntowardbutton.Text = "TurnToward";
            this.turntowardbutton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Xbox);
            this.groupBox2.Controls.Add(this.turntowardbutton);
            this.groupBox2.Location = new System.Drawing.Point(127, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 69);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // LookButton
            // 
            this.LookButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LookButton.Location = new System.Drawing.Point(398, 365);
            this.LookButton.Name = "LookButton";
            this.LookButton.Size = new System.Drawing.Size(87, 23);
            this.LookButton.TabIndex = 42;
            this.LookButton.Text = "ObjectsAround";
            this.LookButton.UseVisualStyleBackColor = true;
            // 
            // myrotationbutton
            // 
            this.myrotationbutton.Location = new System.Drawing.Point(12, 272);
            this.myrotationbutton.Name = "myrotationbutton";
            this.myrotationbutton.Size = new System.Drawing.Size(99, 23);
            this.myrotationbutton.TabIndex = 46;
            this.myrotationbutton.Text = "MyRotation";
            this.myrotationbutton.UseVisualStyleBackColor = true;
            // 
            // rotationBox
            // 
            this.rotationBox.Location = new System.Drawing.Point(12, 252);
            this.rotationBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.rotationBox.Name = "rotationBox";
            this.rotationBox.ReadOnly = true;
            this.rotationBox.Size = new System.Drawing.Size(100, 20);
            this.rotationBox.TabIndex = 45;
            this.rotationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // readmessagebutton
            // 
            this.readmessagebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readmessagebutton.Location = new System.Drawing.Point(139, 190);
            this.readmessagebutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.readmessagebutton.Name = "readmessagebutton";
            this.readmessagebutton.Size = new System.Drawing.Size(90, 23);
            this.readmessagebutton.TabIndex = 48;
            this.readmessagebutton.Text = "ReadMessage";
            this.readmessagebutton.UseVisualStyleBackColor = true;
            // 
            // saymessagebutton
            // 
            this.saymessagebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saymessagebutton.Location = new System.Drawing.Point(139, 216);
            this.saymessagebutton.MinimumSize = new System.Drawing.Size(75, 23);
            this.saymessagebutton.Name = "saymessagebutton";
            this.saymessagebutton.Size = new System.Drawing.Size(90, 23);
            this.saymessagebutton.TabIndex = 47;
            this.saymessagebutton.Text = "SayMessage";
            this.saymessagebutton.UseVisualStyleBackColor = true;
            // 
            // objectidbox
            // 
            this.objectidbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objectidbox.Location = new System.Drawing.Point(376, 311);
            this.objectidbox.Name = "objectidbox";
            this.objectidbox.Size = new System.Drawing.Size(16, 20);
            this.objectidbox.TabIndex = 49;
            // 
            // dropobjectbutton
            // 
            this.dropobjectbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dropobjectbutton.Location = new System.Drawing.Point(398, 337);
            this.dropobjectbutton.Name = "dropobjectbutton";
            this.dropobjectbutton.Size = new System.Drawing.Size(87, 23);
            this.dropobjectbutton.TabIndex = 50;
            this.dropobjectbutton.Text = "DropObject";
            this.dropobjectbutton.UseVisualStyleBackColor = true;
            // 
            // takeobjectbutton
            // 
            this.takeobjectbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.takeobjectbutton.Location = new System.Drawing.Point(398, 311);
            this.takeobjectbutton.Name = "takeobjectbutton";
            this.takeobjectbutton.Size = new System.Drawing.Size(87, 23);
            this.takeobjectbutton.TabIndex = 51;
            this.takeobjectbutton.Text = "TakeObject";
            this.takeobjectbutton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.CausesValidation = false;
            this.label6.Location = new System.Drawing.Point(306, 316);
            this.label6.MinimumSize = new System.Drawing.Size(52, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "object index";
            // 
            // AutoButton
            // 
            this.AutoButton.Location = new System.Drawing.Point(309, 347);
            this.AutoButton.Name = "AutoButton";
            this.AutoButton.Size = new System.Drawing.Size(75, 41);
            this.AutoButton.TabIndex = 53;
            this.AutoButton.Text = "Auto";
            this.AutoButton.UseVisualStyleBackColor = true;
            // 
            // ServerBox
            // 
            this.ServerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerBox.Location = new System.Drawing.Point(0, 92);
            this.ServerBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.ServerBox.Name = "ServerBox";
            this.ServerBox.Size = new System.Drawing.Size(169, 20);
            this.ServerBox.TabIndex = 25;
            this.ServerBox.Text = "http://localhost:9000";
            this.ServerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Location = new System.Drawing.Point(-3, 110);
            this.label7.MinimumSize = new System.Drawing.Size(30, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Server";
            // 
            // BotControlForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 656);
            this.Controls.Add(this.AutoButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.takeobjectbutton);
            this.Controls.Add(this.dropobjectbutton);
            this.Controls.Add(this.objectidbox);
            this.Controls.Add(this.readmessagebutton);
            this.Controls.Add(this.saymessagebutton);
            this.Controls.Add(this.myrotationbutton);
            this.Controls.Add(this.rotationBox);
            this.Controls.Add(this.LookButton);
            this.Controls.Add(this.gobackwardbox);
            this.Controls.Add(this.gobackwardbutton);
            this.Controls.Add(this.goforwardbox);
            this.Controls.Add(this.goforwardbutton);
            this.Controls.Add(this.readchatbutton);
            this.Controls.Add(this.mycoordinatesbutton);
            this.Controls.Add(this.turnrightbutton);
            this.Controls.Add(this.turnrightbox);
            this.Controls.Add(this.turnleftbutton);
            this.Controls.Add(this.turnleftbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.locationBox);
            this.Controls.Add(this.objectsBox);
            this.Controls.Add(this.chatboxlabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.Ybox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FNtextBox);
            this.Controls.Add(this.saychatbutton);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.URIbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.MinimumSize = new System.Drawing.Size(505, 686);
            this.Name = "BotControlForm1";
            this.Text = "BotControlForm1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button saychatbutton;
        private System.Windows.Forms.TextBox FNtextBox;
        private System.Windows.Forms.TextBox PWtextBox;
        private System.Windows.Forms.TextBox LNtextBox;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Xbox;
        private System.Windows.Forms.TextBox Ybox;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label chatboxlabel;
        private System.Windows.Forms.TextBox objectsBox;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox URIbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button turnleftbutton;
        private System.Windows.Forms.TextBox turnleftbox;
        private System.Windows.Forms.Button turnrightbutton;
        private System.Windows.Forms.TextBox turnrightbox;
        private System.Windows.Forms.Button mycoordinatesbutton;
        private System.Windows.Forms.Button readchatbutton;
        private System.Windows.Forms.Button goforwardbutton;
        private System.Windows.Forms.TextBox goforwardbox;
        private System.Windows.Forms.TextBox gobackwardbox;
        private System.Windows.Forms.Button gobackwardbutton;
        private System.Windows.Forms.Button turntowardbutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LookButton;
        private System.Windows.Forms.Button myrotationbutton;
        private System.Windows.Forms.TextBox rotationBox;
        private System.Windows.Forms.Button readmessagebutton;
        private System.Windows.Forms.Button saymessagebutton;
        private System.Windows.Forms.TextBox objectidbox;
        private System.Windows.Forms.Button dropobjectbutton;
        private System.Windows.Forms.Button takeobjectbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AutoButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ServerBox;
    }
}