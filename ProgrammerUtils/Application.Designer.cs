﻿namespace ProgrammerUtils
{
    partial class Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.SortTab = new System.Windows.Forms.TabPage();
            this.SortTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sortLabel2 = new System.Windows.Forms.Label();
            this.sortTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.sortTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.sortLabel1 = new System.Windows.Forms.Label();
            this.sortHeader = new System.Windows.Forms.TableLayoutPanel();
            this.SortButton = new System.Windows.Forms.Button();
            this.AutoSortCheckbox = new System.Windows.Forms.CheckBox();
            this.sortModeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sortAlphabeticlyRadio = new System.Windows.Forms.RadioButton();
            this.notSortAlphabeticlyRadio = new System.Windows.Forms.RadioButton();
            this.sortStyleTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.MatchTab = new System.Windows.Forms.TabPage();
            this.CountTab = new System.Windows.Forms.TabPage();
            this.htmlTab = new System.Windows.Forms.TabPage();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.asdasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aasdasdasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayout.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.SortTab.SuspendLayout();
            this.SortTableLayout.SuspendLayout();
            this.sortHeader.SuspendLayout();
            this.sortModeTableLayout.SuspendLayout();
            this.sortStyleTableLayout.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayout.Controls.Add(this.MainTabControl, 0, 1);
            this.MainTableLayout.Controls.Add(this.Toolbar, 0, 0);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Size = new System.Drawing.Size(904, 534);
            this.MainTableLayout.TabIndex = 0;
            // 
            // MainTabControl
            // 
            this.MainTableLayout.SetColumnSpan(this.MainTabControl, 2);
            this.MainTabControl.Controls.Add(this.SortTab);
            this.MainTabControl.Controls.Add(this.MatchTab);
            this.MainTabControl.Controls.Add(this.CountTab);
            this.MainTabControl.Controls.Add(this.htmlTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(3, 33);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(898, 498);
            this.MainTabControl.TabIndex = 0;
            // 
            // SortTab
            // 
            this.SortTab.Controls.Add(this.SortTableLayout);
            this.SortTab.Location = new System.Drawing.Point(4, 25);
            this.SortTab.Name = "SortTab";
            this.SortTab.Padding = new System.Windows.Forms.Padding(3);
            this.SortTab.Size = new System.Drawing.Size(890, 469);
            this.SortTab.TabIndex = 0;
            this.SortTab.Text = "Sort";
            this.SortTab.UseVisualStyleBackColor = true;
            // 
            // SortTableLayout
            // 
            this.SortTableLayout.ColumnCount = 2;
            this.SortTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SortTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SortTableLayout.Controls.Add(this.sortLabel2, 1, 2);
            this.SortTableLayout.Controls.Add(this.sortTextBoxLeft, 0, 1);
            this.SortTableLayout.Controls.Add(this.sortTextBoxRight, 1, 1);
            this.SortTableLayout.Controls.Add(this.sortLabel1, 0, 2);
            this.SortTableLayout.Controls.Add(this.sortHeader, 0, 0);
            this.SortTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortTableLayout.Location = new System.Drawing.Point(3, 3);
            this.SortTableLayout.Name = "SortTableLayout";
            this.SortTableLayout.RowCount = 3;
            this.SortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.SortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SortTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SortTableLayout.Size = new System.Drawing.Size(884, 463);
            this.SortTableLayout.TabIndex = 0;
            // 
            // sortLabel2
            // 
            this.sortLabel2.AutoSize = true;
            this.sortLabel2.BackColor = System.Drawing.Color.Lavender;
            this.sortLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sortLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortLabel2.Location = new System.Drawing.Point(445, 424);
            this.sortLabel2.Name = "sortLabel2";
            this.sortLabel2.Size = new System.Drawing.Size(436, 39);
            this.sortLabel2.TabIndex = 3;
            this.sortLabel2.Text = "Sorted items.";
            this.sortLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sortTextBoxLeft
            // 
            this.sortTextBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortTextBoxLeft.Location = new System.Drawing.Point(3, 55);
            this.sortTextBoxLeft.Name = "sortTextBoxLeft";
            this.sortTextBoxLeft.Size = new System.Drawing.Size(436, 366);
            this.sortTextBoxLeft.TabIndex = 0;
            this.sortTextBoxLeft.Text = "";
            // 
            // sortTextBoxRight
            // 
            this.sortTextBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortTextBoxRight.Location = new System.Drawing.Point(445, 55);
            this.sortTextBoxRight.Name = "sortTextBoxRight";
            this.sortTextBoxRight.ReadOnly = true;
            this.sortTextBoxRight.Size = new System.Drawing.Size(436, 366);
            this.sortTextBoxRight.TabIndex = 1;
            this.sortTextBoxRight.Text = "";
            // 
            // sortLabel1
            // 
            this.sortLabel1.AutoSize = true;
            this.sortLabel1.BackColor = System.Drawing.Color.Lavender;
            this.sortLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sortLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortLabel1.Location = new System.Drawing.Point(3, 424);
            this.sortLabel1.Name = "sortLabel1";
            this.sortLabel1.Padding = new System.Windows.Forms.Padding(10);
            this.sortLabel1.Size = new System.Drawing.Size(436, 39);
            this.sortLabel1.TabIndex = 2;
            this.sortLabel1.Text = "Items to sort. Seperate words by commas!";
            this.sortLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sortHeader
            // 
            this.sortHeader.ColumnCount = 3;
            this.SortTableLayout.SetColumnSpan(this.sortHeader, 2);
            this.sortHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.sortHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.sortHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.sortHeader.Controls.Add(this.SortButton, 0, 0);
            this.sortHeader.Controls.Add(this.AutoSortCheckbox, 1, 0);
            this.sortHeader.Controls.Add(this.sortModeTableLayout, 2, 0);
            this.sortHeader.Controls.Add(this.sortStyleTableLayout, 2, 1);
            this.sortHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortHeader.Location = new System.Drawing.Point(0, 0);
            this.sortHeader.Margin = new System.Windows.Forms.Padding(0);
            this.sortHeader.Name = "sortHeader";
            this.sortHeader.RowCount = 2;
            this.sortHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortHeader.Size = new System.Drawing.Size(884, 52);
            this.sortHeader.TabIndex = 4;
            // 
            // SortButton
            // 
            this.SortButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SortButton.Location = new System.Drawing.Point(3, 3);
            this.SortButton.Name = "SortButton";
            this.sortHeader.SetRowSpan(this.SortButton, 2);
            this.SortButton.Size = new System.Drawing.Size(194, 46);
            this.SortButton.TabIndex = 0;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = false;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // AutoSortCheckbox
            // 
            this.AutoSortCheckbox.AutoSize = true;
            this.AutoSortCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoSortCheckbox.Location = new System.Drawing.Point(203, 3);
            this.AutoSortCheckbox.Name = "AutoSortCheckbox";
            this.sortHeader.SetRowSpan(this.AutoSortCheckbox, 2);
            this.AutoSortCheckbox.Size = new System.Drawing.Size(194, 46);
            this.AutoSortCheckbox.TabIndex = 1;
            this.AutoSortCheckbox.Text = "Auto Sort";
            this.AutoSortCheckbox.UseVisualStyleBackColor = true;
            // 
            // sortModeTableLayout
            // 
            this.sortModeTableLayout.ColumnCount = 2;
            this.sortModeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortModeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortModeTableLayout.Controls.Add(this.sortAlphabeticlyRadio, 0, 0);
            this.sortModeTableLayout.Controls.Add(this.notSortAlphabeticlyRadio, 1, 0);
            this.sortModeTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortModeTableLayout.Location = new System.Drawing.Point(400, 0);
            this.sortModeTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.sortModeTableLayout.Name = "sortModeTableLayout";
            this.sortModeTableLayout.RowCount = 1;
            this.sortModeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sortModeTableLayout.Size = new System.Drawing.Size(484, 26);
            this.sortModeTableLayout.TabIndex = 4;
            // 
            // sortAlphabeticlyRadio
            // 
            this.sortAlphabeticlyRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sortAlphabeticlyRadio.AutoSize = true;
            this.sortAlphabeticlyRadio.Checked = true;
            this.sortAlphabeticlyRadio.Location = new System.Drawing.Point(3, 3);
            this.sortAlphabeticlyRadio.Name = "sortAlphabeticlyRadio";
            this.sortAlphabeticlyRadio.Size = new System.Drawing.Size(116, 20);
            this.sortAlphabeticlyRadio.TabIndex = 2;
            this.sortAlphabeticlyRadio.TabStop = true;
            this.sortAlphabeticlyRadio.Text = "Alphabetically";
            this.sortAlphabeticlyRadio.UseVisualStyleBackColor = true;
            // 
            // notSortAlphabeticlyRadio
            // 
            this.notSortAlphabeticlyRadio.AutoSize = true;
            this.notSortAlphabeticlyRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notSortAlphabeticlyRadio.Location = new System.Drawing.Point(245, 3);
            this.notSortAlphabeticlyRadio.Name = "notSortAlphabeticlyRadio";
            this.notSortAlphabeticlyRadio.Size = new System.Drawing.Size(236, 20);
            this.notSortAlphabeticlyRadio.TabIndex = 3;
            this.notSortAlphabeticlyRadio.Text = "Reverse";
            this.notSortAlphabeticlyRadio.UseVisualStyleBackColor = true;
            // 
            // sortStyleTableLayout
            // 
            this.sortStyleTableLayout.ColumnCount = 2;
            this.sortStyleTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortStyleTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sortStyleTableLayout.Controls.Add(this.radioButton1, 0, 0);
            this.sortStyleTableLayout.Controls.Add(this.radioButton2, 1, 0);
            this.sortStyleTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortStyleTableLayout.Location = new System.Drawing.Point(400, 26);
            this.sortStyleTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.sortStyleTableLayout.Name = "sortStyleTableLayout";
            this.sortStyleTableLayout.RowCount = 1;
            this.sortStyleTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sortStyleTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.sortStyleTableLayout.Size = new System.Drawing.Size(484, 26);
            this.sortStyleTableLayout.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(236, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Comma seperated";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.Location = new System.Drawing.Point(245, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(236, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "New line seperated";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // MatchTab
            // 
            this.MatchTab.Location = new System.Drawing.Point(4, 25);
            this.MatchTab.Name = "MatchTab";
            this.MatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.MatchTab.Size = new System.Drawing.Size(890, 469);
            this.MatchTab.TabIndex = 1;
            this.MatchTab.Text = "Match";
            this.MatchTab.UseVisualStyleBackColor = true;
            // 
            // CountTab
            // 
            this.CountTab.Location = new System.Drawing.Point(4, 25);
            this.CountTab.Name = "CountTab";
            this.CountTab.Padding = new System.Windows.Forms.Padding(3);
            this.CountTab.Size = new System.Drawing.Size(890, 469);
            this.CountTab.TabIndex = 2;
            this.CountTab.Text = "Count";
            this.CountTab.UseVisualStyleBackColor = true;
            // 
            // htmlTab
            // 
            this.htmlTab.Location = new System.Drawing.Point(4, 25);
            this.htmlTab.Name = "htmlTab";
            this.htmlTab.Padding = new System.Windows.Forms.Padding(3);
            this.htmlTab.Size = new System.Drawing.Size(890, 469);
            this.htmlTab.TabIndex = 3;
            this.htmlTab.Text = "HTML:ify";
            this.htmlTab.UseVisualStyleBackColor = true;
            // 
            // Toolbar
            // 
            this.MainTableLayout.SetColumnSpan(this.Toolbar, 2);
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.HelpDropdown});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(904, 30);
            this.Toolbar.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // HelpDropdown
            // 
            this.HelpDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdasdToolStripMenuItem,
            this.aasdasdasdToolStripMenuItem});
            this.HelpDropdown.Image = ((System.Drawing.Image)(resources.GetObject("HelpDropdown.Image")));
            this.HelpDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpDropdown.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.HelpDropdown.Name = "HelpDropdown";
            this.HelpDropdown.Size = new System.Drawing.Size(55, 27);
            this.HelpDropdown.Text = "Help";
            // 
            // asdasdToolStripMenuItem
            // 
            this.asdasdToolStripMenuItem.Name = "asdasdToolStripMenuItem";
            this.asdasdToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.asdasdToolStripMenuItem.Text = "asdasd";
            // 
            // aasdasdasdToolStripMenuItem
            // 
            this.aasdasdasdToolStripMenuItem.Name = "aasdasdasdToolStripMenuItem";
            this.aasdasdasdToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.aasdasdasdToolStripMenuItem.Text = "aasdasdasd";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(904, 534);
            this.Controls.Add(this.MainTableLayout);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.MinimumSize = new System.Drawing.Size(547, 413);
            this.Name = "Application";
            this.Text = "ProgrammingUtils";
            this.MainTableLayout.ResumeLayout(false);
            this.MainTableLayout.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.SortTab.ResumeLayout(false);
            this.SortTableLayout.ResumeLayout(false);
            this.SortTableLayout.PerformLayout();
            this.sortHeader.ResumeLayout(false);
            this.sortHeader.PerformLayout();
            this.sortModeTableLayout.ResumeLayout(false);
            this.sortModeTableLayout.PerformLayout();
            this.sortStyleTableLayout.ResumeLayout(false);
            this.sortStyleTableLayout.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage SortTab;
        private System.Windows.Forms.TabPage MatchTab;
        private System.Windows.Forms.ToolStrip Toolbar;
        private System.Windows.Forms.ToolStripDropDownButton HelpDropdown;
        private System.Windows.Forms.ToolStripMenuItem asdasdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aasdasdasdToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel SortTableLayout;
        private System.Windows.Forms.TabPage CountTab;
        private System.Windows.Forms.TabPage htmlTab;
        private System.Windows.Forms.RichTextBox sortTextBoxLeft;
        private System.Windows.Forms.RichTextBox sortTextBoxRight;
        private System.Windows.Forms.Label sortLabel1;
        private System.Windows.Forms.Label sortLabel2;
        private System.Windows.Forms.TableLayoutPanel sortHeader;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.CheckBox AutoSortCheckbox;
        private System.Windows.Forms.TableLayoutPanel sortModeTableLayout;
        private System.Windows.Forms.RadioButton sortAlphabeticlyRadio;
        private System.Windows.Forms.RadioButton notSortAlphabeticlyRadio;
        private System.Windows.Forms.TableLayoutPanel sortStyleTableLayout;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

