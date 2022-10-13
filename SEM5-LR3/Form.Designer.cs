namespace SEM5_LR3
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonCurve = new System.Windows.Forms.RadioButton();
            this.panelPainter = new System.Windows.Forms.Panel();
            this.buttonClip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPainter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(775, 396);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(13, 416);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 29);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(3, 3);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(69, 17);
            this.radioButtonRectangle.TabIndex = 3;
            this.radioButtonRectangle.Text = "rectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            this.radioButtonRectangle.CheckedChanged += new System.EventHandler(this.radioButtonRectangle_CheckedChanged);
            // 
            // radioButtonCurve
            // 
            this.radioButtonCurve.AutoSize = true;
            this.radioButtonCurve.Checked = true;
            this.radioButtonCurve.Location = new System.Drawing.Point(109, 3);
            this.radioButtonCurve.Name = "radioButtonCurve";
            this.radioButtonCurve.Size = new System.Drawing.Size(52, 17);
            this.radioButtonCurve.TabIndex = 4;
            this.radioButtonCurve.TabStop = true;
            this.radioButtonCurve.Text = "curve";
            this.radioButtonCurve.UseVisualStyleBackColor = true;
            this.radioButtonCurve.CheckedChanged += new System.EventHandler(this.radioButtonCurve_CheckedChanged);
            // 
            // panelPainter
            // 
            this.panelPainter.Controls.Add(this.radioButtonRectangle);
            this.panelPainter.Controls.Add(this.radioButtonCurve);
            this.panelPainter.Location = new System.Drawing.Point(591, 418);
            this.panelPainter.Name = "panelPainter";
            this.panelPainter.Size = new System.Drawing.Size(197, 27);
            this.panelPainter.TabIndex = 5;
            // 
            // buttonClip
            // 
            this.buttonClip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClip.Location = new System.Drawing.Point(446, 416);
            this.buttonClip.Name = "buttonClip";
            this.buttonClip.Size = new System.Drawing.Size(120, 29);
            this.buttonClip.TabIndex = 6;
            this.buttonClip.Text = "clip";
            this.buttonClip.UseVisualStyleBackColor = true;
            this.buttonClip.Click += new System.EventHandler(this.buttonClip_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 492);
            this.Controls.Add(this.buttonClip);
            this.Controls.Add(this.panelPainter);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form";
            this.Text = "Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelPainter.ResumeLayout(false);
            this.panelPainter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
        private System.Windows.Forms.RadioButton radioButtonCurve;
        private System.Windows.Forms.Panel panelPainter;
        private System.Windows.Forms.Button buttonClip;
    }
}

