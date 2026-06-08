using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BoholBusTicketingApp
{
    partial class ConductorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.passengerTextBox = new System.Windows.Forms.TextBox();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.fareLabel = new System.Windows.Forms.Label();
            this.calculateFareButton = new System.Windows.Forms.Button();
            this.printTicketButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // fromComboBox
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(100, 50);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(150, 21);
            this.fromComboBox.TabIndex = 0;
            
            // toComboBox
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Location = new System.Drawing.Point(100, 100);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(150, 21);
            this.toComboBox.TabIndex = 1;
            
            // passengerTextBox
            this.passengerTextBox.Location = new System.Drawing.Point(100, 150);
            this.passengerTextBox.Name = "passengerTextBox";
            this.passengerTextBox.Size = new System.Drawing.Size(150, 20);
            this.passengerTextBox.TabIndex = 2;
            
            // distanceLabel
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(100, 200);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(60, 13);
            this.distanceLabel.TabIndex = 3;
            this.distanceLabel.Text = "Distance: 0 km";
            
            // fareLabel
            this.fareLabel.AutoSize = true;
            this.fareLabel.Location = new System.Drawing.Point(100, 230);
            this.fareLabel.Name = "fareLabel";
            this.fareLabel.Size = new System.Drawing.Size(50, 13);
            this.fareLabel.TabIndex = 4;
            this.fareLabel.Text = "Fare: P0";
            
            // calculateFareButton
            this.calculateFareButton.Location = new System.Drawing.Point(100, 270);
            this.calculateFareButton.Name = "calculateFareButton";
            this.calculateFareButton.Size = new System.Drawing.Size(100, 23);
            this.calculateFareButton.TabIndex = 5;
            this.calculateFareButton.Text = "Calculate Fare";
            this.calculateFareButton.UseVisualStyleBackColor = true;
            this.calculateFareButton.Click += new System.EventHandler(this.CalculateFareButton_Click);
            
            // printTicketButton
            this.printTicketButton.Location = new System.Drawing.Point(210, 270);
            this.printTicketButton.Name = "printTicketButton";
            this.printTicketButton.Size = new System.Drawing.Size(100, 23);
            this.printTicketButton.TabIndex = 6;
            this.printTicketButton.Text = "Print Ticket";
            this.printTicketButton.UseVisualStyleBackColor = true;
            this.printTicketButton.Click += new System.EventHandler(this.PrintTicketButton_Click);
            
            // inventoryButton
            this.inventoryButton.Location = new System.Drawing.Point(320, 270);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(100, 23);
            this.inventoryButton.TabIndex = 7;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = true;
            this.inventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            
            // ConductorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.printTicketButton);
            this.Controls.Add(this.calculateFareButton);
            this.Controls.Add(this.fareLabel);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.passengerTextBox);
            this.Controls.Add(this.toComboBox);
            this.Controls.Add(this.fromComboBox);
            this.Name = "ConductorForm";
            this.Text = "Conductor - Bus Ticketing";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.TextBox passengerTextBox;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Label fareLabel;
        private System.Windows.Forms.Button calculateFareButton;
        private System.Windows.Forms.Button printTicketButton;
        private System.Windows.Forms.Button inventoryButton;
    }
}
