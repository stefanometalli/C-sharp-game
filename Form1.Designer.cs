using WindowsForm.Classes;

namespace WindowsForm;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        GameLoop = new System.Windows.Forms.Timer(components);
        btnRestart = new NoSpaceClickButton();
        lblScore = new Label();
        SuspendLayout();
        // 
        // GameLoop
        // 
        GameLoop.Enabled = true;
        GameLoop.Interval = 30;
        GameLoop.Tick += GameLoop_Tick;
        // 
        // btnRestart
        // 
        btnRestart.BackColor = Color.Transparent;
        btnRestart.BackgroundImage = (Image)resources.GetObject("btnRestart.BackgroundImage");
        btnRestart.BackgroundImageLayout = ImageLayout.Stretch;
        btnRestart.FlatAppearance.BorderSize = 0;
        btnRestart.FlatStyle = FlatStyle.Flat;
        btnRestart.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnRestart.ForeColor = Color.Transparent;
        btnRestart.Location = new Point(391, 536);
        btnRestart.Margin = new Padding(6, 5, 6, 5);
        btnRestart.Name = "btnRestart";
        btnRestart.Size = new Size(277, 75);
        btnRestart.TabIndex = 0;
        btnRestart.Text = "RESTART";
        btnRestart.UseVisualStyleBackColor = false;
        btnRestart.Click += btnRestart_Click;
        // 
        // lblScore
        // 
        lblScore.AutoSize = true;
        lblScore.BackColor = SystemColors.WindowFrame;
        lblScore.ForeColor = Color.White;
        lblScore.Location = new Point(728, 51);
        lblScore.Name = "lblScore";
        lblScore.Size = new Size(223, 60);
        lblScore.TabIndex = 1;
        lblScore.Text = "Score:0";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(32F, 59F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(992, 680);
        Controls.Add(lblScore);
        Controls.Add(btnRestart);
        Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(6, 5, 6, 5);
        Name = "Form1";
        Text = "Space Fight";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Timer GameLoop;
    private NoSpaceClickButton btnRestart;
    private Label lblScore;
}


