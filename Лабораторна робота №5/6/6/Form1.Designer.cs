
namespace _6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Run = new System.Windows.Forms.Button();
            this.row = new System.Windows.Forms.TextBox();
            this.col = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Replay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaxBox = new System.Windows.Forms.TextBox();
            this.MinBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.BackColor = System.Drawing.Color.Aquamarine;
            this.Run.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Run.Location = new System.Drawing.Point(34, 157);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(102, 39);
            this.Run.TabIndex = 0;
            this.Run.Text = "ОК";
            this.Run.UseVisualStyleBackColor = false;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // row
            // 
            this.row.Location = new System.Drawing.Point(120, 35);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(63, 27);
            this.row.TabIndex = 1;
            this.row.Text = "1";
            this.row.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // col
            // 
            this.col.Location = new System.Drawing.Point(120, 80);
            this.col.Name = "col";
            this.col.Size = new System.Drawing.Size(63, 27);
            this.col.TabIndex = 2;
            this.col.Text = "1";
            this.col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Колонки";
            // 
            // Replay
            // 
            this.Replay.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Replay.Location = new System.Drawing.Point(183, 157);
            this.Replay.Name = "Replay";
            this.Replay.Size = new System.Drawing.Size(124, 39);
            this.Replay.TabIndex = 7;
            this.Replay.Text = "Перезапуск";
            this.Replay.UseVisualStyleBackColor = true;
            this.Replay.Click += new System.EventHandler(this.Replay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(580, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Рядки";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.MaxBox);
            this.groupBox1.Controls.Add(this.MinBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.row);
            this.groupBox1.Controls.Add(this.col);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Значення";
            // 
            // MaxBox
            // 
            this.MaxBox.Location = new System.Drawing.Point(359, 80);
            this.MaxBox.Name = "MaxBox";
            this.MaxBox.Size = new System.Drawing.Size(63, 27);
            this.MaxBox.TabIndex = 13;
            this.MaxBox.Text = "20";
            this.MaxBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinBox
            // 
            this.MinBox.Location = new System.Drawing.Point(359, 32);
            this.MinBox.Name = "MinBox";
            this.MinBox.Size = new System.Drawing.Size(63, 27);
            this.MinBox.TabIndex = 12;
            this.MinBox.Text = "1";
            this.MinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(322, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "До";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(238, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Діапазон від";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.LightSalmon;
            this.Exit.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(349, 157);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(102, 39);
            this.Exit.TabIndex = 11;
            this.Exit.Text = "Вихід";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(476, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "Елементи, що сортуються\r\nпозначені";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(580, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "червоним";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(476, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 115);
            this.label8.TabIndex = 14;
            this.label8.Text = "Інші елементи зберігають\r\nсвої позиції та позначені \r\nчорним\r\n\r\n ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 220);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Replay);
            this.Controls.Add(this.Run);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "ЛР5 Максимова";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.TextBox row;
        private System.Windows.Forms.TextBox col;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Replay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox MaxBox;
        private System.Windows.Forms.TextBox MinBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

