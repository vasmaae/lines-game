namespace IntroductoryEducationalPractice
{
    partial class FormGame
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
            labelCountOfPoints = new Label();
            labelNextStep = new Label();
            buttonNewGame = new Button();
            pictureBoxGame = new PictureBox();
            pictureBoxNextStep = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGame).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextStep).BeginInit();
            SuspendLayout();
            // 
            // labelCountOfPoints
            // 
            labelCountOfPoints.AutoSize = true;
            labelCountOfPoints.Font = new Font("Segoe UI", 23F);
            labelCountOfPoints.Location = new Point(559, 12);
            labelCountOfPoints.Name = "labelCountOfPoints";
            labelCountOfPoints.Size = new Size(35, 42);
            labelCountOfPoints.TabIndex = 81;
            labelCountOfPoints.Text = "0";
            // 
            // labelNextStep
            // 
            labelNextStep.AutoSize = true;
            labelNextStep.Location = new Point(559, 91);
            labelNextStep.Name = "labelNextStep";
            labelNextStep.Size = new Size(97, 15);
            labelNextStep.TabIndex = 82;
            labelNextStep.Text = "Следующий ход";
            // 
            // buttonNewGame
            // 
            buttonNewGame.Location = new Point(559, 280);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(180, 23);
            buttonNewGame.TabIndex = 86;
            buttonNewGame.Text = "Новая игра";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += ButtonNewGame_Click;
            // 
            // pictureBoxGame
            // 
            pictureBoxGame.Location = new Point(12, 12);
            pictureBoxGame.Name = "pictureBoxGame";
            pictureBoxGame.Size = new Size(541, 541);
            pictureBoxGame.TabIndex = 87;
            pictureBoxGame.TabStop = false;
            pictureBoxGame.MouseClick += PictureBoxGame_Click;
            // 
            // pictureBoxNextStep
            // 
            pictureBoxNextStep.Location = new Point(559, 109);
            pictureBoxNextStep.Name = "pictureBoxNextStep";
            pictureBoxNextStep.Size = new Size(181, 61);
            pictureBoxNextStep.TabIndex = 88;
            pictureBoxNextStep.TabStop = false;
            // 
            // FormGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 566);
            Controls.Add(pictureBoxNextStep);
            Controls.Add(pictureBoxGame);
            Controls.Add(buttonNewGame);
            Controls.Add(labelNextStep);
            Controls.Add(labelCountOfPoints);
            Name = "FormGame";
            Text = "FormGame";
            ((System.ComponentModel.ISupportInitialize)pictureBoxGame).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextStep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelCountOfPoints;
        private Label labelNextStep;
        private Button buttonNewGame;
        private PictureBox pictureBoxGame;
        private PictureBox pictureBoxNextStep;
    }
}