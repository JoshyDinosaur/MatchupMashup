namespace MatchupMashup
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.addTeamButton = new System.Windows.Forms.Button();
            this.fetchNFLDataButton = new System.Windows.Forms.Button();
            this.createMatchupButton = new System.Windows.Forms.Button();
            this.teamsDataGridView = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            
            // Button setup
            this.addTeamButton.Location = new System.Drawing.Point(12, 12);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(100, 30);
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            
            // DataGridView setup
            this.teamsDataGridView.Location = new System.Drawing.Point(12, 50);
            this.teamsDataGridView.Size = new System.Drawing.Size(800, 400);
            this.teamsDataGridView.Name = "teamsDataGridView";
            
            // Form setup
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 461);
            this.Controls.Add(this.teamsDataGridView);
            this.Controls.Add(this.addTeamButton);
            this.Name = "MainForm";
            this.Text = "MatchupMashup";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Button fetchNFLDataButton;
        private System.Windows.Forms.Button createMatchupButton;
        private System.Windows.Forms.DataGridView teamsDataGridView;
    }
}