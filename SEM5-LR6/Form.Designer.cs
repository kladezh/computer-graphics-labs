namespace SEM5_LR6
{
    partial class Form
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelPainter = new System.Windows.Forms.Panel();
            this.radioButtonFill = new System.Windows.Forms.RadioButton();
            this.radioButtonPolygon = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPainter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(776, 392);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // panelPainter
            // 
            this.panelPainter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelPainter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPainter.Controls.Add(this.radioButtonFill);
            this.panelPainter.Controls.Add(this.radioButtonPolygon);
            this.panelPainter.Location = new System.Drawing.Point(12, 410);
            this.panelPainter.Name = "panelPainter";
            this.panelPainter.Size = new System.Drawing.Size(135, 29);
            this.panelPainter.TabIndex = 6;
            // 
            // radioButtonFill
            // 
            this.radioButtonFill.AutoSize = true;
            this.radioButtonFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFill.Location = new System.Drawing.Point(85, 4);
            this.radioButtonFill.Name = "radioButtonFill";
            this.radioButtonFill.Size = new System.Drawing.Size(39, 21);
            this.radioButtonFill.TabIndex = 1;
            this.radioButtonFill.Text = "fill";
            this.radioButtonFill.UseVisualStyleBackColor = true;
            this.radioButtonFill.CheckedChanged += new System.EventHandler(this.radioButtonFill_CheckedChanged);
            // 
            // radioButtonPolygon
            // 
            this.radioButtonPolygon.AutoSize = true;
            this.radioButtonPolygon.Checked = true;
            this.radioButtonPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPolygon.Location = new System.Drawing.Point(3, 3);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(76, 21);
            this.radioButtonPolygon.TabIndex = 0;
            this.radioButtonPolygon.TabStop = true;
            this.radioButtonPolygon.Text = "polygon";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            this.radioButtonPolygon.CheckedChanged += new System.EventHandler(this.radioButtonPolygon_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(687, 410);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(101, 30);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPainter);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form";
            this.Text = "Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelPainter.ResumeLayout(false);
            this.panelPainter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelPainter;
        private System.Windows.Forms.RadioButton radioButtonFill;
        private System.Windows.Forms.RadioButton radioButtonPolygon;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
    }
}

