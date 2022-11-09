namespace SEM5_LR4
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
            this.panelPainter = new System.Windows.Forms.Panel();
            this.radioButtonPolygon = new System.Windows.Forms.RadioButton();
            this.radioButtonPolyline = new System.Windows.Forms.RadioButton();
            this.buttonClip = new System.Windows.Forms.Button();
            this.buttonDrawPolygon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPainter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(776, 379);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(311, 399);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(101, 30);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panelPainter
            // 
            this.panelPainter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelPainter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPainter.Controls.Add(this.radioButtonPolygon);
            this.panelPainter.Controls.Add(this.radioButtonPolyline);
            this.panelPainter.Location = new System.Drawing.Point(12, 399);
            this.panelPainter.Name = "panelPainter";
            this.panelPainter.Size = new System.Drawing.Size(175, 29);
            this.panelPainter.TabIndex = 2;
            // 
            // radioButtonPolygon
            // 
            this.radioButtonPolygon.AutoSize = true;
            this.radioButtonPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPolygon.Location = new System.Drawing.Point(94, 3);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(76, 21);
            this.radioButtonPolygon.TabIndex = 1;
            this.radioButtonPolygon.TabStop = true;
            this.radioButtonPolygon.Text = "polygon";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            this.radioButtonPolygon.CheckedChanged += new System.EventHandler(this.radioButtonPolygon_CheckedChanged);
            // 
            // radioButtonPolyline
            // 
            this.radioButtonPolyline.AutoSize = true;
            this.radioButtonPolyline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPolyline.Location = new System.Drawing.Point(3, 3);
            this.radioButtonPolyline.Name = "radioButtonPolyline";
            this.radioButtonPolyline.Size = new System.Drawing.Size(74, 21);
            this.radioButtonPolyline.TabIndex = 0;
            this.radioButtonPolyline.TabStop = true;
            this.radioButtonPolyline.Text = "polyline";
            this.radioButtonPolyline.UseVisualStyleBackColor = true;
            this.radioButtonPolyline.CheckedChanged += new System.EventHandler(this.radioButtonPolyline_CheckedChanged);
            // 
            // buttonClip
            // 
            this.buttonClip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClip.Location = new System.Drawing.Point(687, 399);
            this.buttonClip.Name = "buttonClip";
            this.buttonClip.Size = new System.Drawing.Size(101, 30);
            this.buttonClip.TabIndex = 3;
            this.buttonClip.Text = "clip";
            this.buttonClip.UseVisualStyleBackColor = true;
            this.buttonClip.Click += new System.EventHandler(this.buttonClip_Click);
            // 
            // buttonDrawPolygon
            // 
            this.buttonDrawPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrawPolygon.Location = new System.Drawing.Point(193, 399);
            this.buttonDrawPolygon.Name = "buttonDrawPolygon";
            this.buttonDrawPolygon.Size = new System.Drawing.Size(101, 30);
            this.buttonDrawPolygon.TabIndex = 6;
            this.buttonDrawPolygon.Text = "draw";
            this.buttonDrawPolygon.UseVisualStyleBackColor = true;
            this.buttonDrawPolygon.Click += new System.EventHandler(this.buttonDrawPolygon_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 462);
            this.Controls.Add(this.buttonDrawPolygon);
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
        private System.Windows.Forms.Panel panelPainter;
        private System.Windows.Forms.RadioButton radioButtonPolyline;
        private System.Windows.Forms.Button buttonClip;
        private System.Windows.Forms.RadioButton radioButtonPolygon;
        private System.Windows.Forms.Button buttonDrawPolygon;
    }
}

